using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWatchlist.DomainModel
{
    public class Genre
    {
        public String name { get; set; }
        public Genre() { }
        public Genre(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
