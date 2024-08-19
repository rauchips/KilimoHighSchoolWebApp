using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KilimoWebApp.Modules.Students.Model;

namespace KilimoWebApp.Modules.Streams.Model;

public class StreamEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
}