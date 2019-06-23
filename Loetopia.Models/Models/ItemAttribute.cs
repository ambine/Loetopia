using System;
using System.Collections.Generic;

namespace Loetopia.DataAccess
{
    public partial class ItemAttribute
    {
        public int ItemAttributeId { get; set; }
        public int? ItemId { get; set; }
        public int? AttributeId { get; set; }
        public long? Value { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Item Item { get; set; }
    }
}