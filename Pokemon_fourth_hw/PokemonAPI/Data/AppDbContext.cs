using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using PokemonAPI.Models;
using PokemonAPI.Models.dtos;

namespace PokemonAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemonss { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Ignore<AbilityDto>();
			modelBuilder.Ignore<MoveDto>();
			modelBuilder.Ignore<RequestDto>();
			modelBuilder.Ignore<ResponceDto>();
			modelBuilder.Ignore<SpriteDto>();
			modelBuilder.Ignore<SpriteOther>();
			modelBuilder.Ignore<SpriteOtherHome>();
			modelBuilder.Ignore<StatDto>();
			modelBuilder.Ignore<TypeDto>();
		}
	}
}
