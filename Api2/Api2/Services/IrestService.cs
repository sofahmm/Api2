using Api2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api2.Services
{
    public interface IrestService
    {
        Task<List<CatItemModel>> GetCatitemAsync();
        Task SaveCatItemAsync(CatItemModel item, bool isNewItem);
        Task DeleteCatItemAsync(CatItemModel item);
    }
}
