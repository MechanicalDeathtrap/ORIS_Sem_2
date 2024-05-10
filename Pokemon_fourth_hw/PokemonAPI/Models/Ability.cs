using Redis.OM.Modeling;

namespace PokemonAPI.Models
{
	public class Ability
	{
		[RedisIdField] public int Id { get; set; }
		public string Name { get; set; } = "";
		public string Url { get; set; } = "";
	}
}
