using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole.Login
{
    public class RegistGuestRequest
    {
    }

    public class LoginTokenRequest
    {
        public string UserToken;
    }

    public class LoginRequest
    {
        public string Username;
        public string Password;
    }

    public class LoginResponse
    {
        public string UserToken;
        public int Power;
    }
}
