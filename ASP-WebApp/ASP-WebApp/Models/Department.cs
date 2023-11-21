using System.ComponentModel.DataAnnotations;

namespace ASP_WebApp.Models
{
    public class Department

    {
        [Key] 
        public int Id { get; set; }
        public string Departmant { get; set; }
    }
}
