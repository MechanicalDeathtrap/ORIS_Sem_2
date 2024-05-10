using Newtonsoft.Json;
using PokemonAPI.Models.dtos;
namespace Tests.PokemonControllerTests;

[TestClass]
public class PokemonGetByFilterTests
{
	private readonly HttpClient _httpClient = new();
	private const string Url = "http://localhost:5254/pokemon/getbyfilter";

	[TestMethod]
	[DataRow("arch")]
	[DataRow("bulba")]
	public async Task AllPokemonNamesContainFilterString(string filter)
	{
		var specificUrl = Url + $"/{filter}";

		var response = await _httpClient.GetStringAsync(specificUrl);
		var responseJson = JsonConvert.DeserializeObject<List<ResponceDto>>(response);

		if (responseJson is null)
			throw new NullReferenceException("Source was empty");

		var ifAllPokemonNamesContainFilterString = responseJson
			.All(i => CheckIfPokemonNameContainFilterString(i, filter));
		Assert.IsTrue(ifAllPokemonNamesContainFilterString);
	}

	[TestMethod]
	[DataRow("Wrong_filter")]
	[DataRow("AlsoVeryWrongFilter")]
	public async Task WrongFilterReturnsEmptyList(string filter)
	{
		var specificUrl = Url + $"/{filter}";

		var response = await _httpClient.GetStringAsync(specificUrl);
		var responseJson = JsonConvert.DeserializeObject<List<ResponceDto>>(response);

		if (responseJson is null)
			throw new NullReferenceException("Source was empty");

		Assert.AreEqual(0, responseJson.Count);
	}


	private static bool CheckIfPokemonNameContainFilterString(ResponceDto pokemonResponseDto, string filter)
	{
		return pokemonResponseDto.Name.ToLower().Contains(filter.ToLower());
	}
}