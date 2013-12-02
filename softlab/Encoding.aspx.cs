using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

//参考： http://msdn.microsoft.com/zh-cn/library/windowsazure/system.text.encoding.aspx

/*
 * 学习体会：

 * 字符串可以通过各种不同的编码方式获取成为字节数组。不同编码格式的字节数组之间也可以直接转换。
 * byte[] u16bytes = utf16.GetBytes(u16s);
 * byte[] gb2312bytes = gb2312.GetBytes(u16s);
 * byte[] gb2312bytes = Encoding.Convert(utf16, gb2312, u16bytes); 等价于上面的转换方式
 * 
 * 各种不同的字符编码只是在转换成int的时候才能看到不同，在转换成char的时候格式是唯一的。也因此各种不同编码的字符数组在转成字符串的时候是一致的。
 * 因此要想管看出不同编码方式的区别，就只能把字符数组中的字符先转成int格式，然后再转成tring，这样就看出了表达的不同：
 * unicodestring.Text += (((int)c).ToString("x2") + " ");
 * 
 * 在unicodetogb中可以看出用utf16格式表达的字符串“\u6843\u7ea2\u8272”，在转成汉字的时候下面两种方法是一样的，
 * 都是把6843作为一个16位字符串转换成16位有符号整数，下面这个函数的第二个参数16是指原格式是16位的，第一个参数是16位表示的字符串。
 * 两种方式都是转成整数，一个是32位的，一个是16位的，最后转成char之后结果都是一样的。
 * arr[i] = (char)Convert.ToInt32(results[i].Substring(2, 4), 16);
 * arr[i] = (char)Convert.ToInt16(results[i].Substring(2, 4),16);
 * 
 * 
*/

