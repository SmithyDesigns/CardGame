using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CardGameApi.src.Entities;
using CardGameApi.src.Domain.Service;
using CardGameApi.src.Domain.Interface;


namespace CardGameApi.src.Domain.Service
{
    public class GameService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;
        private readonly CardService _cardService;
        private readonly PlayerService _playerService;

        public GameService(
            ICardRepository cardRepository,
            IPlayerRepository playerRepository,
            IGameRepository gameRepository,
            CardService cardService,
            PlayerService playerService)
        {
            _cardRepository = cardRepository;
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _cardService = cardService;
            _playerService = playerService;
        }

        public async Task<GameStartResult> StartNewGameAsync()
        {
            var players = await _playerRepository.GetAllPlayersAsync();
            var playerIdList = players.Select(p => p.Id.ToString()).ToList();

            var cards = await _cardRepository.GetAllCardsAsync();
            var roundPlayingCards = cards.OrderBy(_ => Guid.NewGuid()).Take(30).ToList();

            var cardIdList = roundPlayingCards.Select(c => c.Id).ToList();
            var cardIdStringList = cardIdList.Select(id => id.ToString()).ToList();

            await _cardRepository.UpdateCardsInDeckStatusAsync(cardIdList, false);

            var game = new Game(playerIdList, cardIdStringList);
            await _gameRepository.SaveAsync(game); // i want this game id returned and used in the data var created when returning a response please help me do so

            await _playerRepository.UpdatePlayersWhereAsync(
                p => playerIdList.Contains(p.Id.ToString()),
                player => player.GameId = game.Id);

            await _cardService.DealCardsToPlayersAsync(playerIdList, cardIdStringList);

            var playerScores = await _playerService.CalculateScoresForPlayersAsync(playerIdList);

            await _playerRepository.UpdatePlayersWhereAsync(
                p => playerIdList.Contains(p.Id.ToString()),
                player =>
                {
                    var idStr = player.Id.ToString();
                    if (playerScores.ContainsKey(idStr))
                    {
                        player.Score = playerScores[idStr];
                    }
                }
            );

            return new GameStartResult
            {
                GameId = game.Id,
                PlayerScores = playerScores
            };
        }
        
        public async Task EndGameAsync(int gameId)
        {
            await _gameRepository.UpdateGameAsync(
                gameId: gameId,
                isComplete: true
            );

            await _gameRepository.ResetAllCardsToDeckAsync();
        }
    }
}