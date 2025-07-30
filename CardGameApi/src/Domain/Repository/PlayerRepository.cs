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

        public async Task SaveAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Player>> GetPlayersAsync(int? id, string? name)
        {
            var query = _context.Players.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name == name);

            if (id.HasValue)
                query = query.Where(p => p.Id.Equals(id));

            return await query.ToListAsync();
        }
    }
}