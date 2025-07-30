using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;

namespace CardGameApi.src.Domain.Interface
{
    public interface IPlayerRepository
    {
        public Task SaveAsync(Player player);
        public Task<List<Player>> GetPlayersAsync(int? id, string? name);
    }
}