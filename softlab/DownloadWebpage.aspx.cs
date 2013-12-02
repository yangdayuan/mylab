using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using System.Threading;
using NamespaceWeb;
using System.IO;

/*
 * try download web page by different way.
 * http://www.cnblogs.com/ceachy/articles/CSharp_Retrive_Page_Document.html
 */

public partial class softwaregrocery_DownloadWebpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = Web.Get(TextBox1.Text);
    }

    
    protected void Button2_Click(object sender, EventArgs e)
    {

        DownloadWebpage();

    }
 
    private void DownloadWebpage()
    {
        string URL = TextBox1.Text;

        AutoResetEvent resultEvent = new AutoResetEvent(false);
        string result = null;

        bool visible = this.Checkbox1.Checked;

        IEBrowser browser = new IEBrowser(visible, URL, resultEvent);

        // wait for the third thread getting result and setting result event
        EventWaitHandle.WaitAll(new AutoResetEvent[] { resultEvent });
        // the result is ready later than the result event setting sometimes 
        while (browser == null || browser.HtmlResult == null) Thread.Sleep(5);

        result = browser.HtmlResult;

        if (!visible) browser.Dispose();

        //把获取的html内容通过label显示出来
        Label2.Text = result;

        //保存结果到本程序的目录中
        string path = Request.PhysicalApplicationPath;
        TextWriter tw = new StreamWriter(path + @"softlab/result.html");
        tw.Write(result);
        tw.Close();

        //open a new web page to display result got from webbrowser.
        Response.Output.WriteLine("<script>window.open ('result.html','mywindow','location=1,status=0,scrollbars=1,resizable=1,width=600,height=600');</script>");
    }

    void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser web = (WebBrowser)sender;
        //using (StreamWriter sw = new StreamWriter(@"D:\00_Data\00_TOP_Developer\00_Projects\tempdata\ouput1.html"))//将获取的内容写入文本
        //{
        //    sw.Write(web.Document.Title);
        //}
        HtmlElementCollection ElementCollection = web.Document.GetElementsByTagName("Table");
        foreach (HtmlElement item in ElementCollection)
        {
            //File.AppendAllText(@"d:\00_Data\00_TOP_Developer\00_Projects\tempdata\ouput.htm", item.InnerText);
            Label2.Text += item.InnerText;
        }
    }
}