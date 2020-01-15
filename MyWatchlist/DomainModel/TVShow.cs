using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWatchlist.DomainModel
{
    public class TVShow
    {
        public long id { get; set; }
        public String title { get; set; }
        public String released { get; set; }
        public String[] genres { get; set; }
        public String description { get; set; }
        public String streamingService { get; set; }
        public float stars { get; set; }
        public String img { get; set; }
        public String seasons { get; set; }
        //public List<Actor> actors { get; set; }
        //public List<Creator> creators { get; set; }

        public TVShow() {
            //this.actors = new List<Actor>();
            //this.creators = new List<Creator>();
        }

        public TVShow(String title, String released, string[] genres, string description, string ss, float stars, string img, string seasons)
        {
            this.title = title;
            this.released = released;
            this.genres = genres;
            this.description = description;
            this.streamingService = ss;
            this.stars = stars;
            this.img = img;
            this.seasons = seasons;
            //this.actors = new List<Actor>();
            //this.creators = new List<Creator>();
        }
        public override string ToString()
        {
            return title;
        }
        public string genresToString()
        {
            return string.Join(", ", this.genres);
        }
    }
}
