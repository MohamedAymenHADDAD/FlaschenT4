using FlaschenFi.Dtos;
using FlaschenFi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlaschenFi.Contracts
{
    interface IArticleModelFactory
    {
        IEnumerable<IArticleModel> Create(IEnumerable<Brand> brands);
    }
}
