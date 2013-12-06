using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NamespaceWeb;
using System.Text;

public partial class softlab_jenkins_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = "http://beling19.china.nsn-net.net:8090/view/uREC";
        //string url = "http://resource.stockstar.com/DataCenter/PrivateData/GetInvestRankSummary.aspx";
        string html = Web.Get(url, Encoding.Default, true);
        Utils.SaveTxt("d:\\" + "jenkins.htm", html, false);

        //string jobname = "uREC_Trunk_Lint\"><td data=\"";
        string jobname = "uREC_Trunk_Lint";
        string jobstatus = "Default";
        //Trunk_Lint.Text = html;
        if (html.Contains(jobname) == true)
        {
            jobstatus = html.Substring(html.IndexOf("uREC_Trunk_Lint\"><td data=\"") + jobname.Length, 1);
        }
        Trunk_Lint.Text = jobstatus;

        
    }
}