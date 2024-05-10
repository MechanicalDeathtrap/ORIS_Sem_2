using Redis.OM.Modeling;

namespace PokemonAPI.Models
{
	public class Stats
	{
		[RedisIdField] public int Id { get; set; }
		public string Name { get; set; } = "";
		public string Url { get; set; } = "";
	}
}
