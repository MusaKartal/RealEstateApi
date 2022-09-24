using System.ComponentModel.DataAnnotations;
using TwitterClone.Models;

namespace SocialMedya.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username cannot be empty")]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(255)]
        public string Password { get; set; }

        public  ICollection<User> Users { get; set; }   


    }

}
