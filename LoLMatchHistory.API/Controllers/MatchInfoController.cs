using LoLMatchHistory.API.Mappers;
using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Models;
using LoLMatchHistory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace LoLMatchHistory.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MatchInfoController(MatchInfoRepository repository,
    BansRepository bansRepository,
    KillsRepository killsRepository,
    GoldRepository goldRepository,
    StructuresRepository structuresRepository,
    MonstersRepository monstersRepository,
    ApiRequestLogRepository logRepository) : ControllerBase
{
    private readonly MatchInfoRepository _repository = repository;
    private readonly BansRepository _bansRepository = bansRepository;
    private readonly KillsRepository _killsRepository = killsRepository;
    private readonly GoldRepository _goldRepository = goldRepository;
    private readonly StructuresRepository _structuresRepository = structuresRepository;
    private readonly MonstersRepository _monstersRepository = monstersRepository;
    private readonly ApiRequestLogRepository _logRepository = logRepository;

    private string GetUsernameFromAuth()
    {
        string authHeader = Request.Headers.Authorization;
        if (!string.IsNullOrEmpty(authHeader))
        {
            string encodedCredentials = authHeader.Replace("Basic ", "").Trim();
            string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));

            return decodedString.Split(':')[0];
        }
        return "UnknownUser";
    }

    private async Task LogRequest(string endpoint, Stopwatch stopwatch)
    {

        string userId = GetUsernameFromAuth();

        long duration = stopwatch.ElapsedMilliseconds;

        var log = new ApiRequestLog
        {
            UserId = userId,
            Endpoint = endpoint,
            DurationMilliseconds = duration
        };

        await _logRepository.LogRequestAsync(log);
    }


    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<MatchInfoDto>>> GetAll()
    {

        Stopwatch stopwatch = Stopwatch.StartNew();

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

        stopwatch.Stop();

        await LogRequest("GET api/matchinfo", stopwatch);

        return Ok(matchesDto);
    }

    [HttpGet("v2")]
    public async Task<ActionResult<IReadOnlyList<MatchInfoOptimizedDto>>> GetAllOptimized()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

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

        stopwatch.Stop();

        await LogRequest("GET api/matchinfo/v2", stopwatch);


        return Ok(matchesDto);
    }

    [HttpGet("{playerName}")]
    public async Task<ActionResult<IReadOnlyList<MatchInfoDto>>> GetByPlayerName(string playerName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

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

        stopwatch.Stop();

        await LogRequest("GET api/matchinfo/{playername}", stopwatch);

        return Ok(matchesDto);
    }

}
