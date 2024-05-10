using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Services;

namespace PokemonAPI.Controllers
{
	[Route("[controller]/[action]")]
	public class PokemonController : ControllerBase
	{
		private readonly PokeApiService _pokeApiService;

		public PokemonController(PokeApiService pokeApiService) => _pokeApiService = pokeApiService;
		

		[HttpGet]
		public async Task<IActionResult> GetAll(int limit, int offset)
		{
			var pokemonDataDtoList = await _pokeApiService.GetByFilterAsync("", limit, offset);
			return Ok(new { results = pokemonDataDtoList });
		}

		[HttpGet]
		[Route("{filter}")]
		public async Task<IActionResult> GetByFilter(int limit, int offset, string filter)
		{
			var pokemonDataDtoList = await _pokeApiService.GetByFilterAsync(filter);
			return Ok(new { results = pokemonDataDtoList });
		}

		[HttpGet]
		[Route("{idOrName}")]
		public async Task<IActionResult> GetByIdOrName(string idOrName)
		{
			var pokemonDataDto = await _pokeApiService.GetByIdOrNameAsync(idOrName);

			if (pokemonDataDto is null)
				return NotFound();

			return Ok(new { results = pokemonDataDto });
		}
	}
}