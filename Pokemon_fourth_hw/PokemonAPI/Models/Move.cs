using Redis.OM.Modeling;

namespace PokemonAPI.Models
{
	public class Move
	{
		[RedisIdField] public int Id { get; set; }
		public string Name { get; set; } = "";
		public string Url { get; set; } = "";
		public Type? Type { get; set; }
	}
}
