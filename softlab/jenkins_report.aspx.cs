//#define DOWNLOADHTML

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NamespaceWeb;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;



public partial class softlab_jenkins_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Now;
        Datetime.Text = dt.ToString("d");

        //get html from web
#if DOWNLOADHTML

        //Note: only use http but not https
        string url = "http://beling19.china.nsn-net.net:8090/view/uREC";
        string kampiurl = "http://kampi.emea.nsn-net.net:2020/";
        string trunk_ECL_url = "http://kampi.emea.nsn-net.net:2020/view/Adaptation/view/trunk_ECL/";
        string Dev_url = "http://beling19.china.nsn-net.net:8090/view/DEV/";

        //string html = Web.Get(url, Encoding.Default, true);

        string html = DownloadWebpage(url);
        Utils.SaveTxt("d:\\" + "jenkins.htm", html, false);

        string kampihtml = DownloadWebpage(kampiurl);
        Utils.SaveTxt("d:\\" + "jenkins_kampi.htm", kampihtml, false);

        string trunk_ECL_html = DownloadWebpage(trunk_ECL_url);
        Utils.SaveTxt("d:\\" + "jenkins_trunk_ECL.htm", trunk_ECL_html, false);

        string dev_html = DownloadWebpage(Dev_url);
        //string dev_html = Web.Get(Dev_url, Encoding.Default, true);
        Utils.SaveTxt("d:\\" + "jenkins_dev.htm", dev_html, false);
        
#else
        //get html from local
        StreamReader sr = new StreamReader("d:\\jenkins.htm");//, Encoding.GetEncoding("GB2312")
        string html = sr.ReadToEnd();
        sr.Close();
        
        StreamReader sr_kampi = new StreamReader("d:\\jenkins_kampi.htm");//, Encoding.GetEncoding("GB2312")
        string kampihtml = sr_kampi.ReadToEnd();
        sr_kampi.Close();

        StreamReader sr_trunk_ECL = new StreamReader("d:\\jenkins_trunk_ECL.htm");//, Encoding.GetEncoding("GB2312")
        string trunk_ECL_html = sr_trunk_ECL.ReadToEnd();
        sr_trunk_ECL.Close();

        StreamReader sr_DEV = new StreamReader("d:\\jenkins_dev.htm");//, Encoding.GetEncoding("GB2312")
        string dev_html = sr_DEV.ReadToEnd();
        sr_DEV.Close();


