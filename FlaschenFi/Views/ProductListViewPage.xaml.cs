using System;
using FlaschenFi.Contracts;
using FlaschenFi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlaschenFi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListViewPage : ContentPage
    {
        private readonly ProductsViewModel productsViewModel = new ProductsViewModel();            
        private readonly GridItemsLayout listView = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical) {
            VerticalItemSpacing = 12, 
            HorizontalItemSpacing = 12 
        };
        private readonly GridItemsLayout gridView = new GridItemsLayout(4, ItemsLayoutOrientation.Vertical)
        {
            VerticalItemSpacing = 12,
            HorizontalItemSpacing = 12
        };

        private bool _detailedViewMode = false;

        public ProductListViewPage()
        {
            InitializeComponent();
            BindingContext = productsViewModel;                        
            productsViewModel.LoadBrandsCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ToggleViewMode(this, null);
        }

        void SortProducts(object sender, EventArgs e)
        {
            productsViewModel.ToggleSort();            
        }

        void FilterProducts(object sender, EventArgs e)
        {
            productsViewModel.ToggleFilter();
        }

        void ToggleViewMode(object sender, EventArgs e)
        {
            _detailedViewMode = !_detailedViewMode;
            viewButton.Source = _detailedViewMode ? "grid_24.png": "list_24.png";
            ProductsListView.ItemsLayout = _detailedViewMode ? listView : gridView;
            productTemplateSelectorAccessor.IsSwitchToggeled = headerTemplateSelectorAccessor.IsHeaderVisible = _detailedViewMode;
        }
}
}
