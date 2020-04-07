using System;
using FlaschenFi.ViewModels;
using Xamarin.Forms;

namespace FlaschenFi.Views.Selectors
{
    public class ProductTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DetailedProductTemplate { get; set; }
        public DataTemplate BaseProductTemplate { get; set; }

        public bool IsSwitchToggeled { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return IsSwitchToggeled ? DetailedProductTemplate : BaseProductTemplate ;
        }
    }
}
