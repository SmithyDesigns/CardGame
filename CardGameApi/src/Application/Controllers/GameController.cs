using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CardGameApi.src.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static Dictionary<int, Game> _games = new Dictionary<int, Game>();
        private static int _gameIdCounter = 0;

        [HttpPost("start")]
        public IActionResult StartGame()
        {
            var newGame = new Game();
            var newGameId = _gameIdCounter++;
            _games[newGameId] = newGame;

            return Ok(new { gameId = newGameId, message = "Game Started" });
        }

        [HttpPost("{gameId}/addPlayer")]
        public IActionResult AddPlayer(int gameId, [FromBody] AddPlayerRequest request)
        {
            if (!_games.ContainsKey(gameId))
            {
                return NotFound("Game Not Found");
            }

            var game = _games[gameId];

            if (game.Players.Count >= 6)
            {
                return BadRequest("Max players reached");
            }

            game.AddPlayer(request.PlayerName);
            return Ok(new { message = "player added", playerName = request.PlayerName });
        }

        // [HttpPost("{gameId}/dealCards")]
        // public IActionResult DealCards(int gameId)
        // {
        //     if (!_games.ContainsKey(gameId))
        //     {
        //         return NotFound("Game Not Found");
        //     }

        //     var game = _games[gameId];
        //     game.DealCards();
        //     return Ok(new
        //     {
        //         players = game.Players.Select(p => new { p.Name, Hand = p.Hand.Select(c => $"{c.Rank} of {c.Suit}") })
        //     });
        // }

        // [HttpPost("{gameId}/calculateScores")]
        // public IActionResult CalculateScores(int gameId)
        // {
        //     if (!_games.ContainsKey(gameId))
        //     {
        //         return NotFound("Game Not Found");
        //     }

        //     var game = _games[gameId];
        //     game.CalculateScores();
        //     return Ok(new
        //     {
        //         players = game.Players.Select(p => new { p.Name, p.Score })
        //     });
        // }

        // [HttpPost("{gameId}/breakTie")]
        // public IActionResult BreakTie(int gameId)
        // {
        //     if (!_games.ContainsKey(gameId))
        //     {
        //         return NotFound("Game Not Found");
        //     }

        //     var game = _games[gameId];
        //     game.DetermineWinner();
        //     return Ok(new
        //     {
        //         winner = game.Players.First().Name
        //     });
        // }

        // [HttpPost("{gameId}/status")]
        // public IActionResult GetGameStatus(int gameId)
        // {
        //     if (!_games.ContainsKey(gameId))
        //     {
        //         return NotFound("Game Not Found");
        //     }

        //     var game = _games[gameId];
        //     return Ok(new
        //     {
        //         players = game.Players.Select(p => new { p.Name, Hand = p.Hand.Select(c => $"{c.Rank} of {c.Suit}"), p.Score }),
        //         winner = game.Players.FirstOrDefault()?.Name
        //     });
        // }
    }
}