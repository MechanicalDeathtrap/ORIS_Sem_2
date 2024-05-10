using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class MoveDto
	{
		[NotMapped]
		public Move Move { get; set; } = null!;
	}
}
