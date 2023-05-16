using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SysBasicClass
{
    public  class ApiHelper
    {
        /// <summary>
        /// Post请求
        /// </summary>
        public static string Post(string url, string param = null)
        {
            byte[] bufferBytes = Encoding.UTF8.GetBytes(param ?? "");
            var request = WebRequest.Create(url) as HttpWebRequest;//HttpWebRequest方法继承自WebRequest, Create方法在WebRequest中定义，因此此处要显示的转换
            request.Method = "POST";
            request.ContentLength = bufferBytes.Length;
       
                request.ContentType = "application/json";
            try
            {
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bufferBytes, 0, bufferBytes.Length);
                }
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
            return HttpRequest(request);
        }

        /// <summary>
        /// GET请求
        /// </summary>
        public static string Get(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            return HttpRequest(request);
        }

        /// <summary>
        /// 请求的主体部分
        /// </summary>
        private static string HttpRequest(HttpWebRequest request)
        {
            HttpWebResponse response = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
    public class WebHeaderModel
    {
        public HttpRequestHeader RequestHeader { set; get; }

        public string Value { set; get; }
    }
}