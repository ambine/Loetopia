using Loetopia.DataAccess;
using Loetopia.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loetopia.Repository
{
    public interface IItems
    {
        List<ItemDescription> GetItemInformation(int? id);
        Task<int> AddItem(Item item);
        Task<bool> UpdateItem(int id, Item item);

        Task<bool> RemoveItem(int id);
    }
}