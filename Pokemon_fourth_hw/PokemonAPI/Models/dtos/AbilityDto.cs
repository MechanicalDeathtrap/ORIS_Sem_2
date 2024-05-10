using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class AbilityDto
	{
		[NotMapped]
		public Ability Ability { get; set; } = null!;
	}
}
