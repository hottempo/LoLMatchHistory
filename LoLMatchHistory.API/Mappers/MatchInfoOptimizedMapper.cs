using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.API.Mappers;

public static class MatchInfoOptimizedMapper
{
    public static MatchInfoOptimizedDto MapToDto(this MatchInfoOptimizedView match)
    {
        return new MatchInfoOptimizedDto
        {
            GameHash = match.GameHash,
            League = match.League,
            Year = match.Year,
            Season = match.Season,
            MatchType = match.MatchType,
            RedKills = match.RedKills,
            BlueKills = match.BlueKills,
            Bans = []
        };
    }
}
