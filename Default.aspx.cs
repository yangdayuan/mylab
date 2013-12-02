using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using NamespaceWeb;
using System.IO;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Response;
using Top.Api.Request;

    public partial class _Default : System.Web.UI.Page
    {
        static string code = "";
        static string sin = "";
        private string url;
        private string appkey;
        private string appsecret;
        private string sessionKey = "";
        private string baobeinote = "";
        static private string baobeidalei = "clothing";

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            mogujiereturn.Text = "";
            FavoriteNum.Text = "";
            uploadDate.Text = "";

            //http://container.api.tbsandbox.com/container?appkey=1021222682
            //http://container.open.taobao.com/container?appkey=21222682

            if (Request.QueryString["top_appkey"] != null)
            {
                if (Request.QueryString["top_appkey"] == "21222682")
                {
                    //正式
                    url = "http://gw.api.taobao.com/router/rest";
                    appkey = "21222682";
                    appsecret = "85215a3419a1745c5cb3173ec513c7c4";
                }
                else if (Request.QueryString["top_appkey"] == "1021222682")
                {
                    //沙箱
                    url = "http://gw.api.tbsandbox.com/router/rest";//沙箱环境调用地址,
                    appkey = "1021222682";
                    appsecret = "sandbox419a1745c5cb3173ec513c7c4";
                }
                if (Request.QueryString["top_session"].ToString() != null)
                {
                    sessionKey = Request.QueryString["top_session"].ToString();
                }
            }
            else
            {
                url = "http://gw.api.tbsandbox.com/router/rest";//沙箱环境调用地址,
                appkey = "1021222682";
                appsecret = "sandbox419a1745c5cb3173ec513c7c4";
            }
        }
        //宝贝在蘑菇街大分类页码查询
        protected void Button1_Click(object sender, EventArgs e)
        {
            code = "";
            Label1.Text = "";
            LBdebug1.Text = "";
            LBdebug2.Text = "";
            LBdebug3.Text = "";

            Getbaobeidalei();

            Int32 retry = 0;
            Int32 pagenumber = 1;

            //string url = "http://www.mogujie.com/book/bags/%E7%89%9B%E7%9A%AE?f3cid=4021";

            //根据用户给出的大分类决定URL , 默认值是 clothing， 例如 string url = "http://www.mogujie.com/book/bags/";
            string url = "http://www.mogujie.com/book/" + baobeidalei;
            

            //从蘑菇街地址中截取出宝贝note
            baobeinote = Labelbaobeinote.Text.Substring(Labelbaobeinote.Text.IndexOf(@"/note/") + 6, 7);
            
            //“包包”大分类的第二页地址
            //http://www.mogujie.com/book/bags/%E5%8C%85%E5%8C%85/2/pop/all/?color=&fcid=&childid=0&childname=&minPrice=&maxPrice=&fc=&fc_v=&f=
            //http://www.mogujie.com/book/bags/包包/2/pop/all/
            //Form1 win = new Form1();
            //win.url = url;
            //win.ShowDialog();
            //url = win.url;

            //TextBox1.Text = url;
            //url = TextBox1.Text;

            //从给定网址下载源码，存入“code”中
            string html = Web.Get(url);
            GetPage(html, 1, false);

            //调试代码用：
            //Utils.SaveTxt("d:\\mogujie.htm", code, false);

            //LBdebug1.Text = code;
            LBdebug1.Text = Convert.ToString(code.Length);//记录下载的网页大小
            LBdebug3.Text = url + "<br/>";

            //如果在10页以内没有找到则循环找下一页
            while ((code.Contains(baobeinote) != true)&& pagenumber < 10)
            {
                code = "";
                pagenumber++; //进入新的一页

                //url = "http://www.mogujie.com/book/bags/包包/" + pagenumber + "/pop/all/";
                url = "http://www.mogujie.com/book/" + baobeidalei + "/蘑菇街/" + pagenumber;
                

                html = Web.Get(url);
                GetPage(html, 1, false);

                //调试代码用：
                //Utils.SaveTxt("d:\\mogujie"+Convert.ToString(pagenumber)+".htm", code, false);
                LBdebug1.Text += ("/" + Convert.ToString(pagenumber) + "/" + Convert.ToString(code.Length));//记录下载的网页大小
                LBdebug3.Text += url + "<br/>";

                //如果下载字节小于300000，重试3次
                if ((code.Length < 300000) && (retry < 3))
                {
                    pagenumber--;
                    retry++;
                    LBdebug2.Text += "page:" + Convert.ToString(pagenumber + 1) + " length:" + Convert.ToString(code.Length) + " retry:" + Convert.ToString(retry) + "<br/>";
                }
                else
                {
                    retry = 0;//新的一页重试计数器清零
                }
            }
            if (code.Contains(baobeinote) == true)
            {
                Label1.Text = "在" + DropDownList1.Text + "大类的第" + Convert.ToString(pagenumber) + "页找到了宝贝";
            }
            else
            {
                Label1.Text = "您的宝贝在前" + Convert.ToString(pagenumber)+ "页没有搜索到";
            
            }

        }


        static void GetPage(string html, int page, bool ajax)
        {
            Console.WriteLine(string.Format("page {0} download OK.", page));
            if (string.IsNullOrEmpty(html))
            {
                return;
            }
            string lastTweetId = Utils.GetRegValue("lastTweetId:\".+?\"", html);
            string book = Utils.GetRegValue("book:\".+?\"", html);
            string totalCol = "4";
            string total = Utils.GetRegValue("totalCnt:\".+?\"", html);
            string is_end = Utils.GetRegValue("is_end\":.+?,", html);
            if (ajax)
            {
                lastTweetId = Utils.GetRegValue("lastTweetId\":\".+?\"", html);
                book = sin;
                totalCol = "4";
                total = Utils.GetRegValue("totalCnt:\".+?\"", html);
                is_end = Utils.GetRegValue("is_end\":.+?,", html);
                html = Utils.FormatJson(html);
            }
            else
            {
                sin = book;
            }

            code += html;
            string url = "http://www.mogujie.com/book/ajax";
            string data = string.Format("lastTweetId={0}&book={1}&totalCol={2}&page={3}&total={4}", lastTweetId, book, totalCol, page, total);

            if (is_end != "true" || !string.IsNullOrEmpty(lastTweetId))
            {
                string newhtml = Web.Get(url + "?" + data);
                GetPage(newhtml, page + 1, true);
            }
        }
        protected void Button4_Click1(object sender, EventArgs e)
        {
            string webaddress = "http://www.mogujie.com/book/search/" + baobeiname.Text;
            //string webaddress = "http://www.mogujie.com/book/bags/%E7%89%9B%E7%9A%AE?f3cid=4021";

            string pageHtml = Web.Get(webaddress);
            //string keyword = "找到1个";
            string keyword = "对不起";

            if (pageHtml.Contains(keyword) != true) //说明找到了，也就是被收录了。
            {
                baobeinote = pageHtml.Substring(pageHtml.IndexOf(@"/note/") + 6, 7);
                mogujiereturn.Text = "http://www.mogujie.com/note/" + baobeinote;
                FavoriteNum.Text = pageHtml.Substring(pageHtml.IndexOf("favCount") + 26, 6);
                
                //调试用：在页面上显示下载的页面源码
                //uploadDate.Text = pageHtml;

                //从新的页面得到一些数据：发布的用户名，喜欢数，发布日期
                //uploadDate.Text = "http://www.mogujie.com/note/" + pageHtml.Substring(pageHtml.IndexOf(@"/note/") + 6, 7);

                ////保存在本地以便查看调试（以后会删掉）
                //using (StreamWriter sw = new StreamWriter(@"D:\00_Data\ouput.html"))//将获取的内容写入文本
                //{
                //    sw.Write(pageHtml);
                //}


            }
            else
            {
                mogujiereturn.Text = "您的宝贝尚未收录";
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            DefaultTopClient client = new DefaultTopClient(url, appkey, appsecret);

          
            //client.SetDisableTrace(true);

            UserBuyerGetRequest req = new UserBuyerGetRequest();
            req.Fields = "nick,sex";
            //UserBuyerGetResponse response = client.Execute(req, sessionKey);
            //Label2.Text = response.Body;
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getbaobeidalei();
        }

        private void Getbaobeidalei()
        {
            switch (DropDownList1.Text)
            {
                case "衣服":
                    baobeidalei = "clothing";
                    break;
                case "鞋子":
                    baobeidalei = "shoes";
                    break;
                case "包包":
                    baobeidalei = "bags";
                    break;
                case "配饰":
                    baobeidalei = "accessories";
                    break;
                case "家居":
                    baobeidalei = "home";
                    break;
                case "美妆":
                    baobeidalei = "beauties";
                    break;
            }
            TBmogujiedalei.Text = baobeidalei;
        }
}
