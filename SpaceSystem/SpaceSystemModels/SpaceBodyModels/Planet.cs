using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSystemModels.PeopleModels;

namespace SpaceSystemModels.SpaceBodyModels
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BoughtId { get; set; }
        [Required]
        public string Name { get; set; }
        public int? OrbitInDays { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? GravitationalPull { get; set; }
        public int? Moons { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
