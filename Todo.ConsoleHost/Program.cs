using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using TodoWebApp;

namespace Todo.ConsoleHost
{
    class Program
    {
        private const string webApiUrl = 
            "http://localhost:7778/services/todo";

        static void Main()
        {            
            var host = SetupWebApiServer(webApiUrl);
            host.OpenAsync().Wait();

            Console.WriteLine("Web API host running on {0}", webApiUrl);
            Console.WriteLine();
            Console.ReadKey();

            host.CloseAsync().Wait();
        }

        private static HttpSelfHostServer SetupWebApiServer(string url)
        {            
            var configuration = new HttpSelfHostConfiguration(url);
            WebApiConfig.Register(configuration);

            var host = new HttpSelfHostServer(configuration);

            return host;
        }
    }
}
