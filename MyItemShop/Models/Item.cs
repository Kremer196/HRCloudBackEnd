using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyItemShop.Models
{

    [Table("Items")]
    public class Item : BaseClass
    {
       
      //  public virtual int ItemID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public virtual string ItemName { get; set; }

        [ForeignKey("Category")]
        public virtual int CategoryID { get; set; }
        public Category Category { get; set; }

       
        public virtual int ItemPrice { get; set; }

        [Column(TypeName = "varchar(150)")]
        public virtual string ItemImageURL{ get; set; }



        public Item()
        {

        }

        public Item(ItemDTO itemDTO)
        {
            ID = itemDTO.ID;
            ItemName = itemDTO.ItemName;
            CategoryID = itemDTO.CategoryID;
            ItemPrice = itemDTO.ItemPrice;
            ItemImageURL = itemDTO.ItemImageURL;
        }


    }
}
