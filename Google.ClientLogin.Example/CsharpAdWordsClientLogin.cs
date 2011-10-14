using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.ClientLogin.Example
{
    [TestClass]
    public class CsharpAdWordsClientLogin
    {
        [TestMethod]
        public void GetAuthToken()
        {
            string URL = "https://www.google.com/accounts/ClientLogin";
            string email = "your_account";
            string password = "your_password";
            string source = "your_application_name";

            string httpBody =
                string.Format(
                    "accountType=HOSTED_OR_GOOGLE&Email={0}&Passwd={1}&service=adwords&source={2}",
                    email, password, source);
            var request = WebRequest.Create(URL) as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(httpBody);
            }

            using (HttpWebResponse httpWebResponse = request.GetResponse() as HttpWebResponse)
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = httpWebResponse.GetResponseStream())
                    {
                        StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
                        Console.Out.WriteLine(readStream.ReadToEnd());
                    }
                }
            }
        }
    }
}