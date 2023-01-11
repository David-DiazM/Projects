using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpaceSystemWebModels
{
    public class Star
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sale ID")]
        [Required(ErrorMessage = "Sale ID is required")]
        public int BoughtId { get; set; }

        [Display(Name = "Star Name")]
        [Required(ErrorMessage = "Star Name is required")]
        public string Name { get; set; }

        [Display(Name = "Star Temperature")]
        [Required(ErrorMessage = "Star Temperature is required")]
        [Range(300, int.MaxValue, ErrorMessage ="The field {0} must be greater than {1}K")]
        public int Temperature { get; set; }

        [Display(Name = "Star Brightness")]
        [Required(ErrorMessage = "Star Brightness is required")]
        [Column(TypeName = "decimal(6, 2)")]
        public double Brightness { get; set; }

        [Required(ErrorMessage = "The Customer ID is required in order to map the contact to a user correctly")]
        public int CustomerId { get; set; }
    }
}
