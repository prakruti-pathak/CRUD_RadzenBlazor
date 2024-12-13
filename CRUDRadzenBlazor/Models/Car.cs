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
       
        [Required(ErrorMessage = "Price is required.")]
        [Range(50000, 5000000, ErrorMessage = "Price must be a between 50000 and 5000000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Engine is required.")]
        [MaxLength(50)]
        public string Engine { get; set; }


        [Required(ErrorMessage = "Color is required.")]
        public int ColorId { get; set; }
        public Color Color { get; set; }
        [Required(ErrorMessage = "Year is required.")]
        public int YearId {  get; set; }
        public Year Year { get; set; }

    }
}
