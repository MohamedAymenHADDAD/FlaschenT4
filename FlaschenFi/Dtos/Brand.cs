using System;
namespace FlaschenFi.Dtos
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Brand
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }

        [JsonProperty("descriptionText", NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionText { get; set; }
    }
}
