using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMS.Models
{
    public class List
    {
        [Key, Required] public Guid Id { get; set; }
        [Required, ForeignKey("Students")] public Guid SId { get; set; }
    }
}
