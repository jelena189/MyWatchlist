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

namespace MyWatchlist
{
    public partial class AdminUpdate : Form
    {
        private TVShow tvshow;
        private List<Actor> actors;
        private List<Creator> creators;
        

        public AdminUpdate()
        {
            InitializeComponent();
            actors = new List<Actor>();
            creators = new List<Creator>();
        }

        public AdminUpdate(TVShow tv)
        {
            InitializeComponent();
            this.tvshow = tv;
            actors = new List<Actor>();
            creators = new List<Creator>();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSeasons.Text != String.Empty)
                tvshow.seasons = txtSeasons.Text;
            if (txtDescription.Text != String.Empty)
                tvshow.description = txtDescription.Text;

            foreach (Actor a in actors)
            {
                DataProvider.TVShowActor(tvshow, a);
            }
            foreach(Creator c in creators)
            {
                DataProvider.TVShowCreator(tvshow, c);
            }

            if (!DataProvider.UpdateTVShow(tvshow))
                MessageBox.Show("Error.");
            else
            {
                MessageBox.Show("TV show updated.");
                this.Close();
            }
        }

        private void btnActor_Click(object sender, EventArgs e)
        {
            AddActorOrCreator forma = new AddActorOrCreator(null, this, "actor");
            forma.ShowDialog();
        }

        private void btnCreator_Click(object sender, EventArgs e)
        {
            AddActorOrCreator forma = new AddActorOrCreator(null, this, "creator");
            forma.ShowDialog();
        }

        public void addActor(Actor a)
        {
            actors.Add(a);
            lbActors.Items.Clear();
            lbActors.Items.AddRange(actors.ToArray());
        }

        public void addCreator(Creator c)
        {
            creators.Add(c);
            lbCreators.Items.Clear();
            lbCreators.Items.AddRange(creators.ToArray());
        }

        public List<Actor> getActors()
        {
            return DataProvider.getAvailableActors(tvshow);
        }

        public List<Creator> getCreators()
        {
            return DataProvider.getAvailableCreators(tvshow);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Actor actor = (Actor)lbActors.SelectedItem;
        //    AddAwards forma = new AddAwards(null,this, actor);
        //    forma.ShowDialog();
        //    if (!DataProvider.ActorAward(actor, award))
        //        MessageBox.Show("Error.");
        //    else
        //        MessageBox.Show("Award added successfully.");
        //}
        //public void addAward(Award award)
        //{
        //    this.award = award;
        //}
    }
}
