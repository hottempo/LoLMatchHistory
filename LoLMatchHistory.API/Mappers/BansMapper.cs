using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.API.Mappers;

public static class BansMapper
{
    public static BansDto MapToDto(this Bans bans)
    {
        return new BansDto()
        {
            Team = bans.Team,
            Ban1 = bans.Ban1 ?? string.Empty,
            Ban2 = bans.Ban2 ?? string.Empty,
            Ban3 = bans.Ban3 ?? string.Empty,
            Ban4 = bans.Ban4 ?? string.Empty,
            Ban5 = bans.Ban5 ?? string.Empty
        };
    }
}
