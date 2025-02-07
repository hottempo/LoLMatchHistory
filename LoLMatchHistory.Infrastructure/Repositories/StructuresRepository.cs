using LoLMatchHistory.Infrastructure.Models;

namespace LoLMatchHistory.Infrastructure.Repositories;
public class StructuresRepository(LoLMatchHistoryContext context)
{
    private readonly LoLMatchHistoryContext _context = context;

    public List<Structure> GetAll()
    {
        return _context.Structures.ToList();
    }

    public List<Structure> GetAllByType(string structureType)
    {
        return _context.Structures
            .Where(s => s.Type == structureType)
            .ToList();
    }

    public List<Structure> GetByGameHash(string gameHash)
    {
        return _context.Structures
            .Where(s => s.GameHash == gameHash)
            .ToList();
    }

}
