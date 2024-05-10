using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class RequestDto
	{
		[NotMapped]
		public List<Pokemon> Results { get; init; } = new();
	}
}
