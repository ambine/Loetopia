using System;
using System.Collections.Generic;
using System.Text;

namespace Loetopia.DataAccess.Models
{
    public class ItemDescription
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string TypeDescription { get; set; }
        public int? Durability { get; set; } = 0;
        public int? RequiredLevel { get; set; } = 0;
    }
}
