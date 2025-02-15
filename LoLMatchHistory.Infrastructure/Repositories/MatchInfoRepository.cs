using LoLMatchHistory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LoLMatchHistory.Infrastructure.Repositories;
public class MatchInfoRepository(LoLMatchHistoryContext context)
{
    private readonly LoLMatchHistoryContext _context = context;

    public IQueryable<MatchInfo> GetAll()
    {
        return _context.Matches
            .AsNoTracking()
            .AsSplitQuery()
            .Include(m => m.Bans)
            .Include(m => m.Kills)
            .Include(m => m.Gold)
            .Include(m => m.Structures)
            .Include(m => m.Monsters);
        }

    public IQueryable<MatchInfoOptimizedView> GetAllOptimized()
    {
        return _context.MatchInfoOptimized
            .AsNoTracking();
    }

    public IQueryable<MatchInfo> GetMatchesByPlayer(string playerName)
    {
        return _context.Matches
            .Where(m =>
                new[]
                {
                    m.BlueTop, m.BlueJungle, m.BlueMiddle, m.BlueADC, m.BlueSupport,
                    m.RedTop, m.RedJungle, m.RedMiddle, m.RedADC, m.RedSupport
                }.Contains(playerName)
            )
            .AsNoTracking()
            .AsSplitQuery()
            .Include(m => m.Bans)
            .Include(m => m.Kills)
            .Include(m => m.Gold)
            .Include(m => m.Structures)
            .Include(m => m.Monsters);
    }
}
