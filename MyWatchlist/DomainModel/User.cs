using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWatchlist.DomainModel
{
    public class User
    {
        public long id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String password { get; set; }


        public User(long id, string fn, string ln, string em, string pass)
        {
            this.id = id;
            this.firstName = fn;
            this.lastName = ln;
            this.email = em;
            this.password = pass;
        }

        public User() {

        }
    }
}
