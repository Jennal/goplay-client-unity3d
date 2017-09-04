using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoPlay.Encode.Json;
using GoPlay.Service;
using GoPlay.Transfer.Tcp;
using GoPlay.Package;
using System.Threading;
using GoPlay.Transfer;
using TestConsole.Login;

namespace TestConsole
{
    class Program
    {
        static Client<Tcp, JsonEncoder> client = new Client<Tcp, JsonEncoder>();

        static void TestLogin()
        {
            TestGuestLogin();
            TestUserLogin();
        }

        private static void TestUserLogin()
        {
            
        }

        private static void TestGuestLogin()
        {
            client.OnConnected += (ITransfer transfer)=> {
                client.Request("login.guest.register", new RegistGuestRequest { }, (LoginResponse resp) =>
                {
                    Console.WriteLine("Success: {0}, {1}", resp.UserToken, resp.Power);
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("Failed: {0}, {1}", err.Code, err.Message);
                });
            };
            client.Connect("192.168.1.200", 24680);
        }

        static void Main(string[] args)
        {
            client.OnError += Client_OnError;
            TestLogin();

            //client.OnDisconnected += Client_OnDisconnected;
            //client.OnConnected += Client_OnConnected;

            //client.On("echo.push", client, (string str) =>
            //{
            //    Console.WriteLine("On Push: {0}", str);
            //});
            //client.Connect("", 1234);

            Console.ReadKey();
        }

        private static void Client_OnConnected(GoPlay.Transfer.ITransfer obj)
        {
            for (int i = 0; i < 10; i++)
            {
                //if (i == 10)
                //{
                //    client.Disconnect();
                //    break;
                //}

                client.Notify("echo.services.notify", "Notify from client: " + i);

                client.Request("echo.services.echo", "Request from client: " + i, (string str) =>
                {
                    Console.WriteLine("Request callback: {0}", str);
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("Request Error: {0}", err);
                });
            }
        }

        private static void Client_OnDisconnected(GoPlay.Transfer.ITransfer obj)
        {
            obj.Connect("192.168.1.200", 1234);
        }

        private static void Client_OnError(Exception obj)
        {
            var err = obj;
            while (err.InnerException != null) err = err.InnerException;
            Console.WriteLine(err);
        }
    }
}
