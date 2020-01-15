using MyWatchlist.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWatchlist.DomainModel;
using System.IO;

namespace MyWatchlist
{
    public partial class TVShowDetails : Form
    {
        private TVShow tv;
        private List<Actor> actors;
        private List<Creator> creators;
        public TVShowDetails()
        {
            InitializeComponent();
        }

        public TVShowDetails(TVShow tv)
        { 
            InitializeComponent();
            this.tv = tv;
            this.actors = DataProvider.getActorsFromShow(tv);
            this.creators = DataProvider.getCreatorsFromShow(tv);
            lTitle.Text = tv.title;
            lblDescription.Text = tv.description;
            lblReleased.Text = tv.released;
            lblSeasons.Text = tv.seasons;
            lblStreaming.Text = tv.streamingService;
            lblGenres.Text = getGenres(tv);
            lblRating.Text = tv.stars.ToString();
            ucitajSliku();
            loadActors();
            loadCreators();
        }
        public string getGenres(TVShow tv)
        {
            List<Genre> genres = DataProvider.getGenresFromShow(tv);
            string tekst = "";
            tekst = genres[0].ToString();
            foreach (Genre g in genres.Skip(1))
            {
                tekst = tekst + ", " + g.ToString();
            }
            return tekst;
        }
        public void loadActors()
        {
            string tekst = "";
            string s = "";
            foreach (Actor a in actors)
            {
                if (actors.IndexOf(a) == 0)
                    s = a.ToString();
                else
                    s = "," + a.ToString();
                tekst = tekst + s;
            }
            lblActors.Text = tekst;
        }
        public void loadCreators()
        {
            string tekst = "";
            string s = "";
            foreach (Creator c in creators)
            {
                if (creators.IndexOf(c) == 0)
                    s =c.ToString();
                else
                    s = "," + c.ToString();
                tekst = tekst + s;
            }
            lblCreators.Text = tekst;
        }
        public void ucitajSliku()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + "\\Images\\"+tv.img;
            pictureBox1.Image = new Bitmap(path);
        }

        private void btnAwards_Click(object sender, EventArgs e)
        {
            //string tekst = "";
            //tekst = actors[0].awardsDisplay();
            //foreach (Actor a in actors.Skip(1))
            //{
            //    tekst = tekst + "\n" + a.awardsDisplay();
            //}
            //lblAwards.Text = tekst;
            //lblAwards.Visible = true;
            
            //List<Award> awards= DataProvider.getAwardsForActor(actors[0]);
            List<string> tekst=new List<string>(); 
            //tekst[0]= actors[0].ToString();
            //foreach (Award aw in awards)
            //{
            //    tekst[0] = tekst[0] +  " \n " + aw.ToString();
            //}
            string pom = "";
            foreach (Actor a in actors)
            {
                pom = " \n " + a.ToString()+":";
                List<Award> awards= DataProvider.getAwardsForActor(a);
                foreach (Award award in awards)
                {
                   pom = pom + "\n" + award.ToString();
                }
                tekst.Add(pom);
            }
            lblAwards.Text = string.Join("\n",tekst);
            lblAwards.Visible = true;
        }

        private void TVShowDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
