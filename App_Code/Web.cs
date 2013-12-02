using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net.Sockets;

namespace NamespaceWeb
{
    public class Web
    {
        public class UrlInfo
        {
            public string Host;
            public int Port;
            public string File;
            public string Body;

        }

        /// <summary> 
        /// 解析URL 
        /// </summary> 
        /// <param name="url"></param> 
        /// <returns></returns> 
        public static UrlInfo ParseURL(string url)
        {
            UrlInfo urlInfo = new UrlInfo();
            string[] strTemp = null;
            urlInfo.Host = "";
            urlInfo.Port = 80;
            urlInfo.File = "/";
            urlInfo.Body = "";
            int intIndex = url.ToLower().IndexOf("http://");
            if (intIndex != -1)
            {
                url = url.Substring(7);
                intIndex = url.IndexOf("/");
                if (intIndex == -1)
                {
                    urlInfo.Host = url;
                }
                else
                {
                    urlInfo.Host = url.Substring(0, intIndex);
                    url = url.Substring(intIndex);
                    intIndex = urlInfo.Host.IndexOf(":");
                    if (intIndex != -1)
                    {
                        strTemp = urlInfo.Host.Split(':');
                        urlInfo.Host = strTemp[0];
                        int.TryParse(strTemp[1], out urlInfo.Port);
                    }
                    intIndex = url.IndexOf("?");
                    if (intIndex == -1)
                    {
                        urlInfo.File = url;
                    }
                    else
                    {
                        strTemp = url.Split('?');
                        urlInfo.File = strTemp[0];
                        urlInfo.Body = strTemp[1];
                    }
                }
            }
            return urlInfo;
        }

        /// <summary> 
        /// 发出请求并获取响应 
        /// </summary> 
        /// <param name="host"></param> 
        /// <param name="port"></param> 
        /// <param name="body"></param> 
        /// <param name="encode"></param> 
        /// <returns></returns> 
        private static string GetResponse(string host, int port, string body, Encoding encode)
        {
            string strResult = string.Empty;
            //byte[] bteSend = Encoding.ASCII.GetBytes(body);
            byte[] bteSend = Encoding.UTF8.GetBytes(body);
            byte[] bteReceive = new byte[1024];
            int intLen = 0;

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    //socket.ReceiveTimeout = 1000;//防卡?
                    socket.Connect(host, port);
                    if (socket.Connected)
                    {
                        socket.Send(bteSend, bteSend.Length, 0);
                        while ((intLen = socket.Receive(bteReceive, bteReceive.Length, 0)) > 0)
                        {
                            strResult += encode.GetString(bteReceive, 0, intLen);
                        }
                    }
                    socket.Close();
                }
                catch { }
            }

            return strResult;
        }

        /// <summary> 
        /// GET请求 
        /// </summary> 
        /// <param name="url"></param> 
        /// <param name="encode"></param> 
        /// <returns></returns> 
        public static string Get(string url)
        {
            return Get(url, Encoding.UTF8, false);
        }
        public static string Get(string url, bool isKeepalive)
        {
            return Get(url, Encoding.UTF8, isKeepalive);
        }
        public static string Get(string url, Encoding encode)
        {
            UrlInfo urlInfo = ParseURL(url);
            string strRequest = string.Format("GET {0}?{1} HTTP/1.1\r\nHost:{2}:{3}\r\nConnection:Close\r\n\r\n", urlInfo.File, urlInfo.Body, urlInfo.Host, urlInfo.Port.ToString());
            return GetResponse(urlInfo.Host, urlInfo.Port, strRequest, encode);
        }
        public static string Get(string url, Encoding encode, bool isKeepalive)
        {
            UrlInfo urlInfo = ParseURL(url);
            string strRequest = "";
            if(isKeepalive == true)
            strRequest = string.Format("GET {0}?{1} HTTP/1.1\r\nHost:{2}:{3}\r\nConnection:Keep-Alive\r\n\r\n", urlInfo.File, urlInfo.Body, urlInfo.Host, urlInfo.Port.ToString());
            else strRequest = string.Format("GET {0}?{1} HTTP/1.1\r\nHost:{2}:{3}\r\nConnection:Close\r\n\r\n", urlInfo.File, urlInfo.Body, urlInfo.Host, urlInfo.Port.ToString());
            return GetResponse(urlInfo.Host, urlInfo.Port, strRequest, encode);
        }


        /// <summary> 
        /// POST请求 
        /// </summary> 
        /// <param name="url"></param> 
        /// <param name="encode"></param> 
        /// <returns></returns> 
        public static string Post(string url, Encoding encode)
        {
            UrlInfo urlInfo = ParseURL(url);
            string strRequest = string.Format("POST {0} HTTP/1.1\r\nHost:{1}:{2}\r\nContent-Length:{3}\r\nContent-Type:application/x-www-form-urlencoded\r\nConnection:Close\r\n\r\n{4}", urlInfo.File, urlInfo.Host, urlInfo.Port.ToString(), urlInfo.Body.Length, urlInfo.Body);
            return GetResponse(urlInfo.Host, urlInfo.Port, strRequest, encode);
        }

        public static string GetwholePage(string htmlurl)
        {
            string code = "";
            string sin = "";

            string html = Get(htmlurl);
            return GetPage(html, 1, false, code, sin);
        }

        static string GetPage(string html, int page, bool ajax, string code, string sin)
        {
            

            Console.WriteLine(string.Format("page {0} download OK.", page));
            if (string.IsNullOrEmpty(html))
            {
                return "fail";
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
                code = GetPage(newhtml, page + 1, true, code, sin);
            }
            return code;
        }
    }
}