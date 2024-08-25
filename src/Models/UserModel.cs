using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Models
{
    public class UserModel
    {


        public UserModel()
        {

        }

        public UserModel(string firstName, string lastName, string sex, int age, string state, string email, string userName, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Sex = sex;
            this.Age = age;
            this.State = state;
            this.Email = email;
            this.UserName = userName;
            this.Password = password;
        }

        public int Id { get; set; }
        
        [DisplayName("First Name")]
        [Required]
        public string FirstName {  get; set; }
        
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        
        [DisplayName("Sex")]
        [Required]
        public string Sex { get; set; }
        
        [DisplayName("Age")]
        [Required]
        [Range(1, 130)]
        public int Age { get; set; }
        
        [DisplayName("State")]
        [Required]
        [StringLength(13, MinimumLength = 4)]
        public string State { get; set; }
        
        [DisplayName("Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }
        
        [DisplayName("Username")]
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string UserName { get; set; }
        
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
