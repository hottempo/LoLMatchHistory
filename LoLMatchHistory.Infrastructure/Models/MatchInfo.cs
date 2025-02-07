using System.ComponentModel.DataAnnotations;

namespace LoLMatchHistory.Infrastructure.Models;
public class MatchInfo
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    public string League { get; set; } = null!;
    public int Year { get; set; }
    [StringLength(255)]
    public string Season { get; set; } = null!;
    public string Type { get; set; } = null!;
    [StringLength(255)]
    public string? BlueTeamTag { get; set; }
    public int BlueResult { get; set; }
    public int RedResult { get; set; }
    [StringLength(255)]
    public string RedTeamTag { get; set; }
    public int GameLength { get; set; }
    [StringLength(255)]
    public string BlueTop { get; set; }
    [StringLength(255)]
    public string BlueTopChamp { get; set; }
    [StringLength(255)]
    public string BlueJungle { get; set; }
    [StringLength(255)]
    public string BlueJungleChamp { get; set; }
    [StringLength(255)]
    public string BlueMiddle { get; set; }
    [StringLength(255)]
    public string BlueMiddleChamp { get; set; }
    [StringLength(255)]
    public string BlueADC { get; set; }
    [StringLength(255)]
    public string BlueADCChamp { get; set; }
    [StringLength(255)]
    public string BlueSupport { get; set; }
    [StringLength(255)]
    public string BlueSupportChamp { get; set; }
    [StringLength(255)]
    public string RedTop { get; set; }
    [StringLength(255)]
    public string RedTopChamp { get; set; }
    [StringLength(255)]
    public string RedJungle { get; set; }
    [StringLength(255)]
    public string RedJungleChamp { get; set; }
    [StringLength(255)]
    public string RedMiddle { get; set; }
    [StringLength(255)]
    public string RedMiddleChamp { get; set; }
    [StringLength(255)]
    public string RedADC { get; set; }
    [StringLength(255)]
    public string RedADCChamp { get; set; }
    [StringLength(255)]
    public string RedSupport { get; set; }
    [StringLength(255)]
    public string RedSupportChamp { get; set; }
    [StringLength(255)]
    public string GameHash { get; set; }

    public List<Kill> Kills { get; set; }
    public List<Bans> Bans { get; set; }
    public List<Gold> Gold { get; set; }
    public List<Structure> Structures { get; set; }
    public List<Monster> Monsters { get; set; }

}
