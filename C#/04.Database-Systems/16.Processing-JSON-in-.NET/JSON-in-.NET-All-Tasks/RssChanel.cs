namespace JsonInDotNetAllTasks
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    class Channel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public List<Item> Item { get; set; } 
    }
}
