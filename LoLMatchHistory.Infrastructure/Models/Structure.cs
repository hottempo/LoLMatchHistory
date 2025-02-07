using System.ComponentModel.DataAnnotations;

namespace LoLMatchHistory.Infrastructure.Models;
public class Structure
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    public string GameHash { get; set; }
    [StringLength(255)]
    public string Team { get; set; }
    public long? Time { get; set; }
    [StringLength(255)]
    public string? Lane { get; set; }
    [StringLength(255)]
    public string? Type { get; set; }

}
