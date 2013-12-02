using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace NamespaceWeb
{
    public class Utils
    {
        public static string GetRegValue(string RegexString, string RemoteStr)
        {
            string MatchVale = "";
            Regex r = new Regex(RegexString);
            Match m = r.Match(RemoteStr);
            if (m.Success)
            {
                MatchVale = m.Value;
            }

            string[] rs = RegexString.Replace(".+?", "|").Split('|');
            MatchVale = RegReplace(MatchVale, rs[0], rs[1]);
            return MatchVale;


        }
        public static string RegReplace(string RegValue, string regStart, string regEnd)
        {
            string s = RegValue;
            if (RegValue != "" && RegValue != null)
            {
                if (regStart != "" && regStart != null)
                {
                    s = s.Replace(regStart, "");
                }
                if (regEnd != "" && regEnd != null)
                {
                    s = s.Replace(regEnd, "");
                }
            }
            return s;
        }
        public static void SaveTxt(string file, string text, bool append)
        {
            StreamWriter sw = new StreamWriter(file, append, System.Text.Encoding.UTF8);
            sw.Write(text);
            sw.Close();
        }
        public static string FormatJson(string ajaxcode)
        {
            ajaxcode = ajaxcode.Replace("\r\n", "----");
            Regex reg = new Regex("----{(?<body>[^<].*?)}----");
            string jsoncode = reg.Match(ajaxcode).Groups["body"].Value;
            jsoncode = "{" + jsoncode + "}";
            return "{" + jsoncode + "}\r\n";
        }


        public static string GetTinyURL_google(string URL_long)
        {
            //几个特殊字符换成编码方式显示
            //URL_long = URL_long.Replace("%", "%25");
            //URL_long = URL_long.Replace(":", "%3A");
            //URL_long = URL_long.Replace("/", "%2F");
            //URL_long = URL_long.Replace("?", "%3F");
            //URL_long = URL_long.Replace("=", "%3D");

            //URL_long = URL_long.Replace("&", "%26");

            //debug
            //Label1.Text = URL_long;

            Encoding encoding = Encoding.GetEncoding("UTF-8");
            //Encoding encoding = Encoding.Default;

            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            //string url = "http://dwz.cn/create.php";
            string url = "https://www.googleapis.com/urlshortener/v1/url";
            HttpWebRequest request = null;
            HttpWebResponse response = null;




            // 准备请求,设置参数
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.x-auth-google-url-shortener = "true";
            //request.Headers.Add("x-auth-google-url-shortener", "true");
            //request.Headers.Add("Cookie: authed=1");
            //request.Accept = "*/*";
            //request.Referer = "http://goo.gl";
            //request.Headers.Add("Accept-Encoding: gzip, deflate");
            request.ContentType = "application/json";


            //byte[] data = encoding.GetBytes("url=" + URL_long);
            byte[] data = encoding.GetBytes("{\"longUrl\": \"" + URL_long + "\"}");
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

            MatchCollection mc = Regex.Matches(content, "http.*?(?=\")");

            //string URL_short = content.Substring(content.LastIndexOf("dwz.cn") + 8, 5);
            //URL_short = "http://dwz.cn/" + URL_short;
            string URL_short = mc[0].Value;
            return URL_short;

        }


        public static string GetTinyURL_Baidu(string URL_long)
        {
            //几个特殊字符换成编码方式显示
            URL_long = URL_long.Replace("%", "%25");
            URL_long = URL_long.Replace(":", "%3A");
            URL_long = URL_long.Replace("/", "%2F");
            URL_long = URL_long.Replace("?", "%3F");
            URL_long = URL_long.Replace("=", "%3D");

            URL_long = URL_long.Replace("&", "%26");

            //debug
            //Label1.Text = URL_long;

            Encoding encoding = Encoding.GetEncoding("UTF-8");
            //Encoding encoding = Encoding.Default;

            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            string url = "http://dwz.cn/create.php";
            HttpWebRequest request = null;
            HttpWebResponse response = null;




            // 准备请求,设置参数
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] data = encoding.GetBytes("url=" + URL_long);

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
            string URL_short = content.Substring(content.LastIndexOf("dwz.cn") + 8, 5);
            URL_short = "http://dwz.cn/" + URL_short;
            return URL_short;

        }
    }
}
