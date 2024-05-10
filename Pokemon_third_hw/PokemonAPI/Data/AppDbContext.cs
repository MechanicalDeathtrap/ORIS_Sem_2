using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PokemonAPI.Models;

namespace PokemonAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
    }
}
