using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Top.Api;
using Top.Api.Domain;
using Top.Api.Response;
using Top.Api.Request;
using System.Net;
using System.IO;
using System.Text;
using System.Windows.Forms;

//defined by own
using NamespaceWeb;

public class ItemExt : Item
{
    //private Item ItemElement;

    public ItemExt(Item ItemElement)
    {
        // TODO: Complete member initialization
        this.PicUrl =  ItemElement.PicUrl;
        this.Title = ItemElement.Title;
        this.Price = ItemElement.Price;
        this.HasShowcase = ItemElement.HasShowcase;
    }
    public string MogujieAddress { get; set; }
    public string MogujieFavNum { get; set; }
    public Int32 index { get; set; }


}
public partial class Default2 : System.Web.UI.Page
{
    private string url;
    private string appkey;
    private string appsecret;
    private string sessionKey = "";

    // Items is List of Item, got from response.
    // ItemsExt it List of ItemExt, used for adding other information in DataList.
    private List<ItemExt> ItemsExt = new List<ItemExt>();

    protected void Page_Load(object sender, EventArgs e)
    {

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
    //获取卖家信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Display(TextBox1.Text);
        /*
        ITopClient client = new DefaultTopClient(url, appkey, appsecret);//实例化ITopClient类
        UserGetRequest req = new UserGetRequest(); //实例化具体API对应的Request类
        req.Fields = "user_id,nick,created,buyer_credit,type,sex";
        req.Nick = "sandbox_c_1";
        UserGetResponse rsp = client.Execute(req);//执行API请求并将该类转换为response对象
         */

        ITopClient client = new DefaultTopClient(url, appkey, appsecret);
        UserBuyerGetRequest req = new UserBuyerGetRequest();
        req.Fields = "nick,sex";
        UserBuyerGetResponse response = client.Execute(req, sessionKey);
        Label1.Text = response.Body;

        /* 暂时关闭卖家查询，以便调试买家信息查询
            ITopClient client = new DefaultTopClient(url, appkey, appsecret);
            UserSellerGetRequest req = new UserSellerGetRequest();
            //req.Fields = "nick,sex";
            req.Fields = "user_id,nick,sex,seller_credit,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_size,auto_repost,promoted_type,status,alipay_bind,consumer_protection,avatar,liangpin,sign_food_seller_promise,has_shop,is_lightning_consignment,has_sub_stock,is_golden_seller,vip_info,magazine_subscribe,vertical_market,online_gamin";

            UserSellerGetResponse response = client.Execute(req, sessionKey);

            //Label1.Text = response.Body;
            Label3.Text = response.User.Nick;
            Label2.Text = sessionKey;

            Label1.Text = response.User.Type;
        */

    }

    //查询评价
    protected void Button2_Click(object sender, EventArgs e)
    {
        ITopClient client = new DefaultTopClient(url, appkey, appsecret);
        TraderatesGetRequest req = new TraderatesGetRequest();
        req.Fields = "tid,oid,role,nick,result,created,rated_nick,item_title,item_price,content,reply,num_iid";
        req.RateType = "get";
        req.Role = "buyer";
        req.Result = "neutral";
        req.PageNo = 1L;
        req.PageSize = 100L;
        DateTime StartdateTime = DateTime.Parse("2012-09-01 00:00:00");
        req.StartDate = StartdateTime;
        //DateTime EnddateTime = DateTime.Parse("2012-12-30 00:00:00");
        DateTime EnddateTime = DateTime.UtcNow;
        req.EndDate = EnddateTime;
        //req.Tid = 123456L;
        req.UseHasNext = false;
        //req.NumIid = 1234L;
        TraderatesGetResponse response = client.Execute(req, sessionKey);
        //response.TradeRates;
        
        pingjianum.Text = Convert.ToString(response.TotalResults);
        评价详情.Text = response.Body;
        //订单编号.Text = Convert.ToString(response.TradeRates[0].Tid);

        GetUserAddress(ref client, ref req, ref response);
    }

