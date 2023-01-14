using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnigpusCrud_EfCore.Entities;

[Table(name:"magazine")]
public class Magazine
{
    [Key]
    [Column(name:"id", TypeName = "NVarchar (12)")]
    public string Id { get; set; }
    
    [Required]
    [Column(name:"title", TypeName = "NVarchar (50)")]
    public string Title { get; set; }
    
    [Column(name:"publish_period")]
    public string PublishPeriod { get; set; }
    
    [Column(name:"year_period")]
    public int YearPeriod { get; set; }
}