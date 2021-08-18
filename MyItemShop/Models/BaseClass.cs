using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public abstract class BaseClass
    {
        public BaseClass()
        {

        }

        public BaseClass(BaseDTO baseDTO)
        {
            ID = baseDTO.ID;
        }
        
        [Key]
        public virtual int ID { get; set; }
 
    }
}
