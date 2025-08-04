using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Domain.Interface;
using CardGameApi.src.Domain.Repository;
using CardGameApi.src.Domain.Service;
using CardGameApi.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CardGameApi.src.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartGame()
        {
            var result = await _gameService.StartNewGameAsync();
            return Ok(result);
        }

        [HttpPost("end")]
        public async Task<IActionResult> EndGame(int gameId)
        {
            await _gameService.EndGameAsync(gameId);
            return Ok(new { message = "Game Finished" });
        }
    }
}