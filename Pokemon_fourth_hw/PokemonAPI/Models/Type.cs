using Redis.OM.Modeling;

namespace PokemonAPI.Models
{
	public class Type
	{
		[RedisIdField] public int Id { get; set; }
		public string Name { get; set; } = "";
		public string Url { get; set; } = "";
	}
}
