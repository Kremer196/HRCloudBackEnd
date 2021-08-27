using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class CartDTO : BaseDTO
    {

   
        public virtual int ItemID { get; set; }

        public virtual int Quantity { get; set; }

      
        public CartDTO()
        {

        }

        public CartDTO(Cart cart)
        {
            ID = cart.ID;
            ItemID = cart.ItemID;
            Quantity = cart.Quantity;
        }
    }
}
