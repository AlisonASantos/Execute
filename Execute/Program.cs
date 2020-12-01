using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;

namespace Execute
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(TimerCallback, null, 0, 5000);

            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50932/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/HelloWord").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao incluir produto");
            }

            Console.WriteLine("API Executada com sucesso ! ");

            GC.Collect();
        }
    }
}
