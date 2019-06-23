using System;
using System.Collections.Generic;

namespace Loetopia.DataAccess
{
    public partial class ItemImage
    {
        public int ItemImagesId { get; set; }
        public int? ItemId { get; set; }
        public byte[] Image { get; set; }

        public virtual Item Item { get; set; }
    }
}