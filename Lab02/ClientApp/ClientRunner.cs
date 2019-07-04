using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class ClientRunner
    {
        private readonly HttpClient _client;

        public ClientRunner(HttpClient client)
        {
            _client = client;
        }

        public async Task GetBooksAsync()
        {
            try
            {
                var response = await _client.GetAsync("/api/Books");
                response.EnsureSuccessStatusCode();  // throw exception if no success
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                IEnumerable<Book> books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task PostBookAsync()
        {
            var newBook = new Book
            {
                BookId = 0,
                Title = "Professional C# 9",
                Publisher = "Wrox Press"
            };

            string newBookJson = JsonConvert.SerializeObject(newBook);

            HttpContent content = new StringContent(newBookJson, Encoding.UTF8, "application/json");


            var postResponse = await _client.PostAsync("/api/Books", content);
        }
    }
}
