using System.Collections.Generic;
using System.ComponentModel;

namespace Minesweeper.Models
{
    public class UserModel
    {
        public int id { get; set; }
        
        [DisplayName("First Name")]
        public string firstName {  get; set; }
        
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        
        [DisplayName("Sex")]
        public string sex { get; set; }
        
        [DisplayName("Age")]
        public int age { get; set; }
        
        [DisplayName("State")]
        public string state { get; set; }
        
        [DisplayName("Email")]
        public string email {  get; set; }
        
        [DisplayName("Username")]
        public string userName { get; set; }
        
        [DisplayName("Password")]
        public string password { get; set; }
    }
}
