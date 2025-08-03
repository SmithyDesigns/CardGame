using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;

namespace CardGameApi.src.Domain.Interface
{
    public interface IPlayerRepository
    {
        Task UpdatePlayersWhereAsync(Func<Player, bool> matchCondition, Action<Player> updateAction);
        Task<List<Player>> GetAllPlayersAsync();
    }
}