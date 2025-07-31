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

        public GameController(ICardRepository cardRepository, IPlayerRepository playerRepository, CardService cardService, IGameRepository gameRepository)
        {
            _cardRepository = cardRepository;
            _playerRepository = playerRepository;
            _cardService = cardService;
            _gameRepository = gameRepository;

        }
        // private static Dictionary<int, Game> _games = new Dictionary<int, Game>();
        // private static int _gameIdCounter = 0;

        [HttpPost("start")]
        public async Task<IActionResult> StartGame()
        {

            var players = await _playerRepository.GetAllPlayersAsync();

            var playerIdList = players.Select(p => p.Id.ToString()).ToList();


            var cards = await _cardRepository.GetAllCardsAsync();

            var random = new Random();
            var roundPlayingCards = cards.OrderBy(c => random.Next()).Take(30).ToList();

            var cardIdList = new List<int>();
            var cardIdStringList = new List<string>();
            foreach (var card in roundPlayingCards)
            {
                cardIdList.Add(card.Id);
                cardIdStringList.Add(card.Id.ToString());
            }

            var roundPickedCards = _cardRepository.UpdateCardsInDeckStatusAsync(cardIdList, false);
            Game game = new Game(playerIdList, cardIdStringList);
            await _gameRepository.SaveAsync(game);

            // var dealtcards = _cardService.DealCardsToPlayersAsync(playerIdList, cardIdStringList);
            var dealtcards = _cardService.DealCardsToPlayersAsync(playerIdList, cardIdStringList);

            //@todo - now to give all players 5 cards
            // playerIdList =
            // cardIdStringList = 
            // game.Id

            // @todo update players cardId field and gameId field

            // @todo - calculate the score of earch player update score field in player table. determine winner and if it is a tie or not

            //@todo - do tie caluation update db.

            //@todo update card table when end game is hit to update all the db values back to oriiginal values





            // var article = await _articleService.Create(createDto);

            // var articleDto = new ArticleDto
            // {
            //     Title = article.Title,
            //     Html = article.Html
            // };

            // return Ok(articleDto);

            // return Ok(new { message = "Game Started" });
            return Ok(game);
        }

        [HttpPost("end")]
        public IActionResult EndGame(string gameId)
        {
            // var newGame = new Game();
            // var newGameId = _gameIdCounter++;
            // _games[newGameId] = newGame;

            return Ok(new { message = "Game Finised" });
            // return Ok(new { gameId = newGameId, message = "Game Started" });
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