    //get trade detail information by trade ID(tid) which is got from Traderates result.
    private void GetUserAddress(ref ITopClient client, ref TraderatesGetRequest req, ref TraderatesGetResponse GetUserAddress_response)
    {
        ITopClient GetUserAddressclient = new DefaultTopClient(url, appkey, appsecret);
        TradeFullinfoGetRequest GetUserAddress_req = new TradeFullinfoGetRequest();
        GetUserAddress_req.Fields = "alipay_no,commission_fee,received_payment,buyer_alipay_no,receiver_name,receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,seller_flag";
        GetUserAddress_req.Tid = GetUserAddress_response.TradeRates[0].Tid;

        TradeFullinfoGetResponse response = GetUserAddressclient.Execute(GetUserAddress_req, sessionKey);
        //买家信息.Text = response.Trade.ReceiverAddress;

        NamePhone.Text = response.Trade.ReceiverName + response.Trade.ReceiverPhone + response.Trade.ReceiverMobile;
        BuyerAddress.Text = response.Trade.ReceiverState + " " + response.Trade.ReceiverCity + " " + response.Trade.ReceiverDistrict + " " + response.Trade.ReceiverAddress;
    }

    //查询出售中的宝贝
    protected void Button3_Click(object sender, EventArgs e)
    {
        //Set to empty to avoid including previous value.
        ItemsInfo.Text = string.Empty;

        ITopClient client = new DefaultTopClient(url, appkey, appsecret);
        ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
        req.Fields = "num_iid,title,price,pic_url,has_showcase";
        ItemsOnsaleGetResponse response = client.Execute(req, sessionKey);

        DataList1.DataSource = response.Items;
        DataList1.DataBind();

        
        /* print all the tital of items
        for (int i = 1; i < (response.TotalResults / 200 + 2); i++)
        {
            //int y = 1;
            req.Fields = "num_iid,title,price";
            //req.Q = "N97";
            //req.Cid = 1512L;
            //req.SellerCids = "11";
            req.PageNo = i;
            //req.HasDiscount = true;
            //req.HasShowcase = true;
            //req.OrderBy = "num:desc";
            //req.IsTaobao = true;
            //req.IsEx = true;
            req.PageSize = 200L;
            //DateTime dateTime = DateTime.Parse("2000-01-01 00:00:00");
            //req.StartModified = dateTime;
            //DateTime dateTime = DateTime.Parse("2000-01-01 00:00:00");
            //req.EndModified = dateTime;
            response = client.Execute(req, sessionKey);
            foreach (Item I in response.Items)
            {

                ItemsInfo.Text += I.Title + "<br />";
                //y++;
            }
            //DataList1.DataSource = response.Items;
            //DataList1.DataBind();
        }
         */

    }

    //蘑菇街收录查询,根据宝贝标题查找是否被收录，只能一次查一个。
    protected void Button4_Click1(object sender, EventArgs e)
    {

        WebClient MyWebClient = new WebClient();


        MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
        string webaddress = "http://www.mogujie.com/book/search/" + baobeiname.Text;

        Byte[] pageData = MyWebClient.DownloadData(webaddress); //从指定网站下载数据

        ////string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

        string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

        //string keyword = "找到1个";
        string keyword = "对不起";

        if (pageHtml.Contains(keyword) != true) //说明找到了，也就是被收录了。
        {

            mogujiereturn.Text = "http://www.mogujie.com/note/" + pageHtml.Substring(pageHtml.IndexOf(@"/note/") + 6, 7);
            FavoriteNum.Text = pageHtml.Substring(pageHtml.IndexOf("favCount") + 26, 6);
            
            
            //从新的页面得到一些数据：发布的用户名，喜欢数，发布日期
            //uploadDate.Text = "http://www.mogujie.com/note/" + pageHtml.Substring(pageHtml.IndexOf(@"/note/") + 6, 7);

            //保存在本地以便查看调试（以后会删掉）
            using (StreamWriter sw = new StreamWriter(@"D:\00_Data\00_TOP_Developer\00_Projects\WebSiteTest\App_Data\ouput.html"))//将获取的内容写入文本
            {
                sw.Write(pageHtml);
            }
         

        }
        else
        {
            mogujiereturn.Text = "您的宝贝尚未收录";
        }
    }

