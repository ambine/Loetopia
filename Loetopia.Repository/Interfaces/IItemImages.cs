using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loetopia.Repository
{
    public interface IItemImages
    {
        Task<bool> AddItemImages(int id, byte[] image);
        List<byte[]> GetItemsImages(int? id);
    }
}