using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class ItemDTO : BaseDTO
    {

        
      //  public virtual int ItemID { get; set; }

        public string ItemName { get; set; }

        public int CategoryID { get; set; }

       

        public int ItemPrice { get; set; }

        public string ItemImageURL { get; set; }


        public ItemDTO(Item item)
        {
            ID = item.ID;
            ItemName = item.ItemName;
            CategoryID = item.CategoryID;
            ItemPrice = item.ItemPrice;
            ItemImageURL = item.ItemImageURL;

        }
      

        public ItemDTO()
        {

        }
    }
}
