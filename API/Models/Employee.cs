using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public ICollection<Item> Items { get; set; }

        public Employee()
        {
            Items = new Collection<Item>();
        }
    }
}