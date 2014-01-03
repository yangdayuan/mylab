using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NamespaceWeb;
using System.Text;

public partial class Mystocks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] stocklist = { "300001", "002440", "300303", "002065", "300027", "300170", 
                                 "002081", "600340",  "601633", "002496", "600880", "300339" ,
                             "002648","002570",};
        foreach (string stocknum in stocklist)
        {
            string url = "http://resource.stockstar.com/DataCenter/PrivateData/GetInvestRankSummary.aspx?sc=" + stocknum + "&ed=%C8%FD%B8%F6%D4%C2";
            string url_earning = "http://resource.stockstar.com/DataCenter/PrivateData/GetGains.aspx?sc=" + stocknum + "&ed=%C8%FD%B8%F6%D4%C2";

            string html = Web.Get(url, Encoding.Default);
            if (html.Contains("<tr class=\"td3\">") == false)
                continue;
            //取出从这个股票信息的第一个字符开始直到这个网页最后一个字符的字符串stocktoend。
            string stocktoend = html.Substring(html.IndexOf("<tr class=\"td3\">"));
            //找到股票信息在stocktoend中的结束的位置，作为截取子字符串的长度。
            string stockinfo = stocktoend.Substring(0, stocktoend.IndexOf("</tr>") + 5);

            //需要找到股票信息字符串中GetInvestRank.aspx的位置并在前面加上完整路径。
            string stockinfoadjust = stockinfo.Insert(stockinfo.IndexOf("GetInvestRank.aspx"), "http://resource.stockstar.com/DataCenter/PrivateData/");
            stockinfoadjust = stockinfoadjust.Insert(stockinfoadjust.IndexOf("GetInvestRank.aspx") + "GetInvestRank.aspx?sc=600315".Length, "&ed=%C8%FD%B8%F6%D4%C2");


            Label1.Text += stockinfoadjust;
            
            //获取每股收益信息
            string html_earning = Web.Get(url_earning, Encoding.Default);
            if (html_earning.Contains("<tr class=\"td3\">") == false)
                continue;
            //取出从这个股票信息的第一个字符开始直到这个网页最后一个字符的字符串stocktoend。
            stocktoend = html_earning.Substring(html_earning.IndexOf("<tr class=\"td3\">"));
            //找到股票信息在stocktoend中的结束的位置，作为截取子字符串的长度。
             stockinfo = stocktoend.Substring(0, stocktoend.IndexOf("</tr>") + 5);

            //需要找到股票信息字符串中GetInvestRank.aspx的位置并在前面加上完整路径。
             stockinfoadjust = stockinfo.Insert(stockinfo.IndexOf("GetGainsList.aspx"), "http://resource.stockstar.com/DataCenter/PrivateData/");
             //stockinfoadjust = stockinfoadjust.Insert(stockinfoadjust.IndexOf("GetGainsList.aspx") + "GetGainsList.aspx?sc=600315".Length, "&ed=%C8%FD%B8%F6%D4%C2");
             stockinfoadjust.Replace("三个月", "%C8%FD%B8%F6%D4%C2");

             Label2.Text += stockinfoadjust;
            /* 保存格式
            <tr class="td3">
		<td class="style2">1</td><td><a target="_blank" href="http://stock.quote.stockstar.com/600315.shtml">
        <span class="style3">600315</span></a></td><td><a target="_blank" href="http://stock.quote.stockstar.com/600315.shtml">
            <span class="style3">上海家化</span></a></td><td class="style2">3</td>
        <td class="style2">3</td><td class="style2">-</td><td class="style2">-</td>
        <td class="style2">0</td><td><a target="_blank" href="http://resource.stockstar.com/DataCenter/PrivateData/GetInvestRank.aspx?sc=600315&ed=%C8%FD%B8%F6%D4%C2"">
        <span class="style3">6</span></a></td><td class="style2">2013-02-05</td>
        <td class="style2"><a target="_blank" href="http://stock.quote.stockstar.com/600315.shtml">
            <span class="style1">行情</span></a> <a target="_blank" href="http://news.stockstar.com/info/dstock.aspx?code=600315">
            <span class="style1">资讯</span></a> <a target="_blank" href="http://bar.stockstar.com/redir1.asp?code=600315">
            <span class="style1">股吧</span></a></td>
	</tr>
             * */
        }
        //调试代码用：
        //Utils.SaveTxt("d:\\" + "stocknum.htm", stockinfo, false);
    }
}