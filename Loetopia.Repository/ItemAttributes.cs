using Loetopia.DataAccess;
using Loetopia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loetopia.Repository
{
    public class ItemAttributes : IItemAttributes
    {
        public List<ItemsAttributes> GetItemsAttributes(int? id)
        {
            using (var db = new LoetopiaContext())
            {
                return db.ItemAttributes.Where(x => id == null || x.ItemId == id).Select(x =>
                     new ItemsAttributes { Name = x.Attribute.Name, Description = x.Attribute.Description, Value = x.Value })
                    .ToList();
            }
        }

        public async Task<bool> AddItemAttribute(ItemAttribute itemAttribute)
        {
            using (var db = new LoetopiaContext())
            {
                db.ItemAttributes.Add(itemAttribute);
                if (await db.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
        }

        public async Task<bool> UpdateItemAttribute(int id, Item item)
        {
            using (var db = new LoetopiaContext())
            {
                if (id != item.ItemId)
                {
                    return false;
                }

                db.Entry(item).State = EntityState.Modified;

                if (await db.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
        }

        public async Task<bool> RemoveItemAttribute(int id)
        {
            using (var db = new LoetopiaContext())
            {
                var entity = db.Items.Where(x => x.ItemId == id).FirstOrDefault();
                entity.Active = false;

                db.Entry(entity).State = EntityState.Modified;

                if (await db.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
        }
    }
}
