using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using FlaschenFi.Contracts;
using System.Linq;
using Xamarin.Forms.Internals;
using System.Collections.Generic;

namespace FlaschenFi.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly IList<SortMode> _allSortModes = new List<SortMode>() { SortMode.None, SortMode.PriceAscending, SortMode.PriceDescending };
        private readonly Dictionary<SortMode, string> _sortIcons = new Dictionary<SortMode, string>()
        {
            [SortMode.None] = "sort_24.png",
            [SortMode.PriceAscending] = "sort_down_24.png",
            [SortMode.PriceDescending] = "sort_up_24.png"
        };
        private readonly List<IArticleModel> _allArticles = new List<IArticleModel>();
        private ObservableCollection<IArticleModel> _articles;        
        private SortMode _currentSort = SortMode.None;        
        
        private bool _isFiltered = false;
        private string _sortIcon;

        public ObservableCollection<IArticleModel> Articles { 
            get => _articles;
            set => SetProperty(ref _articles, value);
        }        

        public string SortIcon
        {
            get => _sortIcon;
            set => SetProperty(ref _sortIcon, value);
        }

        public Command LoadBrandsCommand { get; private set; }

        public ProductsViewModel()
        {
            Title = "Articles";            
            Articles = new ObservableCollection<IArticleModel>();
            SortIcon = _sortIcons[SortMode.None];
            LoadBrandsCommand = new Command(async () => await ExecuteLoadBrandsCommand());            
        }

        async Task ExecuteLoadBrandsCommand()
        {
            IsBusy = true;            
            try
            {                
                var articles = await DataStore.GetAllAsync(true);
                _allArticles.Clear();
                _allArticles.AddRange(articles);
                RefreshCollection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void RefreshCollection()
        {
            IEnumerable<IArticleModel> data = _allArticles.AsReadOnly();
            switch (_currentSort)
            {
                case SortMode.PriceAscending:
                    data = data.OrderBy(a => a.Price);
                    break;
                case SortMode.PriceDescending:
                    data = data.OrderByDescending(a => a.Price);
                    break;
            }

            if (_isFiltered)
                data = data.Where(a => a.PricePerUnit.HasValue && a.PricePerUnit.Value < 2.0);

            Articles = new ObservableCollection<IArticleModel>(data);
        }

        public void ToggleSort()
        {
            // cycle through all sort modes
            var index = _allSortModes.IndexOf(_currentSort);
            index =  ++index == _allSortModes.Count ? 0: index;
            _currentSort = _allSortModes[index];
            SortIcon = _sortIcons[_currentSort];
            RefreshCollection();            
        }

        public void ToggleFilter()
        {
            _isFiltered = !_isFiltered;
            RefreshCollection();
        }
    }
}
