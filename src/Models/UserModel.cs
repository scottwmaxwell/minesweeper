using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Models
{
    public class UserModel
    {
        public int id { get; set; }
        
        [DisplayName("First Name")]
        [Required]
        public string firstName {  get; set; }
        
        [DisplayName("Last Name")]
        [Required]
        public string lastName { get; set; }
        
        [DisplayName("Sex")]
        [Required]
        public string sex { get; set; }
        
        [DisplayName("Age")]
        [Required]
        public int age { get; set; }
        
        [DisplayName("State")]
        [Required]
        [StringLength(13, MinimumLength = 4)]
        public string state { get; set; }
        
        [DisplayName("Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email {  get; set; }
        
        [DisplayName("Username")]
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string userName { get; set; }
        
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
