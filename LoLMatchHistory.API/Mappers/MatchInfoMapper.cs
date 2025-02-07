using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.API.Mappers;

public static class MatchInfoMapper
{
    public static MatchInfoDto MapToDto(this MatchInfo matchInfo)
    {
        return new MatchInfoDto()
        {
            GameHash = matchInfo.GameHash,
            GameLength = matchInfo.GameLength,
            League = matchInfo.League,
            Year = matchInfo.Year,
            Season = matchInfo.Season,
            Type = matchInfo.Type,
            BlueTeamTag = matchInfo.BlueTeamTag,
            RedTeamTag = matchInfo.RedTeamTag,
            BlueResult = matchInfo.BlueResult,
            RedResult = matchInfo.RedResult,
            BlueADC = matchInfo.BlueADC,
            BlueADCChamp = matchInfo.BlueADCChamp,
            BlueJungle = matchInfo.BlueJungle,
            BlueJungleChamp = matchInfo.BlueJungleChamp,
            BlueMiddle = matchInfo.BlueMiddle,
            BlueMiddleChamp = matchInfo.BlueMiddleChamp,
            BlueSupport = matchInfo.BlueSupport,
            BlueSupportChamp = matchInfo.BlueSupportChamp,
            BlueTop = matchInfo.BlueTop,
            BlueTopChamp = matchInfo.BlueTopChamp,
            RedADC = matchInfo.RedADC,
            RedADCChamp = matchInfo.RedADCChamp,
            RedJungle = matchInfo.RedJungle,
            RedJungleChamp = matchInfo.RedJungleChamp,
            RedMiddle = matchInfo.RedMiddle,
            RedMiddleChamp = matchInfo.RedMiddleChamp,
            RedSupport = matchInfo.RedSupport,
            RedSupportChamp = matchInfo.RedSupportChamp,
            RedTop = matchInfo.RedTop,
            RedTopChamp = matchInfo.RedTopChamp
        };

    }

}
