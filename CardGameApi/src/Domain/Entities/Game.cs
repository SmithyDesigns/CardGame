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
        public List<Player> Players { get; set; }
        public Deck Deck { get; set; } = new ();
        public bool CanAddPlayer => Players.Count < 6;

        public void AddPlayer(Player player)
        {
            if (!CanAddPlayer)
                throw new InvalidOperationException("Maximum players reached.");

            Players.Add(player);
        }

    }
}