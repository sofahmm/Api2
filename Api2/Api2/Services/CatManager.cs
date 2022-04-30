using Api2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api2.Services
{
    public class CatManager
    {
        IrestService service;
        private RestService restService;

        public CatManager(IrestService restService)
        {
            service = restService;
        }

        public CatManager(RestService restService)
        {
            this.restService = restService;
        }

        public Task<List<CatItemModel>> GetCatItemModels()
        {
            return service.GetCatitemAsync();
        }
        public Task DeleteCatAsync(CatItemModel item)
        {
            return service.DeleteCatItemAsync(item);
        }
        public Task SaveitemAsync(CatItemModel catItem, bool isNewitem = false)
        {
            return service.SaveCatItemAsync(catItem, isNewitem);
        }
    }
}
