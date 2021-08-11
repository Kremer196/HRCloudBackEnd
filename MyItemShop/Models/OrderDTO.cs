using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class OrderDTO
    {
        public virtual int UserID { get; set; }
        
        public virtual List<OrderedItem> OrderedItems { get; set; }


        public OrderDTO(Order order)
        {
            UserID = order.UserID;
            OrderedItems = order.OrderedItems ;
        }

        public OrderDTO()
        {

        }

    }
}
