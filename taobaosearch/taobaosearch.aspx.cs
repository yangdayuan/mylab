using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NamespaceWeb;
using System.Text;

public partial class softlab_taobaosearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        //根据标题在淘宝搜索宝贝：
        //http://s.taobao.com/search?q=2013欧美夏季斜跨小包新款欧美女包包外贸潮女包邮手工包&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index

        string url = "http://s.taobao.com/search?q=" + TextBox1.Text + "&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index";
        string html = Web.Get(url, Encoding.Default);

        if (html.Contains("uniqpid") == true) //说明找到了同款宝贝
        {
            string uniqpid = html.Substring(html.IndexOf("uniqpid") + 10, 9);
            //根据宝贝标题和找到其中的uniqpid=-703331819，构造完整的查询同款宝贝的路径：
            //http://s.taobao.com/search?spm=a230r.1.10.4.aR3KvJ&q=2013欧美夏季斜跨小包新款欧美女包包外贸潮女包邮手工包&uniqpid=-703331819&nouniq=true&style=list&tab=coefp&from_pos=0_mini_samestyle-pop_null_null
            string tongkuanurl = "http://s.taobao.com/search?spm=a230r.1.10.4.aR3KvJ&q=" + TextBox1.Text + @"&uniqpid=-" + uniqpid + "&nouniq=true&style=list&tab=coefp&from_pos=0_mini_samestyle-pop_null_null";
            string tongkuanhtml = Web.Get(tongkuanurl, Encoding.Default);

            string tongkuanhtmlbody = tongkuanhtml.Substring(tongkuanhtml.IndexOf("<html>"));
            Label1.Text = tongkuanhtmlbody;
            Utils.SaveTxt("d:\\" + "TaobaoItem.htm", tongkuanhtml, false);
        }

        //Label1.Text = html;

    }
}