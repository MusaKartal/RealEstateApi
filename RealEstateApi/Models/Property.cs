﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RealEstateApi.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }    

        public double Price { get; set; }

        public bool IsTrending { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Categories { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User Users { get; set; }    


    }
}
