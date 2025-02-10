using LoLMatchHistory.API.Mappers;
using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;
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
            .Include(m => m.Bans)
            .Include(m => m.Kills)
            .Include(m => m.Gold)
            .Include(m => m.Structures)
            .Include(m => m.Monsters)
            .AsNoTracking()
            .AsSplitQuery()
            .ToListAsync();

        if (!matches.Any())
        {
            return NotFound();
        }

        var matchesDto = await Task.Run(() => matches.Select(m =>
        {
            var dto = m.MapToDto();

            dto.Kills = m.Kills.Select(k => k.MapToDto()).ToList();
            dto.Bans = m.Bans.Select(b => b.MapToDto()).ToList();
            dto.Gold = m.Gold.Select(g => g.MapToDto()).ToList();
            dto.Structures = m.Structures.Select(s => s.MapToDto()).ToList();
            dto.Monsters = m.Monsters.Select(mo => mo.MapToDto()).ToList();

            return dto;
        }).ToList());

        return matchesDto;
    }






    /*[HttpGet]
    public ActionResult<IReadOnlyList<MatchInfoDto>> GetAll()
    {
        var matches = _repository
            .GetAll()
            .Select(m => m.MapToDto())
            .AsNoTracking()
            .ToList();

        if (!matches.Any())
        {
            return NotFound();
        }

        foreach (var match in matches)
        {
            var bans = _bansRepository.GetByGameHash(match.GameHash).Select(b => b.MapToDto()).ToList();
            match.Bans = bans;
        }

        foreach (var match in matches)
        {
            var kills = _killsRepository.GetByGameHash(match.GameHash).Select(k => k.MapToDto()).ToList();
            match.Kills = kills;
        }

        foreach (var match in matches)
        {
            var gold = _goldRepository.GetByGameHash(match.GameHash).Select(g => g.MapToDto()).ToList();
            match.Gold = gold;
        }

        foreach (var match in matches)
        {
            var structures = _structuresRepository.GetByGameHash(match.GameHash).Select(s => s.MapToDto()).ToList();
            match.Structures = structures;
        }

        foreach (var match in matches)
        {
            var monsters = _monstersRepository.GetByGameHash(match.GameHash).Select(m => m.MapToDto()).ToList();
            match.Monsters = monsters;
        }

        return matches.AsReadOnly();
    }*/

    [HttpGet("v2")]
    public ActionResult<List<MatchInfoOptimizedDto>> GetAllOptimized()
    {
        var matches = _repository.GetAllCombined()
            //.Include(m => m.Bans)
            //.Include(m => m.Kills)
            .ToList();

        var matchDtos = matches.Select(match => new MatchInfoOptimizedDto
        {
            GameHash = match.GameHash,
            League = match.League,
            Year = match.Year,
            Season = match.Season,
            MatchType = match.Type,
            RedKills = match.Kills.Count(k => k.Team == "rKills"),
            BlueKills = match.Kills.Count(k => k.Team == "bKills"),
            Bans = match.Bans.Select(b => new BansDto
            {
                Team = b.Team,
                Ban1 = b.Ban1,
                Ban2 = b.Ban2,
                Ban3 = b.Ban3,
                Ban4 = b.Ban4,
                Ban5 = b.Ban5
            }).ToList()
        }).ToList();

        return Ok(matchDtos);
    }


    /// <summary>
    /// TODO Revisit this in the future. We should be able to do this
    /// 
    /// </summary>
    /// <returns></returns>
    /// 
    /*[HttpGet("v2")]
    public ActionResult<List<MatchInfoOptimizedDto>> GetAllOptimized()
    {
        var matches = _repository.GetAllCombined().ToList();

        List<MatchInfoOptimizedDto> matchDtos = [];

        foreach (MatchInfo match in matches)
        {
            MatchInfoOptimizedDto matchInfoDto = new()
            {
                GameHash = match.GameHash,
                League = match.League,
                Year = match.Year,
                Season = match.Season,
                MatchType = match.Type,
                RedKills = match.Kills.Count(k => k.Team.Equals("rKills")),
                BlueKills = match.Kills.Count(k => k.Team.Equals("bKills"))
            };

            foreach (Bans ban in match.Bans)
            {
                BansDto banDto = new()
                {
                    Team = ban.Team,
                    Ban1 = ban.Ban1,
                    Ban2 = ban.Ban2,
                    Ban3 = ban.Ban3,
                    Ban4 = ban.Ban4,
                    Ban5 = ban.Ban5
                };
                matchInfoDto.Bans.Add(banDto);
            }

            matchDtos.Add(matchInfoDto);
        }

        return Ok(matchDtos);
    }*/

    [HttpGet("{playerName}")]
    public ActionResult<List<MatchInfoDto>> GetByPlayerName(string playerName)
    {
        var matches = _repository
            .GetMatchesByPlayer(playerName)
            .Select(m => m.MapToDto())
            .ToList();
        if (!matches.Any())
        {
            return NotFound();
        }

        foreach (var match in matches)
        {
            var bans = _bansRepository.GetByGameHash(match.GameHash).Select(b => b.MapToDto()).ToList();
            match.Bans = bans;
        }

        foreach (var match in matches)
        {
            var kills = _killsRepository.GetByGameHash(match.GameHash).Select(k => k.MapToDto()).ToList();
            match.Kills = kills;
        }

        foreach (var match in matches)
        {
            var gold = _goldRepository.GetByGameHash(match.GameHash).Select(g => g.MapToDto()).ToList();
            match.Gold = gold;
        }

        foreach (var match in matches)
        {
            var structures = _structuresRepository.GetByGameHash(match.GameHash).Select(s => s.MapToDto()).ToList();
            match.Structures = structures;
        }

        foreach (var match in matches)
        {
            var monsters = _monstersRepository.GetByGameHash(match.GameHash).Select(m => m.MapToDto()).ToList();
            match.Monsters = monsters;
        }

        return matches;
    }

}
