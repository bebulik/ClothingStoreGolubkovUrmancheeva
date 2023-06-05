using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStoreGolubkovUrmancheeva.ClassHelper
{
    public class ClientLogPass
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public ClientLogPass(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
