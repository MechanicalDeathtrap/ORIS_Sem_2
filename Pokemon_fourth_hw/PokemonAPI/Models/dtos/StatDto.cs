using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class StatDto
	{
		[NotMapped]
		public int Base_Stat { get; set; }
		public Stats Stat { get; set; } = null!;
	}
}
