using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Domain.Interface;
using CardGameApi.src.Domain.Data;
using CardGameApi.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGameApi.src.Domain.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GameDbContext _context;

        public PlayerRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task UpdatePlayersWhereAsync(Func<Player, bool> matchCondition, Action<Player> updateAction)
        {
            var playersToUpdate = _context.Players.Where(matchCondition).ToList();

            foreach (var player in playersToUpdate)
            {
                updateAction(player);
            }

            await _context.SaveChangesAsync();
        }

    }
}