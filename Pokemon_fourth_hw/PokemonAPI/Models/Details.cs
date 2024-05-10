using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.dtos;
using Redis.OM.Modeling;

namespace PokemonAPI.Models
{
	public class Details
	{
		[RedisIdField] public int Id { get; set; }
		[Indexed] public string Name { get; set; }
		public int Height { get; set; }
		public int Weight { get; set; }
		public List<MoveDto> Moves { get; set; } = null;
		public SpriteDto Sprites { get; set; } = null;
		public List<AbilityDto> Abilities { get; set; } = null;
		public List<TypeDto> Types { get; set; } = null;
		public List<StatDto> Stats { get; set; } = null;
	}
}
