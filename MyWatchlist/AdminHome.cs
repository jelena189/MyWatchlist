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
    public partial class AdminHome : Form
    {
        private Award award;
        public AdminHome()
        {
            InitializeComponent();
            lbTVshows.Items.Clear();
            lbTVshows.Items.AddRange(DataProvider.getTVShows().ToArray());
            lbActors.Items.Clear();
            lbActors.Items.AddRange(DataProvider.getActors().ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminAdd ah = new AdminAdd();
            ah.ShowDialog();
            lbTVshows.Items.Clear();
            lbTVshows.Items.AddRange(DataProvider.getTVShows().ToArray());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TVShow tv = (TVShow)lbTVshows.SelectedItem;
            if(!DataProvider.deleteTVshow(tv))
                MessageBox.Show("Error.");
            else
                MessageBox.Show("TV show deleted from database.");
            lbTVshows.Items.Clear();
            lbTVshows.Items.AddRange(DataProvider.getTVShows().ToArray());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TVShow tv = (TVShow)lbTVshows.SelectedItem;
            AdminUpdate au = new AdminUpdate(tv);
            au.ShowDialog();
        }

        private void btnAward_Click(object sender, EventArgs e)
        {
            Actor actor = (Actor)lbActors.SelectedItem;
            AddAwards forma = new AddAwards(null, this, actor);
            forma.ShowDialog();
            if (this.award != null)
            {
                if (!DataProvider.addAward(award))
                    MessageBox.Show("Error.");
                else if (!DataProvider.ActorAward(actor, award))
                    MessageBox.Show("Error.");
                else
                    MessageBox.Show("Award added successfully.");
            }
            else
                MessageBox.Show("Award not added.");
        }

        public void addAward(Award award)
        {
            this.award = award;
        }
    }
}
