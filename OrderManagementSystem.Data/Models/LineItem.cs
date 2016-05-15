using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public string Name { get; set; }
        public virtual Product Product { get; set; }

    }
}
