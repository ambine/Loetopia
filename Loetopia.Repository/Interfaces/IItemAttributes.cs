using System.Collections.Generic;
using System.Threading.Tasks;
using Loetopia.DataAccess;
using Loetopia.DataAccess.Models;

namespace Loetopia.Repository
{
    public interface IItemAttributes
    {
        Task<bool> AddItemAttribute(ItemAttribute itemAttribute);
        List<ItemsAttributes> GetItemsAttributes(int? id);
    }
}