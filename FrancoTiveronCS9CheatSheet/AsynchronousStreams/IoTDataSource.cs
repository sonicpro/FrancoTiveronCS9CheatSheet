using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FrancoTiveronCS9CheatSheet.AsynchronousStreams
{
	// Simulates slow answering data source.
	public static class IoTDataSource
	{
		private static SemaphoreSlim[] semaphores;

		// This is the new IAsyncEnumerable interface type.
		public static async IAsyncEnumerable<JsonElement> DownloadCountriesStream(string[] iso2Codes)
		{
			// Simulare "latency" of the spread sensors data source.
			StartFeed(iso2Codes.Length);
			for (int i = 0; i < iso2Codes.Length; i++)
			{
				// This is the new CS9 keyword "yield return await".
				yield return await DownloadCountryAsync(i, iso2Codes[i]);
			}
		}

		// This method is suitable only for Json in the style pf api.worlbank.org/v2.
		// Specifically the returned Json array mustcontain the first element for header.
		public static async Task<JsonElement.ArrayEnumerator> FetchJsonFromUrl(string url)
		{
			var webClient = new WebClient();
			var response = await webClient.DownloadStringTaskAsync(url);
			JsonDocument responseJson = JsonDocument.Parse(response);
			JsonElement.ArrayEnumerator array = responseJson.RootElement.EnumerateArray();
			// Enumerate to the header.
			array.MoveNext();
			// Skip the header to the array of countries.
			array.MoveNext();
			return array;
		}

		private static async Task<JsonElement> DownloadCountryAsync(int semaphoreNumber, string iso2Code)
		{
			// Proceed only when the semaphore is not zero.
			await semaphores[semaphoreNumber].WaitAsync();
			JsonElement.ArrayEnumerator countryJson = await FetchJsonFromUrl($"http://api.worldbank.org/v2/country/{iso2Code}?format=json");
			// "country" variable represens a single country Json wrapped into array.
			JsonElement country = countryJson.Current;
			if (country.ValueKind != JsonValueKind.Array)
				throw new System.FormatException("Invalid Json Format");
			return country[0];
		}

		// When called, initializes semaphores field with n semaphores each zeroed initially.
		// Release each semaphore after 1 second.
		private static void StartFeed(int sensorsCount)
		{
			async Task Feed()
			{
				for (int i = 0; i < sensorsCount; i++)
				{
					await Task.Delay(1000);
					semaphores[i].Release();
				}
			};
			// Each semapure has initial count of 0 and max allowed threads to pass of 1.
			semaphores = Enumerable.Range(0, sensorsCount).Select(_ => new SemaphoreSlim(0, 1)).ToArray();
			Task.Run(Feed);
		}
	}
}
