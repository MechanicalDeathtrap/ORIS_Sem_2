using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class SpriteOtherHome
	{
		[NotMapped]
		public string Front_Default { get; set; } = "";
	}
}
