using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Formatting;
using Todo.Contracts;

namespace Todo.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21969/api/");

            var response = client.GetAsync("todos").Result;
            var items = response.Content.ReadAsAsync<List<TodoItemDto>>().Result;

            items.ForEach(i => Console.WriteLine(i.Title));

            Console.ReadLine();
        }
    }
}
