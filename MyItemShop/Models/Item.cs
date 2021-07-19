using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyItemShop.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ItemName { get; set; }

        public int CategoryID { get; set; }

        
        public int ItemPrice { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string ItemImageURL{ get; set; }

        
    }
}
