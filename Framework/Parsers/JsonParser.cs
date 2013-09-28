using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonUtils
{
    public class JsonParser
    {
        public JsonParser()
        {
        }

        public ItemSet GetItemSet(string json)
        {
            return JsonConvert.DeserializeObject<ItemSet>(json);
        }

        public Item GetItem(string json)
        {
            return JsonConvert.DeserializeObject<Item>(json);
        }

        public int GetItemId(string json)
        {
            return JsonConvert.DeserializeObject<Item>(json).id;
        }
        public List<int> GetItemsInItemSet(string json)
        {
            var itemSet = JsonConvert.DeserializeObject<ItemSet>(json);
            return itemSet.items;
        }
    }
}
