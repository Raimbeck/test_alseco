using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Cost { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}