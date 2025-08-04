using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardGameApi.src.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; } = 0;
        public List<string>? CardId { get; set; } = null;
        public int? GameId { get; set; } = null;

        public Player(string name, int score, List<string>? cardId = null, int? gameId = null)
        {
            Name   = name;
            Score  = score;
            CardId = cardId;
            GameId = gameId;
        }
    }
}