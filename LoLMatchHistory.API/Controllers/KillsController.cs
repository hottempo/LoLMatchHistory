using LoLMatchHistory.API.Mappers;
using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoLMatchHistory.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class KillsController(KillsRepository repository) : ControllerBase
{
    private readonly KillsRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<KillDto>>> GetAll()
    {
        var matches = await _repository.GetAll()
            .Select(k => k.MapToDto())
            .ToListAsync();

        if (!matches.Any())
        {
            return NotFound();
        }

        return Ok(matches);
    }

    [HttpGet("game/{gamehash}")]
    public async Task<ActionResult<IReadOnlyList<KillDto>>> GetKillsByGameHash(string gamehash)
    {
        var matches = await _repository.GetByGameHash(gamehash)
            .Select(k => k.MapToDto())
            .ToListAsync(); ;

        if (!matches.Any())
        {
            return NotFound();
        }

        return Ok(matches);
    }


    [HttpGet("{playerName}")]
    public async Task<ActionResult<IReadOnlyList<KillDto>>> GetKillsByPlayerName(string playerName)
    {
        var matches = await _repository.GetAllKillsByPlayer(playerName)
            .Select(k => k.MapToDto())
            .ToListAsync();

        if (!matches.Any())
        {
            return NotFound();
        }

        return Ok(matches);
    }

    [HttpGet("deaths/{playerName}")]
    public async Task<ActionResult<IReadOnlyList<KillDto>>> GetDeathsByPlayerName(string playerName)
    {
        var matches = await _repository.GetAllDeathsByPlayer(playerName)
            .Select(k => k.MapToDto())
            .ToListAsync();

        if (!matches.Any())
        {
            return NotFound();
        }

        return Ok(matches);
    }
}
