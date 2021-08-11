using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class Order
    {
         public virtual int UserID { get; set; }
         public virtual User User { get; set; }

        

   
        public virtual List<OrderedItem> OrderedItems { get; set; }

       
        public Order()
        {

        }

        public Order(OrderDTO orderDTO) 
        {
            UserID = orderDTO.UserID;
            OrderedItems = orderDTO.OrderedItems;
        }
    }
}
