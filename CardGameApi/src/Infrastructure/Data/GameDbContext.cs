using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CardGameApi.src.Entities;

namespace CardGameApi.src.Domain.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {}

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Card> Cards { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
            // modelBuilder.Entity<Game>()
            // .HasMany(g => g.Players)
            // .WithOne(p => p.Game)
            // .HasForeignKey(p => p.GameId);

            // modelBuilder.Entity<Player>()
            // .HasMany(p => p.Hand)
            // .WithOne(c => c.Player)
            // .HasForeignKey(c => c.PlayerId);
        // }
    }
}