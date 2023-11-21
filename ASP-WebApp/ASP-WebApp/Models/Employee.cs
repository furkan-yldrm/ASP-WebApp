using System.ComponentModel.DataAnnotations;

namespace ASP_WebApp.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
