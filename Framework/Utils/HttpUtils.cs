using System;
using System.IO;
using System.Net;
using Entities;
using Framework.Entities.WoW.ItemAPI;
using Framework.Parsers;

namespace Framework.Utils
{
    public class HttpClient
    {
        readonly JsonParser _parser;
        private const string UsHost = "us.battle.net";
        private string itemEndpointSegment = @"/api/wow/item/";
        private string itemSetEndpointSegment = @"/api/wow/item/set/";
        public string ContentType { get; set; }
        
        public HttpClient()
        {
            _parser = new JsonParser();
            ContentType = "text/xml";
        }

        public ItemSet GetItemSet(string itemSetId)
        {
            return _parser.GetItemSet(MakeRequest(UsHost + itemSetEndpointSegment + itemSetId));
        }
        public Item GetItem(string itemId)
        {
            return _parser.GetItem(MakeRequest(UsHost + itemEndpointSegment + itemId));
        }

        private string MakeRequest(string endpoint)
        {
            var request = (HttpWebRequest)WebRequest.Create(@"http://" + endpoint);

            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = ContentType;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                return responseValue;
            }
        }
    }
}
