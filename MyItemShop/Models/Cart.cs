using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class Cart : BaseClass
    {
       
        public virtual User User { get; set; }

        public virtual int ItemID { get; set; }
        public virtual Item Item { get; set; }

        public virtual int Quantity { get; set; }

        public Cart()
        {

        }

        public Cart(CartDTO cartDTO) 
        {
            ID = cartDTO.ID;
            ItemID = cartDTO.ItemID;
            Quantity = cartDTO.Quantity;
        }
    }
}
