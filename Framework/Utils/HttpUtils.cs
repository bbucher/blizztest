using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Entities;
using Framework.Entities.WoW.ItemAPI;
using Framework.Parsers;

namespace HttpUtils
{
    public class HttpClient
    {
        JsonParser parser;
        private const string US_HOST = "us.battle.net";
        private string itemEndpointSegment = @"/api/wow/item/";
        private string itemSetEndpointSegment = @"/api/wow/item/set/";
        public string ContentType { get; set; }
        
        public HttpClient()
        {
            parser = new JsonParser();
            ContentType = "text/xml";
        }

        public ItemSet GetItemSet(string itemSetId)
        {
            return parser.GetItemSet(this.MakeRequest(US_HOST + itemSetEndpointSegment + itemSetId));
        }
        public Item GetItem(string itemId)
        {
            return parser.GetItem(this.MakeRequest(US_HOST + itemEndpointSegment + itemId));
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
