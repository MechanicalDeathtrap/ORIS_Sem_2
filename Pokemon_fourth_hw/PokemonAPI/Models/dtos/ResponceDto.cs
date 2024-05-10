using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonAPI.Models.dtos
{
	public class ResponceDto
	{
		[NotMapped]
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public SpriteDto Sprites { get; set; } = null!;
		public List<TypeDto> Types { get; set; } = null!;
	}
}
