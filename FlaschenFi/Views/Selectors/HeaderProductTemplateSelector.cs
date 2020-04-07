using System;
using FlaschenFi.Models;
using Xamarin.Forms;

namespace FlaschenFi.Views.Selectors
{
    public class HeaderProductTemplateSelector : DataTemplateSelector
    {
        public DataTemplate headerTemplate { get; set; }

        public bool IsHeaderVisible { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return IsHeaderVisible ? headerTemplate : null;
        }
    }
}
