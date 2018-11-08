using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Persistence
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<ItemDto> Items { get; set; }

        public EmployeeDto()
        {
            Items = new List<ItemDto>();
        }
    }
}