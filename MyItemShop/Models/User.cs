using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyItemShop.Models
{
    public class User
    {

        [Key]
        public int UserID { get; set; }

        [Column(TypeName="varchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Orders { get; set; }

   
        public int userType { get; set; }
        
        [Column(TypeName = "varchar(max)")]
        public string Cart { get; set; }


    }

   
}
