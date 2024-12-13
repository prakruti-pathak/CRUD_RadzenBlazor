using System.ComponentModel.DataAnnotations;

namespace CRUDRadzenBlazor.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
