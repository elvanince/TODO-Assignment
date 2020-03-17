using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODOFrontEnd.Models;

namespace TODOFrontEnd.Data
{
    public class TODOItemManager
    {

		IRestService restService;

		public TODOItemManager(IRestService service)
		{
			restService = service;
		}

		public Task<List<TODOItem>> GetTasksAsync()
		{
			return restService.RefreshDataAsync();
		}

		public Task SaveTaskAsync(TODOItem item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync(item, isNewItem);
		}

		public Task DeleteTaskAsync(TODOItem item)
		{
			return restService.DeleteTodoItemAsync(item.ID);
		}
	}
}
