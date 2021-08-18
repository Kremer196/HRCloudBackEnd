using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class CategoryDTO : BaseDTO
    {
      
    //    public virtual int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public CategoryDTO(Category category)
        {
            ID = category.ID;
            CategoryName = category.CategoryName;
        }
    }
}
