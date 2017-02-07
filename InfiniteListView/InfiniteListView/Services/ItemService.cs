using System.Collections.Generic;
using InfiniteListView.Models;

namespace InfiniteListView.Services
{
    public class ItemService : IItemService
    {
        public List<Item> GetItems(int offset)
        {
            var response = new List<Item>();
            for (var i = offset; i < offset + 20; i++)
            {
                response.Add(new Item
                {
                    Title = $"Item number {i}",
                    Description = $"Description of item {i}"
                });
            }
            return response;
        }
    }
}
