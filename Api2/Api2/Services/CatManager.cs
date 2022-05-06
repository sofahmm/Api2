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

        public CatManager(IrestService restService)
        {
            service = restService;
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
        /*IRestService service;

        public TodoManager(IRestService restService)
        {
            service = restService;
        }
        public Task<List<TodoItemModel>> GetTodoItemModels()
        {
            return service.GetTodoItemAsync();
        }

        public Task DeleteTodoAsync(TodoItemModel item) 
        {
            return service.DeleteTodoItemAsync(item);
        }
        public Task SaveItemAsync(TodoItemModel todoItem, bool isNewItem = false)
        {
            return service.SaveTodoItemAsync(todoItem, isNewItem);
        }*/
    }
}
