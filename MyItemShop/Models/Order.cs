using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class Order : BaseClass
    {
       
         public virtual User User { get; set; }

        

   
        public virtual List<OrderedItem> OrderedItems { get; set; }

       
        public Order()
        {

        }

        public Order(OrderDTO orderDTO) 
        {
            ID = orderDTO.ID;
            OrderedItems = orderDTO.OrderedItems;
        }
    }
}
