namespace PokemonAPI.Models.dtos
{
	public class RequestDto
	{
		public List<Pokemon> Results { get; init; } = new();
	}
}
