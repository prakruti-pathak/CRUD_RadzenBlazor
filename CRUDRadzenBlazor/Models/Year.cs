using System.ComponentModel.DataAnnotations;

namespace CRUDRadzenBlazor.Models
{
    public class Year
    {
        [Key]
        public int YearId { get; set; }
        public string YearName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
