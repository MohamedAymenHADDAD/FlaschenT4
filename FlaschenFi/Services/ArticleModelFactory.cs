using FlaschenFi.Contracts;
using FlaschenFi.Dtos;
using FlaschenFi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlaschenFi.Services
{
    class ArticleModelFactory : IArticleModelFactory
    {
        public IEnumerable<IArticleModel> Create(IEnumerable<Brand> brands)
        {
            return brands.SelectMany(b => b.Articles.Select(a => new ArticleModel {
                Id = a.Id,                
                Price = a.Price,
                ImageUrl = a.ImageUrl,
                ShortDescription = a.ShortDescription,
                PricePerUnitText = a.PricePerUnitText,
                LongBrandName = b.Name,
                ShortBrandName = b.BrandName
            }));
        }
    }
}
