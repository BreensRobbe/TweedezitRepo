using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace iothubtrigger.Models
{
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "messageText")]
        public string MessageText { get; set; }
    }
}
