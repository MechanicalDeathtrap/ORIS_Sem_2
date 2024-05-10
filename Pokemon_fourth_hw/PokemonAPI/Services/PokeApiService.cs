using Newtonsoft.Json;
using PokemonAPI.Models;
using PokemonAPI.Models.dtos;
using System.Net;

namespace PokemonAPI.Services
{
	public class PokeApiService 
	{
		private readonly HttpClient _httpClient = new();
		private readonly string? _pokeApiPokemonUrl;

		public PokeApiService(IConfiguration configuration) => _pokeApiPokemonUrl = configuration.GetSection("Other")["PokeApiPokemonUrl"];
		

		public async Task<List<ResponceDto>> GetByFilterAsync(string filter = "", int limit = 20, int offset = 0)
		{
			if (!filter.Equals(""))
				limit = 10000;

			var response = await _httpClient.GetStringAsync(_pokeApiPokemonUrl + $"?limit={limit}" + $"&offset={offset}");
			var pokemonList = JsonConvert.DeserializeObject<RequestDto>(response);

			if (pokemonList is null)
				throw new NullReferenceException("Pokemons are not existing anymore!");

			var pokemonListFiltered = pokemonList.Results
				.Where(i => i.Name.ToLower().Contains(filter.ToLower()))
				.ToList();
			var pokemonDetailedList = new List<Details>();
			foreach (var pokemon in pokemonListFiltered)
			{

				var pokemonDetailed = await _httpClient.GetFromJsonAsync<Details>(pokemon.Url);

				if (pokemonDetailed is null)
					throw new NullReferenceException("Pokemon does not exist!");
				pokemonDetailedList.Add(pokemonDetailed);
			}

			var pokemonResponseDtoList = pokemonDetailedList
				.Select(MapPokemonDetailedToPokemonResponseDto)
				.ToList();

			return pokemonResponseDtoList;
		}

		public async Task<Details> GetByIdOrNameAsync(string idOrName)
		{
			var isParameterId = int.TryParse(idOrName, out var id);

			var response = await _httpClient.GetAsync(_pokeApiPokemonUrl + $"/{idOrName.ToLower()}");

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

			var responseData = await response.Content.ReadAsStringAsync();
			var pokemonDetailed = JsonConvert.DeserializeObject<Details>(responseData);

			return pokemonDetailed;
		}

		private ResponceDto MapPokemonDetailedToPokemonResponseDto(Details pokemonDetailed)
		{
			return new ResponceDto
			{
				Id = pokemonDetailed.Id,
				Name = pokemonDetailed.Name,
				Sprites = pokemonDetailed.Sprites,
				Types = pokemonDetailed.Types
			};
		}
	}
}
