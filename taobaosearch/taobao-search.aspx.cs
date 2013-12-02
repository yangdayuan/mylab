using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NamespaceWeb;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;

public partial class softlab_taobao_search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      
        
        //根据标题在淘宝搜索宝贝：
        //http://s.taobao.com/search?q=2013欧美夏季斜跨小包新款欧美女包包外贸潮女包邮手工包&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index

        //Response.Write("10%");
        string baobeiTitle_URL = gbtoURLstring(TextBox1.Text); //把宝贝标题转成URL格式。
        //根据淘宝宝贝标题找到其同款宝贝列表的淘客地址
        string tongkuanurl = GetTaokeAddressbyTitle(baobeiTitle_URL);
            //Label2.Text = tongkuanurl;

            //打开新的窗口显示同款宝贝列表页面
            //Response.Write("<script>window.open('tongkuanurl','_blank')</script>");
            Response.Write("<script language='javascript'>window.open('" + tongkuanurl + "');</script>");

            //Response.Write("20%");
            //通过Get获取网页，结果证明显示效果不好，如果要继续用这种方法需要继续优化
            //string tongkuanhtml = Web.Get(tongkuanurl, Encoding.Default);

            /*
            //通过webbrowser获取网页
            AutoResetEvent resultEvent = new AutoResetEvent(false);

            IEBrowser browser = new IEBrowser(false, tongkuanurl, resultEvent);

            // wait for the third thread getting result and setting result event
            EventWaitHandle.WaitAll(new AutoResetEvent[] { resultEvent });
            // the result is ready later than the result event setting sometimes 
            while (browser == null || browser.HtmlResult == null) Thread.Sleep(5);

            string tongkuanhtmlbody = browser.HtmlResult;

            browser.Dispose();

            //string tongkuanhtmlbody = tongkuanhtml.Substring(tongkuanhtml.IndexOf("<html>"));

            //显示获取的同款宝贝查询页面——通过把html字符串赋值给Label
            //Label1.Text = tongkuanhtmlbody;
            //Utils.SaveTxt("d:\\" + "Tongkuantem.htm", tongkuanhtmlbody, false);

            //显示获取的同款宝贝查询页面——打开一个新窗口
            string path = Request.PhysicalApplicationPath; //获取当前路径
            Utils.SaveTxt(path + @"softlab/Tongkuantem.htm", tongkuanhtmlbody, false);
            Response.Output.WriteLine("<script>window.open ('Tongkuantem.htm','mywindow','location=1,status=0,scrollbars=1,resizable=1,width=600,height=600');</script>");

             */
  
        

        //Label1.Text = html;
        
    }

    //根据淘宝宝贝标题找到其同款宝贝列表的淘客地址
    private string GetTaokeAddressbyTitle(string taobaoTitle)
    {
        string tongkuanurl = "";
        Label2.Text = "";

        string url = "http://s.taobao.com/search?q=" + taobaoTitle /*+ "&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index"*/;
        string html = Web.Get(url, Encoding.Default);
        //Utils.SaveTxt("d:\\" + "TaobaoItem.htm", html, false);

        //MatchCollection mc_uniqpid = Regex.Matches(html, "\\(\\?<=uniqpid\\=\"-\\)\\d*"); //(?<=uniqpid\=\"-)\d*

        ////int j = 1;//用来表示序号
        //for (int i = 0; i < mc_uniqpid.Count; i++) //在输入字符串中找到所有匹配
        //{
        //    //Mogujiehtml = Mogujiehtml.Replace(mc_uniqpid[i].Value, ""); //将匹配的字符串删掉
        //    Label2.Text += mc_uniqpid[i].Value + " ";
        //}//此时的Mogujiehtml仅仅是删掉了错误的字符标记



        if (html.Contains("&uniqpid") == true) //说明找到了同款宝贝
        {
            string uniqpid = html.Substring(html.IndexOf("uniqpid") + 9, 10);
            if (uniqpid[9] == '\"')
            {
                uniqpid = uniqpid.Substring(0, 9);

            }
            if (uniqpid[8] == '\"')
                uniqpid = uniqpid.Substring(0, 8);

            //debug
            Label2.Text = uniqpid;

            //根据宝贝标题和找到其中的uniqpid=-703331819，构造完整的查询同款宝贝的路径：
            //http://s.taobao.com/search?spm=a230r.1.10.4.aR3KvJ&q=2013欧美夏季斜跨小包新款欧美女包包外贸潮女包邮手工包&uniqpid=-703331819&nouniq=true&style=list&tab=coefp&from_pos=0_mini_samestyle-pop_null_null
            tongkuanurl = "http://s8.taobao.com/search?q=" + taobaoTitle + @"&uniqpid=-" + uniqpid + "&nouniq=true&style=list&tab=coefp&from_pos=0_mini_samestyle-pop_null_null" + "&pid=mm_32042780_0_0";
        }
        return tongkuanurl;
    }

    //根据蘑菇街大类搜索宝贝地址
    protected void Button2_Click(object sender, EventArgs e)
    {
        ////根据蘑菇街地址在淘宝搜索宝贝：
        ////http://www.mogujie.com/note/1bnzht6?showtype=good&goodsid=15zepr2&p=p&atc=514020cd28c4a0.11946319

        //string url = TextBox1.Text;
        //string html = Web.Get(url, Encoding.Default);
        //Utils.SaveTxt("d:\\" + "TaobaoItem.htm", html, false);

        //获取宝贝大类页面
        //string url = "http://www.mogujie.com/book/bags/";

        //根据蘑菇街大类搜索宝贝地址列表
        string resultsum = GetAddressListbyMogujiePage("mogujiePage.htm");

        string filename_AddressList = Server.MapPath("1_mogujie_地址.txt");
        //File.AppendAllText(filename_AddressList, resultsum, Encoding.Default);
        Utils.SaveTxt(filename_AddressList, resultsum, false);
        //Encoding.GetEncoding("GB2312")

        //debug
        //string filename = Server.MapPath("mogujiebags.htm");
        //Utils.SaveTxt(filename, html, false);
        //Label2.Text = html;


        //Process p = new Process();
        //p.StartInfo.FileName = Server.MapPath("MogujieGetPage.exe"); //"MogujieGetPage.exe";//打开IE
        //p.Start();
        //p.Close();

        /*
        string filename = Server.MapPath("urls.txt");
        StringBuilder sb = new StringBuilder();
        StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("GB2312"));
        string sql = "";
        int i = 0;
        while (!sr.EndOfStream)
        {
            i++;
            string sa = sr.ReadLine();
            sql += "update tsm_staff set Order_No = '" + i + "' where real_name = '" + sa + "';\r\n";

            Process p = new Process();
            p.StartInfo.FileName = "MogujieGetPage.exe";//打开IE
            p.StartInfo.Arguments = sa;
            p.Start();
            p.Close();


        }

        sr.Close();
        filename = Server.MapPath("sql.txt");
        File.AppendAllText(filename, sql, Encoding.GetEncoding("GB2312"));
         */

    }
    //根据蘑菇街大类搜索宝贝地址列表
    private string GetAddressListbyMogujiePage(string filename)
    {
        string filename_mogujiePage = Server.MapPath(filename);

        StreamReader sr = new StreamReader(filename_mogujiePage, Encoding.GetEncoding("GB2312"));
        string Mogujiehtml = sr.ReadToEnd();
        sr.Close();

        MatchCollection mc;
        //String[] results = new String[600];
        int[] matchposition = new int[600]; //记录匹配字符的位置


        string resultsum = "";
        string lastmogunote = "";

        Regex r = new Regex("showtype"); //定义一个Regex对象实例
        mc = r.Matches(Mogujiehtml);

        int j = 1;//用来统计这是第几个匹配
        for (int i = 0; i < mc.Count; i++) //在输入字符串中找到所有匹配
        {

            //results[i] = mc[i].Value; //将匹配的字符串添在字符串数组中
            matchposition[i] = mc[i].Index; //记录匹配字符的位置
            string mogunote = Mogujiehtml.Substring(matchposition[i] - 8, 7);

            if (lastmogunote == mogunote) continue;
            lastmogunote = mogunote;
            
            resultsum += /*Convert.ToString(j)+ " " + */ "http://www.mogujie.com/note/" + mogunote + Environment.NewLine;
            j++;

        }
        Label2.Text = Convert.ToString(mc.Count);
        Label1.Text = resultsum;
        return resultsum;
    }


    //根据蘑菇街大类页面源码得到宝贝标题列表
    //
    protected void Button3_Click(object sender, EventArgs e)
    {
        //获取宝贝大类页面
        //string url = "http://www.mogujie.com/book/bags/";
        //string Titlelist = GetTitleListbyMogujiePage(url);

        //根据蘑菇街大类页面源码（文件名）得到宝贝标题列表
        string Titlelist = GetTitleListbyMogujiePageCodeString("mogujiePage.htm");

        string filename_titlelist = Server.MapPath("2_mogujie_标题.txt");
        //File.AppendAllText(filename, resultsum, Encoding.Default);
        Utils.SaveTxt(filename_titlelist, Titlelist, false);
    }

    //根据蘑菇街页面的URL获取该页面所有宝贝标题列表
    private string GetTitleListbyMogujiePage(string url)
    {
        string Mogujiehtml = Web.GetwholePage(url);

        string filename_mogujiePage = Server.MapPath("mogujiePage.htm");
        Utils.SaveTxt(filename_mogujiePage, Mogujiehtml, false);


        String[] results = new String[600];
        //int[] matchposition = new int[600]; //记录匹配字符的位置


        string resultsum = "";
        //string lastmogunote = "";

        //Regex r = new Regex(baoliu.Text); //定义一个Regex对象实例

        //删掉错误字符串
        MatchCollection mc_delete = Regex.Matches(Mogujiehtml, shandiao.Text);

        for (int i = 0; i < mc_delete.Count; i++) //在输入字符串中找到所有匹配
        {
            Mogujiehtml = Mogujiehtml.Replace(mc_delete[i].Value, ""); //将匹配的字符串删掉
        }//此时的Mogujiehtml仅仅是删掉了错误的字符标记

        //截取需要的前12个宝贝标题
        MatchCollection mc_12 = Regex.Matches(Mogujiehtml, baoliu12.Text);

        for (int i = 0; i < mc_12.Count; i++) //在输入字符串中找到所有匹配
        {
            resultsum += mc_12[i].Value + Environment.NewLine;
        }//此时的Mogujiehtml还仅仅是删掉了错误的字符标记，最上面的12个标题被保存在了resultsum

        //截取需要的宝贝标题
        MatchCollection mc = Regex.Matches(Mogujiehtml, baoliu.Text);

        for (int i = 0; i < mc.Count; i++) //在输入字符串中找到所有匹配
        {

            results[i] = mc[i].Value; //将匹配的字符串添在字符串数组中
            //matchposition[i] = mc[i].Index; //记录匹配字符的位置
            //转成汉字
            resultsum += unicodetogb(results[i]) + Environment.NewLine;
        }
        //Debug
        Label3.Text = "find:" + Convert.ToString(mc.Count + mc_12.Count) + "  delete:" + Convert.ToString(mc_delete.Count);
        return resultsum;
    }

    //根据蘑菇街页面的源代码字符串获取该页面所有宝贝标题列表("mogujiePage.htm")
    //输入参数为文件名
    private string GetTitleListbyMogujiePageCodeString(string filename)
    {
        string filename_mogujiePage = Server.MapPath(filename);
        
        StreamReader sr = new StreamReader(filename_mogujiePage, Encoding.GetEncoding("GB2312"));
        string Mogujiehtml = sr.ReadToEnd();
        sr.Close();

        String[] results = new String[600];
        //int[] matchposition = new int[600]; //记录匹配字符的位置


        string resultsum = "";
        //string lastmogunote = "";

        //Regex r = new Regex(baoliu.Text); //定义一个Regex对象实例

        //删掉错误字符串
        MatchCollection mc_delete = Regex.Matches(Mogujiehtml, shandiao.Text);

        int j = 1;//用来表示序号
        for (int i = 0; i < mc_delete.Count; i++) //在输入字符串中找到所有匹配
        {
            Mogujiehtml = Mogujiehtml.Replace(mc_delete[i].Value, ""); //将匹配的字符串删掉
        }//此时的Mogujiehtml仅仅是删掉了错误的字符标记

        //截取需要的前14个宝贝标题(汉字标题)
        MatchCollection mc_12 = Regex.Matches(Mogujiehtml, baoliu12.Text);

        for (int i = 0; i < mc_12.Count; i++) //在输入字符串中找到所有匹配
        {
            resultsum += /*Convert.ToString(j) + " " + */mc_12[i].Value + Environment.NewLine;
            j++;
        }//此时的Mogujiehtml还仅仅是删掉了错误的字符标记，最上面的12个标题被保存在了resultsum

        //截取其余的需要的宝贝标题（unicode标题）
        MatchCollection mc = Regex.Matches(Mogujiehtml, baoliu.Text);

        for (int i = 0; i < mc.Count; i++) //在输入字符串中找到所有匹配
        {

            results[i] = mc[i].Value; //将匹配的字符串添在字符串数组中
            //matchposition[i] = mc[i].Index; //记录匹配字符的位置
            //转成汉字
            resultsum += /*Convert.ToString(j) + " " + */unicodetogb(results[i]) + Environment.NewLine;
            j++;
        }
        //Debug
        Label3.Text = "find:" + Convert.ToString(mc.Count + mc_12.Count) + "  delete:" + Convert.ToString(mc_delete.Count);
        return resultsum;
    }


    //
    // 摘要:
    //     把一个字符串中的所有"\u1234"格式的unicode字符转换成相应gb2312字符（比如汉字和符号）。
    //
    public static string unicodetogb(string text)
    {


        //匹配"\u1234"格式的字符串，结果保存在mc中。
        System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(text, "\\\\u([\\w]{4})");
        //string textremovedU = text.Replace("\\u", "");

        //保存每个转换后的汉字字符
        char[] arr = new char[mc.Count];
        //保存每个转换前的字符串 "\u1234"
        String[] results = new String[mc.Count];

        //逐个替换输入字符串中的每个“\u1234”。
        for (int i = 0; i < mc.Count; i++)
        {
            results[i] = mc[i].Value; //将匹配的字符串添在字符串数组中

            //截取“\u”后面的部分，进行转换。
            //arr[i] = (char)Convert.ToInt32(results[i].Substring(2, 4), 16);
            arr[i] = (char)Convert.ToInt16(results[i].Substring(2, 4),16);
            //将该字符串“\u1234”替换为字符（单个字符）
            text = text.Replace(results[i], Convert.ToString(arr[i]));
        }
        //string c = new string(arr);

        return text;
    }

    //
    // 摘要:
    //     把一个汉字字符串转成URL格式的字符串（gb2312格式编码，并且数字0到9保持不变，空格转换成'+'）：。
    //
    public static string gbtoURLstring(string gbtext)
    {
        string urlstring = "";
        //转成gb2312的字符数组
        byte[] gb2312bytes = Encoding.GetEncoding("GB2312").GetBytes(gbtext);

        foreach (byte c in gb2312bytes)
        {
            if ((char)c >= '0' && (char)c <= '9')
                urlstring += (char)c;
            else if ((char)c == ' ')
                urlstring += "+";
            else urlstring += ("%" + ((int)c).ToString("X"));
        }
        return urlstring;
    }

    //根据mogujie_标题列表.txt生成 mogujie_标题+链接列表.txt
    protected void Button4_Click(object sender, EventArgs e)
    {
        string filename_2 = Server.MapPath("2_mogujie_标题.txt");

        StreamReader sr = new StreamReader(filename_2, Encoding.GetEncoding("GB2312"));
        string newline = "";
        string newline_onlyshorturl = "";
        string baobeiTitle_URL = "";
        int i = 0;
        while (!sr.EndOfStream)
        {
            i++;
            baobeiTitle_URL = "";
            string baobeiTitle = sr.ReadLine();//从标题列表中获取一行（一个宝贝标题）

            baobeiTitle_URL = gbtoURLstring(baobeiTitle); //把宝贝标题转成URL格式。
            string tongkuanurl = GetTaokeAddressbyTitle(baobeiTitle_URL); //得到同款宝贝列表淘客链接地址
            newline += i + " " + baobeiTitle + " ," + tongkuanurl + ";\r\n";   //标题+链接 加入字符串中

            if (tongkuanurl == "")
                newline_onlyshorturl += "\r\n";
            else newline_onlyshorturl += /*i + " " + */ Utils.GetTinyURL_Baidu(tongkuanurl) + "\r\n";  //生成短网址
        }
        sr.Close();
        string filename_3 = Server.MapPath("3_mogujie_标题+链接.txt");
        File.WriteAllText(filename_3, newline, Encoding.Default);

        string filename_4 = Server.MapPath("4_mogujie_短链接.txt");
        File.WriteAllText(filename_4, newline_onlyshorturl, Encoding.Default);
    }
    protected void DownloadMogujiePage_Click(object sender, EventArgs e)
    {
        string url = Label4.Text;
        string Mogujiehtml = Web.GetwholePage(url);

        string filename_mogujiePage = Server.MapPath("mogujiePage.htm");
        Utils.SaveTxt(filename_mogujiePage, Mogujiehtml, false);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //string BaobeiURL = "http://www.mogujie.com/note/1cautyc";
        string Comments = ""; // "我在另一家买的，比这便宜 " + "goo.gl/FvXA7";
        string AddressAndTinyURL = "";

        string filename_Address = Server.MapPath("1_mogujie_地址.txt");
        StreamReader sr_Address = new StreamReader(filename_Address);

        string filename_TinyURL = Server.MapPath("4_mogujie_短链接.txt");
        StreamReader sr_TinyURL = new StreamReader(filename_TinyURL);

        //FileStream stream = new FileStream("d:/debug1.txt", FileMode.Create);
        //StreamWriter fileWriter = new StreamWriter(stream, Encoding.Default);
        //fileWriter.Flush();
        //fileWriter.Close();
        //System.Diagnostics.Process.Start("d:/debug1.txt");

        int i = 0;
        while (!sr_Address.EndOfStream)
        {
            i++;
            string baobei_Address = sr_Address.ReadLine();//从标题列表中获取一行（一个宝贝地址）
            string baobei_TinyURL = sr_TinyURL.ReadLine();//从标题列表中获取一行（一个宝贝短链接）
            if((baobei_Address!="")&&(baobei_TinyURL!=""))
            {
                Comments = "我在另一家买的，比这便宜 "/* + baobei_TinyURL*/;
                AddressAndTinyURL += (baobei_Address + " " + Comments + "\r\n");
                PostCommentsOnMogujieBaobei(baobei_Address, Comments);
                //Trace.Write(Convert.ToString(i)+"\r\n");

                //debug
                //fileWriter.WriteLine(Convert.ToString(i) + "\r\n");

                System.Threading.Thread.Sleep(5000); //延迟5s
            }
            if (i > 1)
                break;
        }

        //fileWriter.Flush();
        //fileWriter.Close();
        //fileWriter.WriteLine("echo ----------- 结束 ------------------");

        sr_Address.Close(); sr_Address.Dispose();
        sr_TinyURL.Close(); sr_TinyURL.Dispose();

        string filename_AddressandTinyURL = Server.MapPath("5_mogujie_地址+短链接.txt");
        Utils.SaveTxt(filename_AddressandTinyURL, AddressAndTinyURL, false);

        //PostCommentsOnMogujieBaobei(BaobeiURL, Comments);
        //Label5.Text = content;

    }

    private static void PostCommentsOnMogujieBaobei(string BaobeiURL, string Comments)
    {
        string Comments_utf8 = "";

        byte[] u8bytes = Encoding.UTF8.GetBytes(Comments);
        foreach (byte c in u8bytes)
        {
            if (((char)c >= '0' && (char)c <= '9') || ((char)c >= 'a' && (char)c <= 'z') || ((char)c >= 'A' && (char)c <= 'Z') || (char)c == '.')
                Comments_utf8 += (char)c;
            else if ((char)c == ' ')
                Comments_utf8 += "+";
            else Comments_utf8 += ("%" + ((int)c).ToString("X"));
        }

        Encoding encoding = Encoding.GetEncoding("UTF-8");
        //Encoding encoding = Encoding.Default;

        Stream outstream = null;
        Stream instream = null;
        StreamReader sr = null;
        string url = "http://www.mogujie.com/replytwitter/add";
        HttpWebRequest request = null;
        HttpWebResponse response = null;




        // 准备请求,设置参数
        request = WebRequest.Create(url) as HttpWebRequest;
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        request.Referer = BaobeiURL;
        request.Accept = "Accept: application/json, text/javascript, */*; q=0.01";

        request.Headers.Add("Accept-Encoding: gzip, deflate");
        request.Headers.Add("x-requested-with: XMLHttpRequest");
        //request.Headers.Add("Connection: Keep-Alive");

        //得到当前的UNIX时间，用来修改cookie中的时间戳。
        string currenttime = GetCurrentUnixTime();

        request.Headers.Add("Cookie: bdshare_firstime=1363157257734; __mogujiettcc=1; __mogujie=9bDEICEnHeYbUIAt2NNUnex6F%2Bw9TV7Pu7%2F7AvmIR0bNNxZ6KwagyiHxlxU8GmFUhTn%2BThF7MsHPRJkcRllHgQ%3D%3D; __mgjuuid=0bf049a3-5276-d075-f3fe-ea6511884506; __utma=1.352569515.1362651730.1364542566." + currenttime + ".21; __utmz=1.1362651730.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); if_show_newyears=2%2C13; __areaid=5; if_show_rightsiderbar=1; __ud_=1174ab2; __utmb=1.1.10." + currenttime + "; __utmc=1");
        //Cookie: bdshare_firstime=1363157257734; __mogujiettcc=1; __mogujie=GhF7vYZ8izYR1Kfjc9qdmAecYFd7vzvSqtcsc%2BNhgVVZXfR5X4ejA5vuLWECqFAJr%2FjpxiaWfqWWWIPZr4E4%2Bw%3D%3D; __mgjuuid=0bf049a3-5276-d075-f3fe-ea6511884506; __utma=1.352569515.1362651730.1364542566.1364546548.21; __utmz=1.1362651730.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); if_show_newyears=2%2C13; __areaid=5; if_show_rightsiderbar=1; __ud_=1174ab2; __utmb=1.1.10.1364546548; __utmc=1

        byte[] data = encoding.GetBytes("replyId=1cautyc&content=" + Comments_utf8 + "&print=2&nttype=newnote&is_public=&type=&itemInfoId=&ff=");
        //replyId=1cautyc&content=%E6%88%91%E4%B9%B0%E7%9A%8458%EF%BC%8C%E9%9C%80%E8%A6%81%E7%9A%84%E5%8F%AF%E4%BB%A5%E5%8E%BB%E7%9C%8B%E4%B8%80%E4%B8%8B+%40goo.gl%2FFvXA7&print=2&nttype=newnote&is_public=&type=&itemInfoId=&ff=
        request.ContentLength = data.Length;
        outstream = request.GetRequestStream();
        outstream.Write(data, 0, data.Length);
        outstream.Flush();
        outstream.Close();

        //发送请求并获取相应回应数据


        response = request.GetResponse() as HttpWebResponse;
        //直到request.GetResponse()程序才开始向目标网页发送Post请求
        instream = response.GetResponseStream();
        sr = new StreamReader(instream, encoding);
        //返回结果网页(html)代码


        string content = sr.ReadToEnd();
    }

    private static string GetCurrentUnixTime()
    {
        double intResult = 0;
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        System.DateTime time = System.DateTime.Now;
        intResult = (time - startTime).TotalSeconds;
        //return intResult;
        string currenttime = ((int)intResult).ToString();
        return currenttime;
    }
}