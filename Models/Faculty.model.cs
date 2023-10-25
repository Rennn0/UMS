using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Faculty
    {
        [Key, Required] public Guid Id { get; set; }
        [Required] public string faculty { get; set; } = string.Empty;
    }
}
