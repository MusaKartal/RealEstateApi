using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
        


        public ICollection <Property> Properties { get; set; }
    }
}
