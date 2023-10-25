using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UMS.DTOs
{
    public class Subject_
    {
        [Required, ForeignKey("Faculty")] public Guid FId { get; set; }
    }
}
