using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWatchlist.DomainModel
{
    public class Admin
    {
        public String Email { get; set; }
        public String Password { get; set; }

        public Admin() { }

        public Admin(String email, String sifra)
        {
            this.Email = email;
            this.Password = sifra;
        }
    }
}