    //根据卖家的所有出售中的宝贝的标题在蘑菇街中搜索，如果搜到则加入到<List>ItemsExt中。
    protected void Button5_Click(object sender, EventArgs e)
    {
        ITopClient client = new DefaultTopClient(url, appkey, appsecret);
        ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
        req.Fields = "num_iid";
        ItemsOnsaleGetResponse response = client.Execute(req, sessionKey);

        // Items is List of Item, got from response.
        // ItemsExt it List of ItemExt, used for adding other information in DataList.
        

        baobeinumber.Text = Convert.ToString(response.TotalResults);

        for (int i = 1; i < (response.TotalResults / 40 + 2); i++)
        //for (int i = 1; i < 2; i++)
        {
            req.Fields = "num_iid,title,price,pic_url,has_showcase";
            req.PageNo = i;
            req.PageSize = 40L;
            ItemsOnsaleGetResponse response2 = client.Execute(req, sessionKey);


            int j = 1;
            foreach (Item ItemElement in response2.Items)
            {
                sousuojindu.Text = Convert.ToString((i - 1) * 40 + j);

                ItemExt ItemExtElement = new ItemExt(ItemElement);

                //根据宝贝标题进行搜索
                SearchInMogujie(ItemExtElement); //To get ItemExtElement.MogujieAddress and ItemExtElement.MogujieFavNum using title

                if (ItemExtElement.MogujieAddress != "您的宝贝尚未收录")
                {
                    ItemsExt.Add(ItemExtElement);
                    ItemExtElement.index = ItemsExt.IndexOf(ItemExtElement);

                    //如果发现宝贝被收录成功了，下一步是查该宝贝被收录的具体情况


            //WebBrowser web = new WebBrowser();
            //web.Navigate(ItemExtElement.MogujieAddress);
            //web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);




                    uploadDate.Text = ItemExtElement.MogujieAddress;
                    //FavoriteNum.Text = mogujienotehtml;

                    //using (StreamWriter sw = new StreamWriter(@"D:\00_Data\99_debugdata\" + ItemExtElement.Title + ".html"))//将获取的内容写入文本
                    //{
                    //    sw.Write(mogujienotehtml);
                    //}
                }
                j++;
            }
            //MogujieDataList.DataSource = ItemsExt;
            //MogujieDataList.DataBind();
        }
            MogujieDataList.DataSource = ItemsExt;
            MogujieDataList.DataBind();
            sousuojindu.Text = Convert.ToString(ItemsExt.Count); 
    }
    //get ItemExtElement.MogujieAddress and ItemExtElement.MogujieFavNum using title
    private void SearchInMogujie(ItemExt ItemExtElement)
    {
        /*
        WebClient MyWebClient = new WebClient();
        MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
        string webaddress = "http://www.mogujie.com/book/search/" + ItemExtElement.Title;

        Byte[] pageData = MyWebClient.DownloadData(webaddress); //从指定网站下载数据

        ////string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

        string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
        */

        //根据宝贝标题进行搜索
        string url = "http://www.mogujie.com/book/search/" + ItemExtElement.Title;
        string pageHtml = Web.Get(url);

        //string keyword = "找到1个";
        string keyword = "对不起";

        if (pageHtml.Contains(keyword) != true) //说明找到了，也就是被收录了。
        {

            ItemExtElement.MogujieAddress = "http://www.mogujie.com/note/" + pageHtml.Substring(pageHtml.IndexOf(@"/note/") + 6, 7);
            ItemExtElement.MogujieFavNum = pageHtml.Substring(pageHtml.IndexOf("favCount") + 26, 6);
        }
        else
        {
            ItemExtElement.MogujieAddress = "您的宝贝尚未收录";
        }
    }
    protected void Getdate_Click(object sender, EventArgs e)
    {
        Console.ReadLine();
        sousuojindu.Text = Convert.ToString(ItemsExt.Count);
        foreach(ItemExt ItemExtElement in ItemsExt)
        {
            
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            string webaddress = ItemExtElement.MogujieAddress;

            Byte[] pageData = MyWebClient.DownloadData(webaddress); //从指定网站下载数据
            
            ////string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

            string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

            //string keyword = "找到1个";
            //string keyword = "对不起";

            Console.WriteLine(pageHtml);

            using (StreamWriter sw = new StreamWriter(@"D:\00_Data\00_TOP_Developer\00_Projects\WebSiteTest\App_Data\Baobei.html"))//将获取的内容写入文本
            {
                sw.Write(pageHtml);
            }
            Console.ReadLine(); 
            //if (pageHtml.Contains(keyword) != true) //说明找到了，也就是被收录了。
            //{

            //    ItemExtElement.MogujieAddress = "http://www.mogujie.com/note/" + pageHtml.Substring(pageHtml.IndexOf(@"/note/") + 6, 7);
            //    ItemExtElement.MogujieFavNum = pageHtml.Substring(pageHtml.IndexOf("favCount") + 26, 6);

            //}
            //else
            //{
            //    ItemExtElement.MogujieAddress = "您的宝贝尚未收录";
            //}

        }

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
            File.AppendAllText(@"d:\00_Data\00_TOP_Developer\00_Projects\tempdata\ouput.htm", item.InnerText);
        }
    }
}