﻿using LoLMatchHistory.API.Mappers;
using LoLMatchHistory.API.Models;
using LoLMatchHistory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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

    [HttpGet("{playerName}")]
    public ActionResult<List<KillDto>> GetKillsByPlayerName(string playerName)
    {
        var matches = _repository.GetAllKillsByPlayer(playerName).Select(k => k.MapToDto()).ToList();

        if (!matches.Any())
        {
            return NoContent();
        }

        return matches;
    }

    [HttpGet("deaths/{playerName}")]
    public ActionResult<List<KillDto>> GetDeathsByPlayerName(string playerName)
    {
        var matches = _repository.GetAllDeathsByPlayer(playerName);

        if (!matches.Any())
        {
            return NoContent();
        }

        return matches.Select(k => k.MapToDto()).ToList();
    }

}
