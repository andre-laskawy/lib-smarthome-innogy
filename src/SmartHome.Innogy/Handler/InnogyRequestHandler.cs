///-----------------------------------------------------------------
///   File:         InnogyRequestHandler.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 19:15:10
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Handler
{
    using Newtonsoft.Json;
    using SmartHome.Innogy.Enums;
    using SmartHome.Innogy.Models;
    using SmartHome.Innogy.Models.Base;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="InnogyRequestHandler" />
    /// </summary>
    internal class InnogyRequestHandler
    {
        /// <summary>
        /// Defines the req
        /// </summary>
        private HttpWebRequest req;

        /// <summary>
        /// Defines the res
        /// </summary>
        private WebResponse res;

        /// <summary>
        /// Defines the token
        /// </summary>
        private string token;

        /// <summary>
        /// Defines the confList
        /// </summary>
        private readonly Dictionary<RequestTyp, UriType> confList = new Dictionary<RequestTyp, UriType>();

        /// <summary>
        /// Defines the reqStream
        /// </summary>
        private Stream reqStream;

        /// <summary>
        /// Defines the reader
        /// </summary>
        private StreamReader reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="InnogyRequestHandler"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public InnogyRequestHandler(string accessToken)
        {
            string rootURI = null;
            this.token = accessToken;

            rootURI = "https://api.services-smarthome.de/api/1.0/";
            confList.Add(RequestTyp.Initialize, new UriType(rootURI + "initialize/", typeof(CurrentConf)));
            confList.Add(RequestTyp.Device, new UriType(rootURI + "device/", typeof(List<Device>)));
            confList.Add(RequestTyp.Location, new UriType(rootURI + "location/", typeof(List<Location>)));
            confList.Add(RequestTyp.LocationTypes, new UriType(rootURI + "clientstorage/LocationTypes4.0/", typeof(List<LocationTypes>)));
            confList.Add(RequestTyp.Capability, new UriType(rootURI + "capability/", typeof(List<Capability>)));
            confList.Add(RequestTyp.Action, new UriType(rootURI + "action/", typeof(ActionResponse)));
            confList.Add(RequestTyp.DeviceState, new UriType(rootURI + "device/states/", typeof(List<DeviceState>)));
            confList.Add(RequestTyp.CapabilityState, new UriType(rootURI + "capability/states/", typeof(List<DeviceState>)));
            confList.Add(RequestTyp.Interaction, new UriType(rootURI + "interaction/", typeof(List<Interaction>)));
            confList.Add(RequestTyp.Uninitialize, new UriType(rootURI + "uninitialize/", typeof(object)));
            confList.Add(RequestTyp.Message, new UriType(rootURI + "message/", typeof(List<Message>)));

            confList.Add(RequestTyp.User, new UriType("https://api.services-smarthome.de/ACCOUNT/1.0/user/", typeof(User)));
            confList.Add(RequestTyp.DeviceActivity, new UriType("https://data.services-smarthome.de/data/1.0/device/", typeof(DeviceActivity)));
        }

        /// <summary>
        /// Performs the specified req typ.
        /// </summary>
        /// <param name="reqTyp">The req typ.</param>
        /// <returns></returns>
        public object Perform(RequestTyp reqTyp)
        {
            return DoRequest(reqTyp, null, null);
        }

        /// <summary>
        /// Performs the specified req typ.
        /// </summary>
        /// <param name="reqTyp">The req typ.</param>
        /// <param name="postObj">The post object.</param>
        /// <returns></returns>
        public object Perform(RequestTyp reqTyp, InAction postObj)
        {
            return DoRequest(reqTyp, postObj, null);
        }

        /// <summary>
        /// Performs the specified req typ.
        /// </summary>
        /// <param name="reqTyp">The req typ.</param>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public object Perform(RequestTyp reqTyp, string query)
        {
            return DoRequest(reqTyp, null, query);
        }

        /// <summary>
        /// Does the request.
        /// </summary>
        /// <param name="reqTyp">The req typ.</param>
        /// <param name="postObj">The post object.</param>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        private object DoRequest(RequestTyp reqTyp, object postObj, string query)
        {
            object result = null;

            req = WebRequest.CreateHttp(confList[reqTyp].Uri + query);
            req.Headers.Add("Authorization", "Bearer " + token);
            req.ContentType = "application/json";
            req.AllowAutoRedirect = false;

            if (postObj == null)
            {
                req.Method = "GET";
            }
            else
            {
                req.Method = "POST";
            }

            try
            {
                AddPostDataToRequest(postObj);
                res = req.GetResponse();

                using (StreamReader reader = new StreamReader(this.res.GetResponseStream()))
                {
                    result = JsonConvert.DeserializeObject(reader.ReadToEnd(), confList[reqTyp].Type);
                }

                return result;
            }
            catch (WebException ex)
            {
                HandleError(ex);
                return null;

            }
        }

        /// <summary>
        /// Adds the post data to request.
        /// </summary>
        /// <param name="postObj">The post object.</param>
        private void AddPostDataToRequest(object postObj)
        {
            string postDataJson = null;
            byte[] postDataBin = null;

            if (postObj == null)
                return;

            postDataJson = JsonConvert.SerializeObject(postObj);

            postDataBin = Encoding.UTF8.GetBytes(postDataJson);

            req.ContentLength = postDataBin.Length;

            using (reqStream = req.GetRequestStream())
            {
                reqStream.Write(postDataBin, 0, postDataBin.Length);
            }
        }

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="wex">The wex.</param>
        private void HandleError(WebException wex)
        {
            InnogyError reqError = default(InnogyError);

            using (reader = new StreamReader(wex.Response.GetResponseStream()))
            {
                reqError = JsonConvert.DeserializeObject<InnogyError>(reader.ReadToEnd());
            }

            throw new System.Exception(reqError.Description);
        }
    }
}
