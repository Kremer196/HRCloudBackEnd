using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyItemShop.Models
{
    [Table("Users")]
    public class User : BaseClass
    {
        
        
       // public virtual int UserID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public virtual string FirstName { get; set; }


        [Column(TypeName = "varchar(50)")]
        public virtual string LastName { get; set; }

        [Column(TypeName = "date")]
        public virtual DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(100)")]
        public virtual string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        public virtual string Password { get; set; }


  
        public virtual int UserType { get; set; }

       public virtual List<Order> Orders { get; set; }

        public virtual List<Cart> CartItems { get; set; }

        public User(UserDTO userDTO)
        {
            ID = userDTO.ID;
            FirstName = userDTO.FirstName;
            LastName = userDTO.LastName;
            DateOfBirth = userDTO.DateOfBirth;
            Email = userDTO.Email;
            Password = userDTO.Password;
            UserType = userDTO.UserType;
            
        }  

        public User()
        {

        }
    }

   
}
