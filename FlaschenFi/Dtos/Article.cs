using System;
namespace FlaschenFi.Dtos
{
    using Newtonsoft.Json;
    public class Article
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("unit")]
        public string QuantityUnit { get; set; }

        [JsonProperty("pricePerUnitText")]
        public string PricePerUnitText { get; set; }

        [JsonProperty("image")]
        public string ImageUrl { get; set; }
    }
}