public partial class zahuopu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        unicodestring.Text = "";
        unicodeFFFEstring.Text = "";
        utf8string.Text = "";
        gbkstring.Text = "";
        big5string.Text = "";
        gb2312string.Text = "";
        urlstring.Text = "";
        utf8urlstring.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
             
            string u16s = TextBox1.Text; //默认的字符编码是unicode,也就是utf16   

            //n种编码   
            Encoding utf8 = Encoding.UTF8;
            //位元組由小到大
            Encoding utf16 = Encoding.Unicode;
            //位元組由大到小
            Encoding unicodeFFFE = Encoding.GetEncoding("unicodeFFFE");

            Encoding gb = Encoding.GetEncoding("gbk");
            Encoding b5 = Encoding.GetEncoding("big5");
            Encoding gb2312 = Encoding.GetEncoding("GB2312");



            //转换得到4种编码的字节流   
            //先把字符串转成字节数组才能转换编码方式
            byte[] u16bytes = utf16.GetBytes(u16s);
            byte[] unicodeFFFEbytes = Encoding.Convert(utf16, unicodeFFFE, u16bytes);
            byte[] u8bytes = Encoding.Convert(utf16, utf8, u16bytes);
            byte[] gbytes = Encoding.Convert(utf16, gb, u16bytes);
            byte[] bbytes = Encoding.Convert(utf16, b5, u16bytes);
            //byte[] gb2312bytes = Encoding.Convert(utf16, gb2312, u16bytes); 等价于下面的转换方式
            byte[] gb2312bytes = gb2312.GetBytes(u16s);

            //Console.Write("unicode: ");
           
            //Array.Reverse(u16bytes);   
            foreach (byte c in u16bytes)
            //foreach (byte c in Encoding.Default.GetBytes(u16s))
            {
                //Console.Write(((int)c).ToString("X") + " ");
                unicodestring.Text += (((int)c).ToString("x2") + " ");
            }
            //Console.WriteLine();
            foreach (byte c in unicodeFFFEbytes)
            {
                //Console.Write(((int)c).ToString("X") + " ");
                unicodeFFFEstring.Text += (((int)c).ToString("x2") + " ");
            }
            //Console.Write("utf8: ");
            foreach (byte c in u8bytes)
            {
                //Console.Write(((int)c).ToString("X") + " ");
                utf8string.Text += (((int)c).ToString("X") + " ");
            }
            //Console.WriteLine();

            //Console.Write("gbk: ");
            foreach (byte c in gbytes)
            {
                //Console.Write(((int)c).ToString("X") + " ");
                gbkstring.Text += (((int)c).ToString("X") + " ");
            }
            //Console.WriteLine();
        
            //Console.Write("big5: ");
            foreach (byte c in bbytes)
            {
                //Console.Write(((int)c).ToString("X") + " ");
                //big5string.Text += (((int)c).ToString("X") + " ");
                big5string.Text += (((int)c).ToString("X") + " "); 
            }
            //Console.WriteLine();

            foreach (byte c in gb2312bytes)
            {
                gb2312string.Text += (((int)c).ToString("X") + " ");
            }

            foreach (byte c in gb2312bytes)
            {
                if ((char)c >= '0' && (char)c <= '9')
                    urlstring.Text += (char)c;
                else if((char)c == ' ')
                    urlstring.Text +=  "+";
                else urlstring.Text += ( "%" + ((int)c).ToString("X") );
            }
            foreach (byte c in u8bytes)
            {
                if (((char)c >= '0' && (char)c <= '9') || ((char)c >= 'a' && (char)c <= 'z') || ((char)c >= 'A' && (char)c <= 'Z') || (char)c == '.')
                    utf8urlstring.Text += (char)c;
                else if ((char)c == ' ')
                    utf8urlstring.Text += "+";
                else utf8urlstring.Text += ("%" + ((int)c).ToString("X"));
            }
            ////得到4种编码的string   
            //string u8s = utf8.GetString(u8bytes);
            //string gs = gb.GetString(gbytes);
            //string bs = b5.GetString(bbytes);

            //Console.WriteLine("unicode: " + u16s + " " + u16s.Length.ToString());
            //Console.WriteLine("utf8: " + u8s + " " + u8s.Length.ToString());
            //Console.WriteLine("gbk: " + gs + " " + gs.Length.ToString());
            //Console.WriteLine("big5: " + bs + " " + bs.Length.ToString());

            //Console.Write("unicode: ");
            //foreach (char c in u16s)
            //{
            //    Console.Write(((int)c).ToString("x") + " ");
            //}
            //Console.WriteLine();

            //Console.Write("utf8: ");
            //foreach (char c in u8s)
            //{
            //    Console.Write(((int)c).ToString("x") + " ");
            //}
            //Console.WriteLine();

            //Console.Write("gb2312: ");
            //foreach (char c in gs)
            //{
            //    Console.Write(((int)c).ToString("x") + " ");
            //}
            //Console.WriteLine();

            //Console.Write("big5: ");
            //foreach (char c in bs)
            //{
            //    Console.Write(((int)c).ToString("x") + " ");
            //}
            //Console.WriteLine();

            //Console.ReadKey();
        }


    protected void Button2_Click(object sender, EventArgs e)
    {
        hanzistring.Text = unicodetogb(TextBox2.Text);
    }
    public static string unicodetogb(string text)
    {
        

        //匹配"\u1234"格式的字符串，结果保存在mc中。
        System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(text, "\\\\u([\\w]{4})");
        //string textremovedU = text.Replace("\\u", "");

        //保存每个转换后的汉字字符
        char[] arr = new char[mc.Count];
        //保存每个转换前的字符串 "\u1234"
        String[] results = new String[mc.Count];

        for (int i = 0; i < mc.Count; i++)
        {
            results[i] = mc[i].Value; //将匹配的字符串添在字符串数组中
            //arr[i] = (char)Convert.ToInt32(results[i].Substring(2, 4), 16);
            arr[i] = (char)Convert.ToInt16(results[i].Substring(2, 4),16);
            text = text.Replace(results[i], Convert.ToString(arr[i]));
        }
        //string c = new string(arr);

        return text;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        //在文本框中读取字符串
        //在4中查找3
        System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(TextBox4.Text, TextBox3.Text);

        ////从文件中读取字符串
        //string filename = Server.MapPath("mogupage.txt");
        //StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("GB2312"));
        //string mogupagestring = "";
        
        //while (!sr.EndOfStream)
        //{
        //    mogupagestring += sr.ReadLine();
        //}
        //sr.Close();

        //System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(mogupagestring, TextBox3.Text);

        for (int i = 0; i < mc.Count;i++ )
            Label1.Text += Convert.ToString(mc[i].Value)+ " ";
    }
}

