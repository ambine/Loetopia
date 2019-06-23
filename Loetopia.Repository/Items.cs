using Loetopia.DataAccess;
using Loetopia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loetopia.Repository
{
    public class Items : IItems
    {

        public List<ItemDescription> GetItemInformation(int? id)
        {
            using (var db = new LoetopiaContext())
            {
                return db.Items
                    .Where(x => id == null || x.ItemId == id)
                    .Select(x => 
                    new ItemDescription { ItemId = x.ItemId, Name = x.Name, Description = x.Description, Type = x.ItemType.Name, TypeDescription = x.ItemType.Description, Durability = x.Durability, RequiredLevel = x.RequiredLevel })
                    .ToList();
              
            }
        }

        public async Task<int> AddItem(Item item)
        {
            using (var db = new LoetopiaContext())
            {
                db.Items.Add(item);
                if(await db.SaveChangesAsync() > 0)
                    return item.ItemId;

                return 0;
            }
        }

        
        public async Task<bool> UpdateItem(int id, Item item)
        {
            using (var db = new LoetopiaContext())
            {
                if(id != item.ItemId)
                {
                    return false;
                }

                db.Entry(item).State = EntityState.Modified;
         
                if (await db.SaveChangesAsync() > 0)
                    return true;
               
                return false;
            }
        }

        public async Task<bool> RemoveItem(int id)
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
