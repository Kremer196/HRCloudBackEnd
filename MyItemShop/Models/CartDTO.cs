using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class CartDTO : BaseDTO
    {

   
        public virtual List<CartItem> CartItems { get; set; }

        public CartDTO()
        {

        }

        public CartDTO(Cart cart)
        {
            ID = cart.ID;
            CartItems = cart.CartItems;
        }
    }
}
