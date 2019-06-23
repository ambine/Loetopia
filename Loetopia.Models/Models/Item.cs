using System;
using System.Collections.Generic;

namespace Loetopia.DataAccess
{
    public partial class Item
    {
        public Item()
        {
            ItemAttributes = new HashSet<ItemAttribute>();
            ItemImages = new HashSet<ItemImage>();
        }

        public int ItemId { get; set; }
        public int? ItemTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? RequiredLevel { get; set; }
        public int? Durability { get; set; }
        public bool? Active { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<ItemAttribute> ItemAttributes { get; set; }
        public virtual ICollection<ItemImage> ItemImages { get; set; }
    }
}