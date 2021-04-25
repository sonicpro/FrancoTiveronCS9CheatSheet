using FrancoTiveronCS9CheatSheet.AsynchronousStreams;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTests
{
	public class TestAsynchronousStream
	{
		private ITestOutputHelper output;

		public TestAsynchronousStream(ITestOutputHelper output)
		{
			this.output = output;
		}

		// There is no assert in this test. Just a demonstration of the new "await foreach" keyword.
		[Fact]
		public async Task TestStream()
		{
			var tenCodes = await GetTenRandomIso2Codes();
			var countries = IoTDataSource.DownloadCountriesStream(tenCodes);
			// "await foreach" is a new keyword thatcan be applied to a variable that implements IAsyncEnumerable<T>.
			await foreach (var country in countries)
			{
				output.WriteLine(country.GetProperty("name").GetString());
			}
		}

		private async Task<string[]> GetTenRandomIso2Codes()
		{
			// Download a hundred Iso2Codes from worldbank.org.
			JsonElement.ArrayEnumerator array = await IoTDataSource.FetchJsonFromUrl("http://api.worldbank.org/v2/country?format=json&per_page=100");
			// Remove array wrapper from the Json.
			JsonElement.ArrayEnumerator countries = array.Current.EnumerateArray();
			// Select iso2Codes from array of countries.
			string[] iso2Codes = countries.Select(c => c.GetProperty("iso2Code").GetString()).ToArray();
			// Take 10 sequential codes from the hundred of country data.
			var random = new System.Random();
			return Enumerable.Range(0, 10).Select(i => random.Next(i * 10, i * 10 + 10)).Select(i => iso2Codes[i]).ToArray();
		}
	}
}
