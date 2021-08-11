using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop.Models
{
    public class UserDTO
    {
        
        public virtual int UserID { get; set; }

        
        public virtual string FirstName { get; set; }

        
        public virtual string LastName { get; set; }

       
        public virtual DateTime DateOfBirth { get; set; }

        
        public virtual string Email { get; set; }

        public virtual string Password { get; set; }


        public virtual int UserType { get; set; }

        public UserDTO(User user) 
        {
            UserID = user.UserID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateOfBirth = user.DateOfBirth;
            Email = user.Email;
            Password = user.Password;
            UserType = user.UserType;
        }

        public UserDTO()
        {

        }
        
    }
}
