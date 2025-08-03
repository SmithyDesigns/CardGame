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
        private readonly ICardRepository _cardRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;
        private readonly CardService _cardService;
        private readonly PlayerService _playerService;
        private readonly GameService _gameService;

        public GameController(
            ICardRepository cardRepository,
            IPlayerRepository playerRepository,
            CardService cardService,
            IGameRepository gameRepository,
            PlayerService playerService,
            GameService gameService
            )
        {
            _cardRepository = cardRepository;
            _playerRepository = playerRepository;
            _cardService = cardService;
            _gameRepository = gameRepository;
            _playerService = playerService;
            _gameService = gameService;
        }

        [HttpPost("start")]
        // public async Task<IActionResult> StartGame()
        // {

        //     var players = await _playerRepository.GetAllPlayersAsync();

        //     var playerIdList = players.Select(p => p.Id.ToString()).ToList();


        //     var cards = await _cardRepository.GetAllCardsAsync();

        //     var random = new Random();
        //     var roundPlayingCards = cards.OrderBy(c => random.Next()).Take(30).ToList();

        //     var cardIdList = new List<int>();
        //     var cardIdStringList = new List<string>();
        //     foreach (var card in roundPlayingCards)
        //     {
        //         cardIdList.Add(card.Id);
        //         cardIdStringList.Add(card.Id.ToString());
        //     }

        //     var roundPickedCards = _cardRepository.UpdateCardsInDeckStatusAsync(cardIdList, false);
        //     Game game = new Game(playerIdList, cardIdStringList);
        //     await _gameRepository.SaveAsync(game);

        //     await _playerRepository.UpdatePlayersWhereAsync(
        //         p => playerIdList.Contains(p.Id.ToString()),
        //         player => player.GameId = game.Id);

        //     var dealtcards = _cardService.DealCardsToPlayersAsync(playerIdList, cardIdStringList);
        //     var calculatePlayerScore = await _playerService.CalculateScoresForPlayersAsync(playerIdList);

        //     await _playerRepository.UpdatePlayersWhereAsync(
        //         p => playerIdList.Contains(p.Id.ToString()),
        //         player =>
        //         {
        //             var playerIdString = player.Id.ToString();

        //             if (calculatePlayerScore != null && calculatePlayerScore.ContainsKey(playerIdString))
        //             {
        //                 player.Score = calculatePlayerScore[playerIdString];
        //             }
        //         }
        //     );


        //     return Ok(calculatePlayerScore);
        // }

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

        // [HttpPost("{gameId}/addPlayer")]
        // public IActionResult AddPlayer(int gameId, [FromBody] AddPlayerRequest request)
        // {
        //     if (!_games.ContainsKey(gameId))
        //     {
        //         return NotFound("Game Not Found");
        //     }

        //     var game = _games[gameId];

        //     if (game.Players.Count >= 6)
        //     {
        //         return BadRequest("Max players reached");
        //     }

        //     game.AddPlayer(request.PlayerName);
        //     return Ok(new { message = "player added", playerName = request.PlayerName });
        // }

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