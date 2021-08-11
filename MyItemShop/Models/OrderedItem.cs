using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class OrderedItem
    {

        public virtual int ItemID { get; set; }
        public virtual string DateOfPurchase { get; set; }
        public virtual int Quantity { get; set; }
    }
}
