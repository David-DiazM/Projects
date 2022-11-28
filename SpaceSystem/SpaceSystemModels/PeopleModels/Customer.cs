using SpaceSystemModels.SpaceBodyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSystemModels.PeopleModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        public string Username { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        public virtual List<Planet> Planets { get; set; } = new List<Planet>();
        public virtual List<Star> Stars { get; set; } = new List<Star>();
    }
}
