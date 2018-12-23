using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tiers__DATA_
{
    class Web
    {
        public static void SaveString(string url, string path)
        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;
            try
            {
                Uri uri = new Uri(url);
                var str = wb.DownloadString(uri);
                File.AppendAllText(path, str, Encoding.UTF8);
            }
            catch (WebException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }

        public static string ReadString(string url)
        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;
            var str = "";
            try
            {
                Uri uri = new Uri(url);
                str = wb.DownloadString(uri);
            }
            catch (WebException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
            return str;
        }

        public static void DownloadFile(string url, string path)
        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;
            var str = "";
            try
            {
                Uri uri = new Uri(url);
                wb.DownloadFile(uri, path);
            }
            catch (WebException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
