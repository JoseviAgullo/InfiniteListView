using System.Collections.Generic;
using InfiniteListView.Models;

namespace InfiniteListView.Services
{
    public interface IItemService
    {
        List<Item> GetItems(int offset);
    }
}