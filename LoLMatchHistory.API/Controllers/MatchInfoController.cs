using LoLMatchHistory.API.Mappers;
using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoLMatchHistory.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MatchInfoController(MatchInfoRepository repository,
    BansRepository bansRepository,
    KillsRepository killsRepository,
    GoldRepository goldRepository,
    StructuresRepository structuresRepository,
    MonstersRepository monstersRepository) : ControllerBase
{
    private readonly MatchInfoRepository _repository = repository;
    private readonly BansRepository _bansRepository = bansRepository;
    private readonly KillsRepository _killsRepository = killsRepository;
    private readonly GoldRepository _goldRepository = goldRepository;
    private readonly StructuresRepository _structuresRepository = structuresRepository;
    private readonly MonstersRepository _monstersRepository = monstersRepository;


    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<MatchInfoDto>>> GetAll()
    {
        var matches = await _repository.GetAll()
            .ToListAsync();

        if (!matches.Any())
        {
            return NotFound();
        }

        var matchesDto = matches
            .Select(m =>
        {
            var dto = m.MapToDto();

            dto.Kills = m.Kills.Select(k => k.MapToDto()).ToList();
            dto.Bans = m.Bans.Select(b => b.MapToDto()).ToList();
            dto.Gold = m.Gold.Select(g => g.MapToDto()).ToList();
            dto.Structures = m.Structures.Select(s => s.MapToDto()).ToList();
            dto.Monsters = m.Monsters.Select(mo => mo.MapToDto()).ToList();

            return dto;
        }).ToList();

        return Ok(matchesDto);
    }

    [HttpGet("v2")]
    public async Task<ActionResult<IReadOnlyList<MatchInfoOptimizedDto>>> GetAllOptimized()
    {
        var matches = await _repository.GetAllOptimized()
            .ToListAsync();

        if (!matches.Any())
        {
            return NotFound();
        }

        var matchesDto = matches
            .GroupBy(m => m.GameHash)
            .Select(group =>
            {
                var dto = group.First().MapToDto();

                dto.Bans = group.Select(b => BansMapper.MapToDto(b)).ToList();

                return dto;
            }).ToList();

        return Ok(matchesDto);
    }

    [HttpGet("{playerName}")]
    public async Task<ActionResult<IReadOnlyList<MatchInfoDto>>> GetByPlayerName(string playerName)
    {
        var matches = await _repository.GetMatchesByPlayer(playerName)
            .ToListAsync();

        if (!matches.Any())
        {
            return NotFound();
        }

        var matchesDto = matches
            .Select(m =>
            {
                var dto = m.MapToDto();

                dto.Kills = m.Kills.Select(k => k.MapToDto()).ToList();
                dto.Bans = m.Bans.Select(b => b.MapToDto()).ToList();
                dto.Gold = m.Gold.Select(g => g.MapToDto()).ToList();
                dto.Structures = m.Structures.Select(s => s.MapToDto()).ToList();
                dto.Monsters = m.Monsters.Select(mo => mo.MapToDto()).ToList();

                return dto;
            }).ToList();

        return Ok(matchesDto);
    }

}
