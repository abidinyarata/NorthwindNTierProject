using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Entities
{
    public partial class NewCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
