using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class Cart : BaseClass
    {
       
        public virtual User User { get; set; }

        public virtual List<CartItem> CartItems { get; set; }

        public Cart()
        {

        }

        public Cart(CartDTO cartDTO) 
        {
            ID = cartDTO.ID;
            CartItems = cartDTO.CartItems;
        }
    }
}
