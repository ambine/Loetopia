using Loetopia.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loetopia.Repository
{
    public class Attributes : IAttributes
    {
        public List<DataAccess.Attribute> GetAttributes(int? id)
        {
            using (var db = new LoetopiaContext())
            {
                return db.Attributes
                    .Where(x => id == null || x.AttributeId == id)
                    .ToList();

            }
        }

        public async Task<bool> AddAttribute(DataAccess.Attribute attribute)
        {
            using (var db = new LoetopiaContext())
            {
                db.Attributes.Add(attribute);
                if (await db.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
        }
    }
}
