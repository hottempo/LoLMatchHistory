using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.Infrastructure.Repositories;
public class MonstersRepository(LoLMatchHistoryContext context)
{
    private readonly LoLMatchHistoryContext _context = context;

    public List<Monster> GetAll()
    {
        return _context.Monsters.ToList();
    }

    public List<Monster> GetAllByType(string monsterType)
    {
        return _context.Monsters
            .Where(m => m.Type == monsterType)
            .ToList();
    }

    public List<Monster> GetByGameHash(string gameHash)
    {
        return _context.Monsters
            .Where(s => s.GameHash == gameHash)
            .ToList();
    }


}
