using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSH_P33.DeckOfCardsAPI
{
    class API
    {
        public static string host = "https://deckofcardsapi.com/";
        public static HttpClient httpClient = new HttpClient();

        public static DeckResponse MakeDeckRequest(string url)
        {
            var response = API.httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                DeckResponse? deck = JsonSerializer.Deserialize<DeckResponse>(jsonContent);
                if (deck != null) return deck;
                else throw new NullReferenceException();
            }
            else throw new HttpRequestException();
        }
    }

       
    class Deck
    {
        public string Id { get; set; }
        public int Remaining { get; set; }
        public bool Shuffled { get; set; }

        public Deck(int deckCount = 1) {
            this.Id = "";
            string url = $"{API.host}api/deck/new/shuffle/?deck_count={deckCount}";
            this.SetFromDeckResponse(API.MakeDeckRequest(url));
        }

        public Deck(string deckId)
        {
            this.Id = "";
            string url = $"{API.host}api/deck/{deckId}/";
            this.SetFromDeckResponse(API.MakeDeckRequest(url));
        }

        private void SetFromDeckResponse(DeckResponse deck)
        {
            this.Id = deck.Id;
            this.Remaining = deck.Remaining;
            this.Shuffled = deck.Shuffled;
        }
    }

    class DeckResponse
    {
        /*
       {
            "success": true,
            "deck_id": "y9l23kzvpcgs",
            "remaining": 52,
            "shuffled": true
        }
        */
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("deck_id")]
        public string Id { get; set; }
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }
        [JsonPropertyName("shuffled")]
        public bool Shuffled { get; set; }
    }
}
