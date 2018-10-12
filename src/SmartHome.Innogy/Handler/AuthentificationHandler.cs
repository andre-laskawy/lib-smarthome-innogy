///-----------------------------------------------------------------
///   File:         authentificationhandler.cs
///   Author:   	Andre Laskawy           
///   Date:         11.10.2018 20:16:05
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Handler
{
    using Newtonsoft.Json;
    using SmartHome.Innogy.Models;
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web;

    /// <summary>
    /// Defines the <see cref="AuthentificationHandler" />
    /// </summary>
    internal class AuthentificationHandler
    {
        /// <summary>
        /// The URL authentication
        /// </summary>
        private const string urlAuth = "https://api.services-smarthome.de/AUTH/Authorize/Login?lang=de-DE";

        /// <summary>
        /// The URL token
        /// </summary>
        private const string urlToken = "https://api.services-smarthome.de/AUTH/token";

        /// <summary>
        /// The URL redirect
        /// </summary>
        private const string urlRedirect = "https://home.innogy-smarthome.de/#/auth";

        /// <summary>
        /// The coockie request
        /// </summary>
        private const string coockieRequest = "https://api.services-smarthome.de/AUTH/authorize?response_type=code&client_id=35903586&redirect_uri=https%3A%2F%2Fhome.innogy-smarthome.de%2F%23%2Fauth&scope=&lang=de-DE&state=b0cd40fb-400b-42ed-89a8-d30f81f0a8d1";

        /// <summary>
        /// The token
        /// </summary>
        private TokenResponseData token;

        /// <summary>
        /// The req stream
        /// </summary>
        private Stream reqStream;

        /// <summary>
        /// The cookie req token
        /// </summary>
        private string cookieReqToken = null;

        /// <summary>
        /// Gets or sets a value indicating whether [credentials correct].
        /// </summary>
        public bool CredentialsCorrect { get; set; }

        /// <summary>
        /// Gets the Token
        /// </summary>
        public string Token
        {
            get { return this.token.Access_Token; }
        }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        public string RefreshToken
        {
            get { return this.token.Refresh_Token; }
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public void Login(string userName, string password)
        {
            string authCode = null;
            TokenRequestData tokReqD = new TokenRequestData();

            try
            {
                authCode = GetAuthCode(userName, password);
                if (string.IsNullOrEmpty(authCode))
                {
                    throw new WebException("Login denied.");
                }
            }
            catch (WebException ex)
            {
                CredentialsCorrect = false;
                return;
            }

            CredentialsCorrect = true;

            try
            {
                tokReqD.Code = authCode;
                tokReqD.Grant_Type = "authorization_code";
                tokReqD.Redirect_Uri = urlRedirect;
                this.token = GetToken(tokReqD);
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Logins the specified reference tok.
        /// </summary>
        /// <param name="refTok">The reference tok.</param>
        public void Login(string refTok)
        {
            TokenRequestData reqD = new TokenRequestData();

            try
            {
                reqD.Refresh_Token = refTok;
                reqD.Grant_Type = "refresh_token";

                this.token = GetToken(reqD);
                CredentialsCorrect = true;
            }
            catch (WebException ex)
            {
                CredentialsCorrect = false;
                return;
            }
        }

        /// <summary>
        /// Gets the authentication code.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private string GetAuthCode(string userName, string password)
        {
            HttpWebRequest req = default(HttpWebRequest);
            WebResponse res = default(HttpWebResponse);

            string postDataStr = null;
            byte[] postData = null;
            string reqToken = GetRequestVerificationToken(coockieRequest);

            postDataStr = "__RequestVerificationToken=" + reqToken
            + "&OriginalRequest.client_id=35903586"
            + "&OriginalRequest.redirect_uri=" + urlRedirect
            + "&OriginalRequest.response_type=code"
            + "&OriginalRequest.scope="
            + "&OriginalRequest.state=" + Guid.NewGuid().ToString()
            + "&ReturnUrl=/AUTH/authorize?code="
            + "&UserName=" + HttpUtility.UrlEncode(userName)
            + "&Password=" + HttpUtility.UrlEncode(password);

            postData = Encoding.UTF8.GetBytes(postDataStr);

            req = WebRequest.CreateHttp(urlAuth);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.AllowAutoRedirect = false;
            req.Timeout = 50000;

            CookieContainer container = new CookieContainer();
            var cVal = cookieReqToken.Replace("__RequestVerificationToken_L0FVVEg1=", "");
            Cookie cookie = new Cookie("__RequestVerificationToken_L0FVVEg1", cVal)
            {
                Domain = new Uri("https://www.api.services-smarthome.de/").Host
            };
            container.Add(cookie);

            req.Headers.Add("Cookie", cookieReqToken);

            using (reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);
            }

            try
            {
                req.GetResponse();
            }
            catch (WebException ex)
            {
                res = ex.Response;
            }

            //Location übergeben
            var loc = res.Headers["Location"];

            //AuthCode extrahieren und zurückgeben
            int idx = loc.IndexOf("code=");
            var code = loc.Substring(idx + 5);
            idx = code.IndexOf("&");
            code = code.Substring(0, idx);
            return code;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="reqData">The req data.</param>
        /// <returns></returns>
        private TokenResponseData GetToken(TokenRequestData reqData)
        {
            HttpWebRequest req = default(HttpWebRequest);
            WebResponse res = default(HttpWebResponse);

            TokenResponseData resData = default(TokenResponseData);
            var postDataJson = JsonConvert.SerializeObject(reqData);
            var postData = Encoding.UTF8.GetBytes(postDataJson);

            req = WebRequest.CreateHttp(urlToken);
            req.Method = "POST";
            req.Headers.Add("authorization", "Basic MzU5MDM1ODY6Tm9TZWNyZXQ=");
            req.Headers.Add("origin", "https://home.innogy-smarthome.de");
            req.Headers.Add("Referer", "https://home.innogy-smarthome.de/");
            req.Headers.Add("Accept", "*/*");
            req.Headers.Add("Accept-Language", "de,en-US;q=0.7,en;q=0.3");
            req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            req.Headers.Add("content-type", "application/json");
            req.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:62.0) Gecko/20100101 Firefox/62.0");
            req.Headers.Remove("Cache-Control");

            req.AllowAutoRedirect = false;

            using (reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);
            }

            res = req.GetResponse();

            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                resData = JsonConvert.DeserializeObject<TokenResponseData>(reader.ReadToEnd());
            }

            return resData;
        }

        /// <summary>
        /// Gets the request verification token.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string GetRequestVerificationToken(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpWebRequest request = null;
                    request = HttpWebRequest.Create(url) as HttpWebRequest;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    cookieReqToken = response.Headers[HttpResponseHeader.SetCookie].Replace("; path=/; HttpOnly", "");

                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseBody = reader.ReadToEnd();

                    if (responseBody.Contains("__RequestVerificationToken"))
                    {
                        int tokenIdx = responseBody.IndexOf("__RequestVerificationToken") + "__RequestVerificationToken".Length;
                        var sub = responseBody.Substring(tokenIdx);
                        var valIdxStart = sub.IndexOf("value=") + 7;
                        var tokenStart = sub.Substring(valIdxStart);

                        var idxTokenEnd = tokenStart.IndexOf("\"");
                        var token = tokenStart.Substring(0, idxTokenEnd);
                        return token.Replace("; path=/; HttpOnly", "");
                    }
                }
                catch (HttpRequestException ex)
                {
                }

                return null;
            }
        }
    }
}