#endif



        //string[] jobnames2 = {};
        
        //string[] jobnames2 = { "uREC_Trunk_UT_Build", "uREC_Trunk_DCMPS_Lib_Build", "uREC_Trunk_Lint", "uREC_Trunk_Klocwork",
        //                     "uREC_FB1305_MAC_Lint",
        //                     "uREC_Trunk_OneSCT_Regression_Test_unstable_new",
        //                     "uREC_Trunk_OneSCT_Regression_Test",
        //                     "uREC_FB1305_DCMPS_Lib_Build",
        //                     "uREC_FB1311_MAC_Lint",
        //                     "uREC_FB1311_Klocwork",
        //                     "uREC_FB1311_DCMPS_Lib_Build",
        //                     "uREC_FB1311_UT_Build"};

        string[] jobs_oneSCT_test = 
        { 
            "uREC_Trunk_OneSCT_Regression_Test",
            "uREC_Trunk_OneSCT_Regression_Test_unstable_new",
            "uREC_FB1305_OneSCT_Regression_Test_new",
            "uREC_FB1311_OneSCT_Regression_Test",
            "uREC_FB1311_OneSCT_Regression_Test_unstable_new",
            "Trunk_oneSCT_Unstable_Test",
            "Trunk_oneSCT_Regression_Test",
            "FB1305_oneSCT_Regression_Test",
            "FB1305_oneSCT_Unstable_Test",
            "FB1311_oneSCT_Regression_Test",
            "FB1311_oneSCT_Unstable_Test",
            "CA_Regression_Test",
            "CA_Regression_Test_Unstable",
        };

        int nPageControls = this.Page.Controls.Count;

        //用页面中搜索到的panel 控件来获得所有jobname的List
        List<string> jobnames2 = new List<string>();
        for (int i = 0; i < nPageControls; i++)
        {
            foreach (System.Web.UI.Control control in this.Page.Controls[i].Controls)
            {
                if (control.GetType() == typeof(Panel))
                {
                    jobnames2.Add(control.ID);
                    Panel Panel = (Panel)control;
                    Panel.Height = Unit.Percentage(100);
                    
                    //Debug_Label.Text += control.ID+" \r\n";
                }
            }
        }


        foreach (string jobname2 in jobnames2)
        {

            //this url is used for 
            string joburl_uREC = @"https://beling19.china.nsn-net.net:8080/view/uREC/job/";
            string joburl_Macro = @"http://kampi.emea.nsn-net.net:2020//job/";
            string joburl_trunk_ECL = @"http://kampi.emea.nsn-net.net:2020/view/Adaptation/view/trunk_ECL/";
            string joburl_Dev = @"https://beling19.china.nsn-net.net:8080/view/DEV/job/";

            if(jobname2.Contains("CA") == true)
                Get_Job_status(dev_html, jobs_oneSCT_test, jobname2, joburl_Dev);
            else if(jobname2.Contains("Dev_trunk_ECL") == true)
                Get_Job_status(trunk_ECL_html, jobs_oneSCT_test, jobname2, joburl_trunk_ECL);
            else if(jobname2.Contains("uREC") == true)
                Get_Job_status(html, jobs_oneSCT_test, jobname2, joburl_uREC);
            else
                Get_Job_status(kampihtml, jobs_oneSCT_test, jobname2, joburl_Macro);
            
        }
        //jobname= "uREC_Trunk_Klocwork";
        //jobfullname = jobname + jobnamesuffix;

        //if (html.Contains(jobfullname) == true)
        //{
        //    jobstatus = html.Substring(html.IndexOf(jobfullname) + jobfullname.Length, 1);

        //    // Find control on page.
        //    Control myControl = FindControl(jobname);
        //    Label Lablename = (Label)myControl;
        //    Lablename.Text = jobstatus;
        //}
        

        
    }

    private void Get_Job_status(string html, string[] jobs_oneSCT_test, string jobname2, string joburl_uREC)
    {
        string jobstatus = "Default";
        string robotstatus = "Not found";
        Boolean isRobotJob = false;


        string jobfullname = "jobdefaultname";
        string jobnamesuffix = "\"><td data=\"";
        jobfullname = jobname2 + jobnamesuffix;

        jobstatus = html.Substring(html.IndexOf(jobfullname) + jobfullname.Length, 1);

        // Find control on page.
        Control myControl = FindControl(jobname2);
        Control myControl_Label = FindControl(jobname2 + "_Label");
        Control myControl_HyperLink = FindControl(jobname2 + "_HyperLink");

        if (myControl.GetType() == typeof(Panel))
        {
            Panel myPanel = (Panel)myControl;
            Label myLabel = (Label)myControl_Label;
            HyperLink myHyperLink = (HyperLink)myControl_HyperLink;


            //如果这个job是一个regression job
            if (jobs_oneSCT_test.Contains(jobname2))
            {
                isRobotJob = true;
                robotstatus = html.Substring(html.IndexOf(jobfullname), 2000);
                MatchCollection mc = Regex.Matches(robotstatus, "\\d{1,3} / \\d{1,3} passed");


                //设置字符串为robot结果
                if (myLabel != null)
                {
                    myLabel.Text = mc[0].Value;
                }
                if (myHyperLink != null)
                {
                    myHyperLink.Text = mc[0].Value;
                    myHyperLink.NavigateUrl = joburl_uREC + jobname2;
                }
            }
            else //如果这个job不是一个regression job。
            {   //设置字符串为job结果
                if (myHyperLink != null)
                {
                    myHyperLink.Text = jobstatus;
                    //myHyperLink.NavigateUrl = joburl_uREC + jobname2;
                    
                }
                if (myLabel != null)
                    myLabel.Text = jobstatus;
            }

            if (jobstatus == "4" || jobstatus == "5") //green, Success , green, in progress
            {
                myPanel.BackColor = System.Drawing.Color.Green;

                if (isRobotJob == true)
                    myPanel.ForeColor = System.Drawing.Color.Yellow;
                else
                    myPanel.ForeColor = System.Drawing.Color.Green;
                //Imagename.BackColor = System.Drawing.Color.Green;

            }
            if (jobstatus == "2" || jobstatus == "3") //yellow, unstable
            {

                myPanel.BackColor = System.Drawing.Color.Yellow;
                if (isRobotJob == true)
                    myPanel.ForeColor = System.Drawing.Color.Green;
                else
                    myPanel.ForeColor = System.Drawing.Color.Yellow;
            }
            if (jobstatus == "0" ) //red, failed
            {

                myPanel.BackColor = System.Drawing.Color.Red;
                if (isRobotJob == true)
                    myPanel.ForeColor = System.Drawing.Color.Green;
                else
                    myPanel.ForeColor = System.Drawing.Color.Red;

                //if failed, add job link.
                myHyperLink.Text = "Failed";
                myHyperLink.NavigateUrl = joburl_uREC + jobname2;

            }
            //if (jobstatus == "3") //yellow_anime, running
            //{
            //    myPanel.BackColor = System.Drawing.Color.Yellow;
            //    myPanel.ForeColor = System.Drawing.Color.Yellow;
            //}

        }
    }

    private string DownloadWebpage(string url)
    {
        string URL = url;

        AutoResetEvent resultEvent = new AutoResetEvent(false);
        string result = null;

        //bool visible = this.Checkbox1.Checked;
        bool visible = true;

        IEBrowser browser = new IEBrowser(visible, URL, resultEvent);

        // wait for the third thread getting result and setting result event
        EventWaitHandle.WaitAll(new AutoResetEvent[] { resultEvent });
        // the result is ready later than the result event setting sometimes 
        while (browser == null || browser.HtmlResult == null) Thread.Sleep(5);

        result = browser.HtmlResult;

        return result;

        //if (!visible) browser.Dispose();

        ////把获取的html内容通过label显示出来
        //Label2.Text = result;

        ////保存结果到本程序的目录中
        //string path = Request.PhysicalApplicationPath;
        //TextWriter tw = new StreamWriter(path + @"softlab/result.html");
        //tw.Write(result);
        //tw.Close();

        ////open a new web page to display result got from webbrowser.
        //Response.Output.WriteLine("<script>window.open ('result.html','mywindow','location=1,status=0,scrollbars=1,resizable=1,width=600,height=600');</script>");
    }
}