using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.Infrastructure.Repositories;
public class BansRepository(LoLMatchHistoryContext context)
{
    private readonly LoLMatchHistoryContext _context = context;

    public List<Bans> GetAll()
    {
        return _context.Bans.ToList();
    }

    public List<Bans> GetByGameHash(string gameHash)
    {
        return _context.Bans
            .Where(s => s.GameHash == gameHash)
            .ToList();
    }

}
