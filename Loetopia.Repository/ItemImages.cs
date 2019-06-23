using Loetopia.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loetopia.Repository
{
    public class ItemImages : IItemImages
    {
        public List<byte[]> GetItemsImages(int? id)
        {
            using (var db = new LoetopiaContext())
            {
                return db.ItemImages.Where(x => id == null || x.ItemImagesId == id).Select(x => x.Image).ToList();
            }
        }

        public async Task<bool> AddItemImages(int id, byte[] image)
        {
            using (var db = new LoetopiaContext())
            {
                db.ItemImages.Add(new ItemImage() { ItemId = id, Image = image });
                if (await db.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
        }
    }
}
