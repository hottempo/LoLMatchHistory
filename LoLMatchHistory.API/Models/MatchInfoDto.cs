namespace LoLMatchHistory.API.Models;

public class MatchInfoDto
{
    public string League { get; set; }
    public int Year { get; set; }
    public string Season { get; set; }
    public string Type { get; set; }
    public string? BlueTeamTag { get; set; }
    public int BlueResult { get; set; }
    public int RedResult { get; set; }
    public string RedTeamTag { get; set; }
    public int GameLength { get; set; }
    public string BlueTop { get; set; }
    public string BlueTopChamp { get; set; }
    public string BlueJungle { get; set; }
    public string BlueJungleChamp { get; set; }
    public string BlueMiddle { get; set; }
    public string BlueMiddleChamp { get; set; }
    public string BlueADC { get; set; }
    public string BlueADCChamp { get; set; }
    public string BlueSupport { get; set; }
    public string BlueSupportChamp { get; set; }
    public string RedTop { get; set; }
    public string RedTopChamp { get; set; }
    public string RedJungle { get; set; }
    public string RedJungleChamp { get; set; }
    public string RedMiddle { get; set; }
    public string RedMiddleChamp { get; set; }
    public string RedADC { get; set; }
    public string RedADCChamp { get; set; }
    public string RedSupport { get; set; }
    public string RedSupportChamp { get; set; }
    public string GameHash { get; set; }

    public List<KillDto> Kills { get; set; } = [];
    public List<BansDto> Bans { get; set; } = [];
    public List<GoldDto> Gold { get; set; } = [];
    public List<StructureDto> Structures { get; set; } = [];
    public List<MonsterDto> Monsters { get; set; } = [];

}


public class MatchInfoOptimizedDto
{
    public string GameHash { get; init; }
    public int Year { get; init; }
    public string League { get; init; }
    public string Season { get; init; }
    public string MatchType { get; init; }
    public int TotalKills => RedKills + BlueKills;
    public int RedKills { get; init; }
    public int BlueKills { get; init; }
    public List<BansDto> Bans { get; init; } = [];
}