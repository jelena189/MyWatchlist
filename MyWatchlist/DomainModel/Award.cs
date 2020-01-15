using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWatchlist.DomainModel
{
    public class Award
    {
        public long id { get; set; }
        public string year { get; set; }
        public string award { get; set; }
        public string category { get; set; }
        public string nominatedWork { get; set; }
        public string result { get; set; }
        public Award(long id,string year, string award, string category,string nominatedWork, string result)
        {
            this.id = id;
            this.year = year;
            this.award = award;
            this.category = category;
            this.nominatedWork = nominatedWork;
            this.result = result;
        }
        public override string ToString()
        {
            return year + " - " + award + " - " + category + " - " + nominatedWork+" - "+result;
        }
        public Award() { }
    }
}
