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
        public static async Task<MeowFactsData?> GetMeowFacts(int count = 1, string lang="eng")
        {
            var httpClient = new HttpClient();

            string url = "https://meowfacts.herokuapp.com/";
            string parameters = $"?count={count}&lang={lang}";

            var response = await httpClient.GetAsync(url + parameters);
            if (response.IsSuccessStatusCode)
            {
                var asJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MeowFactsData>(asJson);                
            }

            return null;
        }

        public static async Task GetAlerts()
        {
            var httpClient = new HttpClient();

            string url = "https://92e8-85-198-148-245.ngrok-free.app/";

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var asJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(asJson);
                // return JsonSerializer.Deserialize<MeowFactsData>(asJson);
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
            }
        }

        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;

            await GetAlerts();
            //var facts = await GetMeowFacts(3, "ukr");
            //foreach (var fact in facts.data)
            //{
            //    Console.WriteLine(fact + "\n");
            //}

        }
    }
}
