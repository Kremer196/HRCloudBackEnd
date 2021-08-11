using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class ItemDTO
    {
        public int ItemID { get; set; }

      
        public string ItemName { get; set; }

        public int CategoryID { get; set; }

       

        public int ItemPrice { get; set; }

        public string ItemImageURL { get; set; }


        public ItemDTO(int itemID, string itemName, int categoryID, int itemPrice, string itemImageURL)
        {
            ItemID = itemID;
            ItemName = itemName;
            CategoryID = categoryID;
            ItemPrice = itemPrice;
            ItemImageURL = itemImageURL;

        }
      

        public ItemDTO()
        {

        }
    }
}
