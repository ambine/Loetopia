using System;
using System.Collections.Generic;

namespace Loetopia.DataAccess
{
    public partial class Attribute
    {
        public Attribute()
        {
            ItemAttributes = new HashSet<ItemAttribute>();
        }

        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ItemAttribute> ItemAttributes { get; set; }
    }
}