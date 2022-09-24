using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SocialMedya.Models;

namespace TwitterClone.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    
        [StringLength(255)]
        public string Surname { get; set; }

        [StringLength(255)]
        public string  ProfilePhoto { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDay { get; set; }

        [StringLength(255)]
        public string  About { get; set; }

        public int AccountId { get; set; }


        public Account Account { get; set; }

        public int TweetId { get; set; }

        public Tweet Tweet { get; set; }


    }
}
