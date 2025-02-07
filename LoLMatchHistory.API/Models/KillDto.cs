namespace LoLMatchHistory.API.Models;

public class KillDto
{
    public required string GameHash { get; set; }
    public required string Team { get; set; }
    public required long Time { get; set; }
    public required string Victim { get; set; }
    public required string Killer { get; set; }
    public required string Assist_1 { get; set; }
    public required string Assist_2 { get; set; }
    public required string Assist_3 { get; set; }
    public required string Assist_4 { get; set; }
    public required string Xpos { get; set; }
    public required string Ypos { get; set; }
}
