using FlaschenFi.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FlaschenFi.Models
{
    public class ArticleModel : IArticleModel
    {
        private static readonly Regex pattern = new Regex(@"^\((?<price>\d+\,\d+)\s.\/(\w+)\)$");

        private string _pricePerUnitText;
        private double? _pricePerUnit;

        public long Id { get; set; }
        public string LongBrandName { get; set; }
        public string ShortBrandName { get; set; }
        public string PricePerUnitText
        {
            get => _pricePerUnitText;
            set => SetPricePerUnitText(value);
        }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public double? PricePerUnit => _pricePerUnit;

        private void SetPricePerUnitText(string pricePerUnitTxt)
        {
            _pricePerUnitText = pricePerUnitTxt;
            _pricePerUnit = GetPricePerUnit(pricePerUnitTxt);
        }

        private static double? GetPricePerUnit(string pricePerUnitTxt)
        {
            var match = pattern.Match(pricePerUnitTxt);
            if (match.Success)
            {
                var priceGroup = match.Groups["price"];
                if (double.TryParse(priceGroup.Value.Replace(",","."), out var price))
                    return price;
            }

            return null;
        }
    }
}
