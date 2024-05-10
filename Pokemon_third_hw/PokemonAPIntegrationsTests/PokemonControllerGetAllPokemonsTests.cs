
using Newtonsoft.Json;
using PokemonAPI.Models.dtos;

namespace Tests.PokemonControllerTests;

[TestClass]
public class PokemonGetAllTests
{
	private readonly HttpClient _httpClient = new();
	private const string Url = "http://localhost:5254/pokemon/getall";

	[TestMethod]
	[DataRow(5)]
	public async Task LimitWorksRight(int limit)
	{
		var specificUrl = Url + $"?limit={limit}";

		var response = await _httpClient.GetStringAsync(specificUrl);
		var responseJson = JsonConvert.DeserializeObject<List<ResponceDto>>(response);

		if (responseJson is null || !responseJson.Any())
			throw new NullReferenceException("Source was empty");
		Assert.AreEqual(limit, responseJson.Count);
	}

	[TestMethod]
	public async Task NoLimitReturns20()
	{
		var response = await _httpClient.GetStringAsync(Url);
		var responseJson = JsonConvert.DeserializeObject<List<ResponceDto>>(response);

		if (responseJson is null || !responseJson.Any())
			throw new NullReferenceException("Source was empty");

		Assert.AreEqual(20, responseJson.Count);
	}

	[TestMethod]
	[DataRow(4, 11)]
	public async Task LimitAndOffsetWorkRight(int limit, int offset)
	{
		var specificUrl = Url + $"?limit={limit}" + $"&offset={offset}";

		var response = await _httpClient.GetStringAsync(specificUrl);
		var responseJson = JsonConvert.DeserializeObject<List<ResponceDto>>(response);

		if (responseJson is null || !responseJson.Any())
			throw new NullReferenceException("Source was empty");

		Assert.IsTrue(offset + 1 == responseJson.First().Id && responseJson.Count == limit);
	}
}
