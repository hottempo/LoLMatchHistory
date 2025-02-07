using System.ComponentModel.DataAnnotations;

namespace LoLMatchHistory.Infrastructure.Models;
public class Kill
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    public string GameHash { get; set; }
    [StringLength(255)]
    public string Team { get; set; }
    public long? Time { get; set; }
    [StringLength(255)]
    public string? Victim { get; set; }
    [StringLength(255)]
    public string? Killer { get; set; }
    [StringLength(255)]
    public string? Assist_1 { get; set; }
    [StringLength(255)]
    public string? Assist_2 { get; set; }
    [StringLength(255)]
    public string? Assist_3 { get; set; }
    [StringLength(255)]
    public string? Assist_4 { get; set; }
    [StringLength(255)]
    public string? Xpos { get; set; }
    [StringLength(255)]
    public string? Ypos { get; set; }

}
