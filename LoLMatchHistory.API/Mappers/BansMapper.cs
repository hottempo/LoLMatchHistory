using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.API.Mappers;

public static class BansMapper
{
    public static BansDto MapToDto<T>(this T bans) where T : class
    {
        return new BansDto()
        {
            Team = (string)typeof(T).GetProperty("Team")?.GetValue(bans) ?? string.Empty,
            Ban1 = (string)typeof(T).GetProperty("Ban1")?.GetValue(bans) ?? string.Empty,
            Ban2 = (string)typeof(T).GetProperty("Ban2")?.GetValue(bans) ?? string.Empty,
            Ban3 = (string)typeof(T).GetProperty("Ban3")?.GetValue(bans) ?? string.Empty,
            Ban4 = (string)typeof(T).GetProperty("Ban4")?.GetValue(bans) ?? string.Empty,
            Ban5 = (string)typeof(T).GetProperty("Ban5")?.GetValue(bans) ?? string.Empty
        };
    }

    /*public static BansDto MapToDto(this Bans bans)
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
    }*/
}
