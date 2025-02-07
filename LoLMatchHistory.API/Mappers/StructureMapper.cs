using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.API.Mappers;

public static class StructureMapper
{
    public static StructureDto MapToDto(this Structure structure)
    {
        return new StructureDto()
        {
            GameHash = structure.GameHash ?? string.Empty,
            Lane = structure.Lane ?? string.Empty,
            Team = structure.Team ?? string.Empty,
            Time = structure.Time ?? 0,
            Type = structure.Type ?? string.Empty
        };
    }
}
