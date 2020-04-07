using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FlaschenFi.Contracts;
using FlaschenFi.Dtos;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FlaschenFi.Services
{
    public class FlaschenDataStore : IDataStore<IArticleModel, long>
    {
        private readonly HttpClient _client;
        private readonly Dictionary<long, IArticleModel> _brandCache;

        private IArticleModelFactory ModelsFactory => DependencyService.Resolve<IArticleModelFactory>();

        public FlaschenDataStore()
        {
            _client = new HttpClient();
            _brandCache = new Dictionary<long, IArticleModel>();
        }

        public Task<IArticleModel> GetById(long id)
        {
            if(_brandCache.TryGetValue(id, out var brand))
                return Task.FromResult(brand);
            
            return Task.FromResult<IArticleModel>(null);
        }

        public async Task<IEnumerable<IArticleModel>> GetAllAsync(bool forceRefresh = false)
        {
            if (forceRefresh || _brandCache.Count == 0) {
                // empty cache if force refresh
                _brandCache.Clear();

                var clientResponse = await _client.GetAsync("https://flapotest.blob.core.windows.net/test/ProductData.json");
                string brandsJson = await clientResponse.Content.ReadAsStringAsync();

                var brandCollection = JsonConvert.DeserializeObject<List<Brand>>(brandsJson);
                var articles = ModelsFactory.Create(brandCollection);
                foreach (var article in articles)
                    _brandCache[article.Id]= article;
            }
            

            return _brandCache.Values;
        }
    }
}
