using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class OrderDTO : BaseDTO
    {
   
        
        public virtual List<OrderedItem> OrderedItems { get; set; }


        public OrderDTO(Order order)
        {
            ID = order.ID;
            OrderedItems = order.OrderedItems ;
        }

        public OrderDTO()
        {

        }

    }
}
