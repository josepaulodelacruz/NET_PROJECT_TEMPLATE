using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TestProjectRazor.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string Email { get; set; } 
        [Required]
        public string Name { get; set; }
    }
}
