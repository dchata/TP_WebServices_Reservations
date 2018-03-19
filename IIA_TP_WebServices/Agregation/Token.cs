using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agregation
{
    public class Token
    {
        private string access_token;
        private string token_type;
        private string expires_in;

        public string Access_token { get => access_token; set => access_token = value; }
        public string Token_type { get => token_type; set => token_type = value; }
        public string Expires_in { get => expires_in; set => expires_in = value; }
    }
}
