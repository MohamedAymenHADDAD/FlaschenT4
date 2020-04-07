using System;
using System.Collections.Generic;
using System.Text;

namespace FlaschenFi.Contracts
{
    public interface IArticleModel
    {
        string LongBrandName { get; set; }
        string ShortBrandName { get; set; }
        long Id { get; set; }
        string ImageUrl { get; set; }
        double Price { get; set; }
        double? PricePerUnit { get; }
        string PricePerUnitText { get; set; }
        string ShortDescription { get; set; }
    }
}
