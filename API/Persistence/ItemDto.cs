using System.ComponentModel.DataAnnotations;

namespace API.Persistence
{
    public class ItemDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public double Cost { get; set; }

        public int EmployeeId { get; set; }
    }
}