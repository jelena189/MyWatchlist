using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWatchlist.DomainModel
{
    public class Creator
    {
        public long id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }

   
}
