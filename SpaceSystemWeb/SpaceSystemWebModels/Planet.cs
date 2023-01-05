using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpaceSystemWebModels
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sale ID")]
        [Required(ErrorMessage = "Sale ID is required")]
        public int BoughtId { get; set; }

        [Display(Name = "Planet Name")]
        [Required(ErrorMessage = "Planet Name is required")]
        public string Name { get; set; }

        [Display(Name = "Planet's Orbit")]
        [Required(ErrorMessage = "Planet's Orbit is required")]
        public int OrbitInDays { get; set; }

        [Display(Name = "Planet's Gravitational Pull")]
        [Required(ErrorMessage = "Planet's Gravitational Pull is required")]
        [Column(TypeName = "decimal(6, 2)")]
        public double GravitationalPull { get; set; }

        [Display(Name = "Planet's Moons")]
        [Required(ErrorMessage = "Planet's Moons is required")]
        public int Moons { get; set; }

        [Required(ErrorMessage = "The Customer ID is required in order to map the contact to a user correctly")]
        public int CustomerId { get; set; }
    }
}