using System.ComponentModel.DataAnnotations;

namespace LoLMatchHistory.Infrastructure.Models;
public class Bans
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    public required string GameHash { get; set; }
    [StringLength(255)]
    public required string Team { get; set; }
    [StringLength(255)]
    public string? Ban1 { get; set; }
    [StringLength(255)]
    public string? Ban2 { get; set; }
    [StringLength(255)]
    public string? Ban3 { get; set; }
    [StringLength(255)]
    public string? Ban4 { get; set; }
    [StringLength(255)]
    public string? Ban5 { get; set; }

}
