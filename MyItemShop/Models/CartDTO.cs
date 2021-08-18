using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class CartDTO 
    {

        public virtual int UserID { get; set; }
        public virtual List<CartItem> CartItems { get; set; }

        public CartDTO()
        {

        }

        public CartDTO(Cart cart)
        {
            UserID = cart.UserID;
            CartItems = cart.CartItems;
        }
    }
}
