using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KilimoWebApp.Modules.Streams.Model;

namespace KilimoWebApp.Modules.Students.Model;

[Table("Students")]
public class StudentEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid StudentId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public int Age { get; set; }
    public string RegistrationNumber { get; set; } = null!;
    
    [ForeignKey(nameof(Streams.Model.StreamEntity))]
    public Guid StreamId { get; set; }
}