using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class SpriteOther
	{
		[NotMapped]
		public SpriteOtherHome Home { get; set; } = null!;
	}
}
