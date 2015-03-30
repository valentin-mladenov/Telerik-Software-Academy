namespace JsonInDotNetAllTasks
{
    using Newtonsoft.Json;

    class Rss
    {
        [JsonProperty("channel")]
        public Channel Channel { get; set; }
    }
}
