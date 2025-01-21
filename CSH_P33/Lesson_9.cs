using System.Text;
using System.Net.Http;
using System.Text.Json;

namespace CSH_P33
{
    class MeowFactsData
    {
        public List<string> data { get; set; }
    }

    class Lesson_9
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();

            string url = "https://meowfacts.herokuapp.com/";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var asJson = await response.Content.ReadAsStringAsync();
                var facts = JsonSerializer.Deserialize<MeowFactsData>(asJson);

                foreach (var fact in facts.data)
                {
                    Console.WriteLine(fact);
                }
            }
        }
    }
}
