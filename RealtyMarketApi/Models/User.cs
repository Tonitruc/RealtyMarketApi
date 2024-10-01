using RealtyMarketApi.Repository;
using System.ComponentModel.DataAnnotations;

namespace RealtyMarketApi.Models
{
    public class User : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Number { get; set; }

        [Required]
        public string Email { get; set; } 


        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
