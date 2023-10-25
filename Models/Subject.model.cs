using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMS.Models
{
    public class Subject
    {
        [Key, Required] public Guid Id { get; set; }
        [Required, ForeignKey("Faculty")] public Guid FId { get; set; }
    }
}
