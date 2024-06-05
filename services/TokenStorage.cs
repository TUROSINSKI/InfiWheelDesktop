using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace InfiWheelDesktop.services
{
    public class TokenManager
    {
        private static TokenManager _instance;
        private static readonly object _lock = new object();
        private string _token;

        private TokenManager() { }

        public static TokenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TokenManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetToken(string token)
        {
            _token = token;
        }

        public string GetToken()
        {
            return _token;
        }

        public void ClearToken()
        {
            _token = null;
        }
    }

}
