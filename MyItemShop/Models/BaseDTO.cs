using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public abstract class BaseDTO
    {


        public BaseDTO()
        {

        }

        public BaseDTO(BaseClass baseClass)
        {
            ID = baseClass.ID;
        }

        public virtual int ID { get; set; }
    }
}
