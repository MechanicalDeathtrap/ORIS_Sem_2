using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class SpriteDto
	{
		[NotMapped]
		public SpriteOther Other { get; set; } = null!;
	}
}
