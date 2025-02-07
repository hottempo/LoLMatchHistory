using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.API.Mappers;

public static class KillMapper
{
    public static KillDto MapToDto(this Kill kill)
    {
        return new KillDto()
        {
            GameHash = kill.GameHash,
            Team = kill.Team,
            Killer = kill.Killer ?? string.Empty,
            Victim = kill.Victim ?? string.Empty,
            Time = kill.Time ?? 0,
            Xpos = kill.Xpos ?? string.Empty,
            Ypos = kill.Ypos ?? string.Empty,
            Assist_1 = kill.Assist_1 ?? string.Empty,
            Assist_2 = kill.Assist_2 ?? string.Empty,
            Assist_3 = kill.Assist_3 ?? string.Empty,
            Assist_4 = kill.Assist_4 ?? string.Empty
        };
    }
}
