using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.API.Mappers;

public static class MonsterMapper
{
    public static MonsterDto MapToDto(this Monster monster)
    {
        return new MonsterDto()
        {
            GameHash = monster.GameHash ?? string.Empty,
            Team = monster.Team ?? string.Empty,
            Time = monster.Time,
            Type = monster.Type ?? string.Empty
        };
    }
}
