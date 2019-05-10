using SharedFitness.Model;
using SharedFitness.Network.HttpSetters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedFitness.Network.WebServers
{
    class SFWebServer: WebServer
    {
        WebHeaderCollection Headers { get; set; } = new WebHeaderCollection();
        public static SFWebServer Main
        {
            get
            {
                if (_main == null)
                {
                    _main = new SFWebServer();
                }
                return _main;
            }
        }
        private static SFWebServer _main;
        protected override HttpRequest NewHttpRequest()
        {
            HttpRequest hr = new HttpRequest();
            hr.Uri = new Uri("http://sharedfitness.altervista.org/");
            hr.Headers = this.Headers;
            return hr;
        }

        protected override IHttpSetter NewHttpSetter()
        {
            return new CascadeUriHttpSetter();
        }

        protected override string FormatJson(string json)
        {
            return "{\"data\":" + json + "}";
        }
        public async Task<Boolean> Login(User user)
        {
            if (user.Username == null || user.Password == null)
            {
                return false;
            }
            IHttpSetter httpSetter = Setter(SFResources.Connect);
            httpSetter.SetBody(user?.ToJson());
            httpSetter.SetMethod(HttpMethod.Put);
            HttpRequestResponse hrr = await RunRequestFromSetter(httpSetter);
            if (hrr.Body == "true")
            {
                String cookieName = "PHPSESSID=";
                String s = hrr.Headers.Get("Set-Cookie");
                if(s != null)
                {
                    String sessionId = s.Substring(s.IndexOf(cookieName));
                    sessionId = sessionId.Substring(0, sessionId.IndexOf(";") + 1);

                    Headers.Add("Cookie", sessionId);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
