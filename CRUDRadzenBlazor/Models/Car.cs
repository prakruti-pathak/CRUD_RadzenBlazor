using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDRadzenBlazor.Models
{
    public class Car
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Make is required.")]
        [MaxLength(50)]
        
        public string Make { get; set; }
        [Required(ErrorMessage = "Model is required.")]
        [MaxLength(50)]
        public string Model { get; set; }
        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2025, ErrorMessage = "Year must be between 1900 and 2025.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Engine is required.")]
        [MaxLength(50)]
        public string Engine { get; set; }
        [Required(ErrorMessage = "Color is required.")]
        [MaxLength(50)]
        public string Color { get; set; }
    }
}
