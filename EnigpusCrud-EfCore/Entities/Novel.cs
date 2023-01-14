using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnigpusCrud_EfCore.Entities;

[Table(name:"novel")]
public class Novel
{
    [Key]
    [Column(name:"id", TypeName = "NVarchar(12)")]
    public string Id { get; set; }
    
    [Required]
    [Column(name:"name", TypeName = "NVarchar (50)")]
    public string? Title { get; set; }
    
    [Required]
    [Column(name:"publisher")]
    public string Publisher { get; set; }
    
    [Column(name:"publish_year")]
    public int PublishYear { get; set; }
    
    [Column(name:"writer")]
    public string Writer { get; set; }
}