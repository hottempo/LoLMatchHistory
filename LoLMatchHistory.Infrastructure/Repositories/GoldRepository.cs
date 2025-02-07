using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.Infrastructure.Repositories;
public class GoldRepository(LoLMatchHistoryContext context)
{
    private readonly LoLMatchHistoryContext _context = context;

    public List<Gold> GetAll()
    {
        return _context.Gold.ToList();
    }

    public List<Gold> GetByGameHash(string gameHash)
    {
        return _context.Gold
            .Where(s => s.GameHash == gameHash)
            .ToList();
    }
}
