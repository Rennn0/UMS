using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UMS.Models
{
    public class Student
    {
        [Key, NotNull, Required] public Guid Id { get; set; }
        [NotNull, Required] public int PersonalNumber { get; set; }
        [NotNull, Required] public string Name { get; set; } = string.Empty;
        [NotNull, Required] public string LastName { get; set; } = string.Empty;

        [NotNull] public float GPI { get; set; }
    }
}
