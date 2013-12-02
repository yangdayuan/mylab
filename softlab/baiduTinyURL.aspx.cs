using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Net;
using NamespaceWeb;

public partial class softlab_baiduTinyURL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * 
         * HttpWebRequest在初始化的时候要先根据url进行创建，然后再设置Method和ContentType,然后再将请求的内容写进去，
         * 通过GetRequestStream来返回流，再向这个流中写请求内容便可以了。
         * 再通过request对象的GetResponse方法返回response对象，最后得到返回的数据流，
         * 这是通过GetResponseStream方法返回的，最后从这个流中读出返回的数据便ok了。
         */
        string URL_long = TextBox1.Text;

        string URL_short_Baidu = Utils.GetTinyURL_Baidu(URL_long);
        TextBox_baidu.Text = URL_short_Baidu;

        string URL_short_google = Utils.GetTinyURL_google(URL_long);
        TextBox_google.Text = URL_short_google;
    }

}