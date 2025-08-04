using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace CardGameApi.src.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public List<string> PlayerId { get; set; } = [];
        public List<string> CardId { get; set; } = [];
        public bool? isComplete { get; set; } = false;

        public Game(List<string> playerId, List<string> cardId, bool? isComplete = false)
        {
            PlayerId        = playerId;
            CardId          = cardId;
            this.isComplete = isComplete;
        }
    }
}