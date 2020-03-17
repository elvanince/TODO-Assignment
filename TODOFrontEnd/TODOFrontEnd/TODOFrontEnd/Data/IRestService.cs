using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODOFrontEnd.Models;

namespace TODOFrontEnd.Data
{
    public interface IRestService
    {

        Task<List<TODOItem>> RefreshDataAsync();

        Task SaveTodoItemAsync(TODOItem item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}
