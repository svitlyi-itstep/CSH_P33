using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSH_P33
{
    class Oblast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAlert { get; set; }

        public Oblast(int id, string name, bool isAlert = false)
        {
            Id = id;
            Name = name;
            IsAlert = isAlert;
        }

        public Oblast() : this(0, "") { }
    }

    class Alert
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("location_title")]
        public int LocationTitle { get; set; }
        [JsonPropertyName("alert_type")]
        public int AlertType { get; set; }
        [JsonPropertyName("location_oblast_uid")]
        public int LocationOblastUid { get; set; }

        public override string ToString()
        {
            return $"Alert(Id={this.Id}, LocationTitle={this.LocationTitle}, " +
                $"AlertType={this.AlertType}, LocationOblastUid={this.LocationOblastUid})";
        }
    }

    class AlertsList
    {
        [JsonPropertyName("alerts")]
        public List<Alert> Alerts { get; set; }
    }

    class AirAlertMap
    {
        static List<Oblast> regions = new List<Oblast>()
            {
                new Oblast(0, ""),
                new Oblast(1, ""),
                new Oblast(2, ""),
                new Oblast(3, "Хмельницька область"),
                new Oblast(4, "Вінницька область"),
                new Oblast(5, "Рівненська область"),
                new Oblast(6, ""),
                new Oblast(7, ""),
                new Oblast(8, "Волинська область"),
                new Oblast(9, "Дніпропетровська область"),
                new Oblast(10, "Житомирська область"),
                new Oblast(11, "Закарпатська область"),
                new Oblast(12, "Запорізька область"),
                new Oblast(13, "Івано-Франківська область"),
                new Oblast(14, "Київська область"),
                new Oblast(15, "Кіровоградська область"),
                new Oblast(16, "Луганська область"),
                new Oblast(17, "Миколаївська область"),
                new Oblast(18, "Одеська область"),
                new Oblast(19, "Полтавська область"),
                new Oblast(20, "Сумська область"),
                new Oblast(21, "Тернопільська область"),
                new Oblast(22, "Харківська область"),
                new Oblast(23, "Херсонська область"),
                new Oblast(24, "Черкаська область"),
                new Oblast(25, "Чернігівська область"),
                new Oblast(26, "Чернівецька область"),
                new Oblast(27, "Львівська область"),
                new Oblast(28, "Донецька область"),
                new Oblast(29, "Автономна Республіка Крим"),
                new Oblast(30, "м. Севастополь"),
                new Oblast(31, "м. Київ")
         };

        static int[,] map = new int[mapHeight, mapWidth]
            {
                {0, 3, 0, 0, 31, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
            };


        const int mapWidth = 8, mapHeight = 6, cellWidth = 13;


        public static string ShortenName(string name, int length)
        {
            return name.Length > length ? name.Substring(0, length - 1) + "…" : name;
        }

        public static AlertsList? GetAlerts()
        {
            var httpClient = new HttpClient();
            string url = "https://4fe0-85-198-148-246.ngrok-free.app";
            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var asJson = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(asJson);
                return JsonSerializer.Deserialize<AlertsList>(asJson);
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
                return null;
            }
        }

        public static void DrawMap()
        {
            for (int column = 0; column < mapWidth; column++)
            {
                string region_name = "";
                if (map[0, column] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (regions[map[0, column]].IsAlert)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write($" {region_name,cellWidth} ");
                Console.ResetColor();
            }
            Console.WriteLine();

            for (int column = 0; column < mapWidth; column++)
            {
                string region_name = "";
                if (map[0, column] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (regions[map[0, column]].IsAlert)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    region_name = ShortenName(regions[map[0, column]].Name, cellWidth);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    region_name = ShortenName(regions[map[0, column]].Name, cellWidth);
                }
                Console.Write($" {region_name,cellWidth} ");
                Console.ResetColor();
            }
            Console.WriteLine();

            for (int column = 0; column < mapWidth; column++)
            {
                string region_name = "";
                if (map[0, column] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (regions[map[0, column]].IsAlert)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write($" {region_name,cellWidth} ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;

            regions[3].IsAlert = true;
            DrawMap();
        }
    }
}