using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSH_P33
{
    class MeowFactsResponse
    {
        [JsonPropertyName("data")]
        public List<string> Data { get; set; }
    }
    
    class Lesson10
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;

            string date = "2025-01-01";
            DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd", null);
            if(dateTime < DateTime.Now) { /* Дата вже пройшла */ }
            else { /* Дата ще не настала */ }

            HttpClient client = new HttpClient();
            string url = "https://meowfacts.herokuapp.com/";
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                string data = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(data);
                MeowFactsResponse? facts = JsonSerializer.Deserialize<MeowFactsResponse>(data);
                if (facts is null) throw new NullReferenceException();

                foreach (var fact in facts.Data)
                {
                    Console.WriteLine(fact);
                }
            }
        }
    }
}
