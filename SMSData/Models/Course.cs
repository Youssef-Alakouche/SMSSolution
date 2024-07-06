// Fields:
// CourseId (Primary Key)
// Name
// Description
// Credits

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SMSData.Models;

public class Course {
    public long CourseId {get; set;}

    [Required]
    [NotNull]
    public string? Name {get; set;}

    [Required]
    [NotNull]
    public string? Description {get; set;}
    public int Credits {get; set;}

    // Relationship
    public ICollection<Enrollment>? enrollments {get; set;}
}