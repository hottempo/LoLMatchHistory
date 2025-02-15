using LoLMatchHistory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LoLMatchHistory.Infrastructure.Repositories;
public class KillsRepository(LoLMatchHistoryContext context)
{
    private readonly LoLMatchHistoryContext _context = context;

    public IQueryable<Kill> GetAll()
    {
        return _context.Kills
            .AsNoTracking();
    }

    public IQueryable<Kill> GetAllKillsByPlayer(string playerName)
    {
        return _context
            .Kills
            .Where(k => k.Killer != null
                        && k.Killer.Contains(playerName));
    }

    public IQueryable<Kill> GetAllDeathsByPlayer(string playerName)
    {
        return _context
            .Kills
            .Where(k => k.Victim != null
                        && k.Victim.Contains(playerName));
    }

    public List<Kill> GetByGameHash(string gameHash)
    {
        return _context.Kills
            .Where(s => s.GameHash == gameHash)
            .ToList();
    }


}
