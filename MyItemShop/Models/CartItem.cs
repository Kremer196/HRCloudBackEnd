using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class CartItem
    {

        
        public virtual int ItemID { get; set; }

        
       

        public virtual int Quantity { get; set; }
    }
    
}
