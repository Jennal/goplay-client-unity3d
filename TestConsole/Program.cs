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
using TestConsole.ServerStatus;
using GoPlay.Encode.Protobuf;
using Protobuf.Status;

namespace TestConsole
{
    class Program
    {
        static Client<Tcp, JsonEncoder> client = new Client<Tcp, JsonEncoder>();
        static Client<Tcp, ProtobufEncoder> pclient = new Client<Tcp, ProtobufEncoder>();

        private static void TestGetProtoServerStatus()
        {
            pclient.OnConnected += (ITransfer transfer) =>
            {
                pclient.Request("status.server.status", (ServerStatusResponse resp) =>
                {
                    Console.WriteLine(resp.ServerStatus);
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("Failed: {0}, {1}", err.Code, err.Message);
                });
            };

        }

        private static void TestProtoLogin()
        {
            //TestProtoGuestLogin();
            TestProtoUserLogin();
        }

        private static void TestProtoUserLogin()
        {
            var userName = "jennal123";
            var passWord = "1234";

            pclient.OnConnected += (ITransfer transfer) =>
            {
                pclient.Request("login.user.checkusername", new Protobuf.Login.CheckUserRequest
                {
                    Username = "abcd"
                }, (Protobuf.Login.CheckUserResponse resp) =>
                {
                    Console.WriteLine("login.user.checkusername Success: {0}", resp.Result);
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("Failed: {0}, {1}", err.Code, err.Message);
                });

                pclient.Request("login.user.register", new Protobuf.Login.LoginRequest
                {
                    Username = userName,
                    Password = passWord
                }, (Protobuf.Login.LoginResponse resp) =>
                {
                    Console.WriteLine("login.user.register Success: {0}, {1}", resp.UserToken, resp.Power);
                    pclient.Request("login.user.loginbytoken", new Protobuf.Login.LoginTokenRequest
                    {
                        UserToken = resp.UserToken
                    }, (Protobuf.Login.LoginResponse loginResp) =>
                    {
                        Console.WriteLine("login.user.loginbytoken Success: {0}, {1}", resp.UserToken, resp.Power);
                    }, (ErrorMessage err) =>
                    {
                        Console.WriteLine("login.user.loginbytoken Failed: {0}, {1}", err.Code, err.Message);
                    });

                    pclient.Request("login.user.login", new Protobuf.Login.LoginRequest
                    {
                        Username = userName,
                        Password = passWord
                    }, (Protobuf.Login.LoginResponse loginResp) =>
                    {
                        Console.WriteLine("login.user.login Success: {0}, {1}", resp.UserToken, resp.Power);
                    }, (ErrorMessage err) =>
                    {
                        Console.WriteLine("login.user.login Failed: {0}, {1}", err.Code, err.Message);
                    });
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("login.user.register Failed: {0}, {1}", err.Code, err.Message);
                });
            };
        }

        private static void TestProtoGuestLogin()
        {
            pclient.OnConnected += (ITransfer transfer) =>
            {
                pclient.Request("login.guest.register", new Protobuf.Login.RegistGuestRequest { }, (Protobuf.Login.LoginResponse resp) =>
                {
                    Console.WriteLine("login.guest.register Success: {0}, {1}", resp.UserToken, resp.Power);
                    pclient.Request("login.guest.login", new Protobuf.Login.LoginTokenRequest
                    {
                        UserToken = resp.UserToken
                    }, (Protobuf.Login.LoginResponse loginResp) =>
                    {
                        Console.WriteLine("login.guest.login Success: {0}, {1}", resp.UserToken, resp.Power);
                    }, (ErrorMessage err) =>
                    {
                        Console.WriteLine("login.guest.login Failed: {0}, {1}", err.Code, err.Message);
                    });
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("login.guest.register Failed: {0}, {1}", err.Code, err.Message);
                });
            };
        }

        static void TestLogin()
        {
            TestGuestLogin();
            TestUserLogin();
        }

        private static void TestGetServerStatus()
        {
            client.OnConnected += (ITransfer transfer) =>
            {
                client.Request("status.server.status", (ServerStatus.ServerStatus resp) =>
                {
                    Console.WriteLine(resp);
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("Failed: {0}, {1}", err.Code, err.Message);
                });
            };

        }

        private static void TestUserLogin()
        {
            var userName = "jennal11";
            var passWord = "1234";

            client.OnConnected += (ITransfer transfer) =>
            {
                client.Request("login.user.checkusername", "abcd", (bool resp) =>
                {
                    Console.WriteLine("Success: {0}", resp);
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("Failed: {0}, {1}", err.Code, err.Message);
                });

                client.Request("login.user.register", new LoginRequest {
                    Username = userName,
                    Password = passWord
                }, (LoginResponse resp) =>
                {
                    Console.WriteLine("login.user.register Success: {0}, {1}", resp.UserToken, resp.Power);
                    client.Request("login.user.loginbytoken", new LoginTokenRequest
                    {
                        UserToken = resp.UserToken
                    }, (LoginResponse loginResp) =>
                    {
                        Console.WriteLine("login.user.loginbytoken Success: {0}, {1}", resp.UserToken, resp.Power);
                    }, (ErrorMessage err) =>
                    {
                        Console.WriteLine("login.user.loginbytoken Failed: {0}, {1}", err.Code, err.Message);
                    });

                    client.Request("login.user.login", new LoginRequest
                    {
                        Username = userName,
                        Password = passWord
                    }, (LoginResponse loginResp) =>
                    {
                        Console.WriteLine("login.user.login Success: {0}, {1}", resp.UserToken, resp.Power);
                    }, (ErrorMessage err) =>
                    {
                        Console.WriteLine("login.user.login Failed: {0}, {1}", err.Code, err.Message);
                    });
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("login.user.register Failed: {0}, {1}", err.Code, err.Message);
                });
            };
        }

        private static void TestGuestLogin()
        {
            client.OnConnected += (ITransfer transfer) =>
            {
                client.Request("login.guest.register", new RegistGuestRequest { }, (LoginResponse resp) =>
                {
                    Console.WriteLine("login.guest.register Success: {0}, {1}", resp.UserToken, resp.Power);
                    client.Request("login.guest.login", new LoginTokenRequest
                    {
                        UserToken = resp.UserToken
                    }, (LoginResponse loginResp) =>
                    {
                        Console.WriteLine("login.guest.login Success: {0}, {1}", resp.UserToken, resp.Power);
                    }, (ErrorMessage err) =>
                    {
                        Console.WriteLine("login.guest.login Failed: {0}, {1}", err.Code, err.Message);
                    });
                }, (ErrorMessage err) =>
                {
                    Console.WriteLine("login.guest.register Failed: {0}, {1}", err.Code, err.Message);
                });
            };
        }

        static void Main(string[] args)
        {
            //ConnectJsonClient();
            ConnectProtoClient();

            Console.ReadKey();
        }

        private static void ConnectJsonClient()
        {
            client.OnError += Client_OnError;
            //TestLogin();
            TestGetServerStatus();
            client.Connect("192.168.1.200", 24680);
            //client.Connect("", 24680);

            //client.OnDisconnected += Client_OnDisconnected;
            //client.OnConnected += Client_OnConnected;

            //client.On("echo.push", client, (string str) =>
            //{
            //    Console.WriteLine("On Push: {0}", str);
            //});
            //client.Connect("", 1234);
        }

        static void ConnectProtoClient()
        {
            pclient.OnError += Client_OnError;
            //TestGetProtoServerStatus();
            TestProtoLogin();
            pclient.Connect("", 24680);
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
