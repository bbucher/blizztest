using System.Collections.Generic;
using Entities;
using Framework.Entities.WoW.ItemAPI;
using Newtonsoft.Json;

namespace Framework.Parsers
{
    public class JsonParser
    {
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
            return JsonConvert.DeserializeObject<Item>(json).Id;
        }
        public List<int> GetItemsInItemSet(string json)
        {
            var itemSet = JsonConvert.DeserializeObject<ItemSet>(json);
            return itemSet.items;
        }
    }
}
