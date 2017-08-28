using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoPlay.Encode.Json;
using GoPlay.Service;
using GoPlay.Transfer.Tcp;
using GoPlay.Package;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client<Tcp, JsonEncoder>();

            client.On("echo.push", client, (string str) =>
            {
                Console.WriteLine("On Push: {0}", str);
            });
            client.Connect("", 1234);

            client.Notify("echo.services.notify", "Notify from client");

            client.Request("echo.services.echo", "Request from client", (string str) =>
            {
                Console.WriteLine("Request callback: {0}", str);
            }, (ErrorMessage err) =>
            {
                Console.WriteLine("Request Error: {0}", err);
            });

            Console.ReadKey();
        }
    }
}
