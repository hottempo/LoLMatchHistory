namespace LoLMatchHistory.API.Models;

public class StructureDto
{
    public required string GameHash { get; set; }
    public required string Team { get; set; }
    public required long Time { get; set; }
    public required string Lane { get; set; }
    public required string Type { get; set; }
}
