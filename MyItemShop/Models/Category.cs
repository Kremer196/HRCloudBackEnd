using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyItemShop.Models
{
    [Table("Categories")]
    public class Category : BaseClass
    {
     
      
      //  public virtual int CategoryID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public virtual string CategoryName { get; set; }

        public Category()
        {

        }

        public Category(CategoryDTO categoryDTO)
        {
            ID = categoryDTO.ID;
            CategoryName = categoryDTO.CategoryName;

        }

    }
}
