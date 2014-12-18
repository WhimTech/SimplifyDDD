using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace SimplifyDDD.Extension
{
    public class Utility
    {
        public static Dictionary<string, int> GetEnumDictionary<TEnum>()
        {
            var dic = new Dictionary<string, int>();
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {
                dic.Add(item.ToString(), (int)item);
            }
            return dic;
        }

        public static TResult GetApiResult<TResult>(string url, object param)
        {
            var requestJson = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            var response = client.PostAsync(url, httpContent).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TResult>(responseStr);
        }

        public static TResult GetApiResult<TResult>(string url, object param, string proxy)
        {
            var requestJson = JsonConvert.SerializeObject(param);
            var httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClientHandler = new HttpClientHandler()
            {
                Proxy = new WebProxy(proxy),
                UseProxy = true
            };
            var client = new HttpClient(httpClientHandler);
            var response = client.PostAsync(url, httpContent).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TResult>(responseStr);
        }


        private static MD5CryptoServiceProvider _md5;
        private static MD5CryptoServiceProvider Md5
        {
            get
            {
                if (_md5 == null)
                {
                    _md5 = new MD5CryptoServiceProvider();
                }
                return _md5;
            }
        }

        public static String Encrypt(string crypto)
        {
            return Convert.ToBase64String(Md5.ComputeHash(Encoding.UTF8.GetBytes(crypto)));
        }

        public static string MakeHash(string value)
        {
            return Convert.ToBase64String(Md5.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}