using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class TypeDto
	{
		[NotMapped]
		public Type Type { get; set; } = null!;
	}
}
