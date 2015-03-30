namespace JsonInDotNetAllTasks
{
    using Newtonsoft.Json;

    public class Item
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, Link: {1}, Category: {2}", this.Title, this.Link, this.Category);
        }
    }
}