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
using Neo4jClient;
using Neo4jClient.Cypher;

namespace MyWatchlist
{
    public partial class UserForm : Form
    {
        private DomainModel.User _user;
        public UserForm(DomainModel.User user)
        {
            InitializeComponent();
            _user = user;
            panel1.BackColor = Color.LightSeaGreen;
            lblIme.Text = user.firstName;
            lblMail.Text = user.email;
            lblPrezime.Text = user.lastName;
            lbSveSerije.Items.Clear();
            lbSveSerije.Items.AddRange(DataProvider.getAvailableTVShows(_user).ToArray());
            lbPTW.Items.Clear();
            lbPTW.Items.AddRange(DomainModel.DataProvider.planToWatchFunc(_user).ToArray());
            lbWatched.Items.Clear();
            lbWatched.Items.AddRange(DomainModel.DataProvider.WatchedFunc(_user).ToArray());
            comboBox1.Items.AddRange(DataProvider.getGenres().ToArray());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TVShow tv = (TVShow)lbSveSerije.SelectedItem; 
            DomainModel.DataProvider.addPlanToWatch(_user, tv);
            lbPTW.Items.Clear();
            lbPTW.Items.AddRange(DataProvider.planToWatchFunc(_user).ToArray());
            lbSveSerije.Items.Clear();
            lbSveSerije.Items.AddRange(DataProvider.getAvailableTVShows(_user).ToArray());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (lbPTW.SelectedIndex != -1)
            {
                TVShow tv = (TVShow)lbPTW.SelectedItem;
                DomainModel.DataProvider.addWatched(_user, tv);
                lbWatched.Items.Clear();
                lbWatched.Items.AddRange(DataProvider.WatchedFunc(_user).ToArray());
                DomainModel.DataProvider.deletePlanToWatch(_user, tv);

                lbPTW.Items.Clear();
                lbPTW.Items.AddRange(DataProvider.planToWatchFunc(_user).ToArray());
            }
            else
                MessageBox.Show("Select tv show!");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (lbPTW.SelectedIndex != -1)
            {
                TVShow tv = (TVShow)lbPTW.SelectedItem;
            DomainModel.DataProvider.deletePlanToWatch(_user, tv);

            lbPTW.Items.Clear();
            lbPTW.Items.AddRange(DataProvider.planToWatchFunc(_user).ToArray());
            lbSveSerije.Items.Clear();
            lbSveSerije.Items.AddRange(DataProvider.getAvailableTVShows(_user).ToArray());
            }
            else
                MessageBox.Show("Select tv show!");
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != string.Empty)
            {
                string title = txtTitle.Text;
                if (DataProvider.findTvShow(title, _user) != null)
                {
                    lbSveSerije.Items.Clear();
                    lbSveSerije.Items.AddRange(DataProvider.findTvShow(title, _user).ToArray());
                }
            }
            else
                MessageBox.Show("Enter tv show title!");
        }

        private void btnActor_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                string[] tekst = txtName.Text.Split(' ');
                string actorName = tekst[0];
                if (DataProvider.getShowsWithActor(actorName, _user) != null)
                { 
                    lbSveSerije.Items.Clear();
                    lbSveSerije.Items.AddRange(DataProvider.getShowsWithActor(actorName, _user).ToArray());
                }
            }
            else
                MessageBox.Show("Enter actors name!");
        }

        private void alltvshosbtn_Click(object sender, EventArgs e)
        {
            lbSveSerije.Items.Clear();
            lbSveSerije.Items.AddRange(DataProvider.getAvailableTVShows(_user).ToArray());
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (lbSveSerije.SelectedIndex != -1)
            {
                TVShow tv = (TVShow)lbSveSerije.SelectedItem;
                TVShowDetails details = new TVShowDetails(tv);
                details.ShowDialog();
            }
            else
                MessageBox.Show("Select tv show!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtReleased.Text != string.Empty)
            {
                string year = txtReleased.Text;
                if (DataProvider.findTvShowReleased(year, _user) != null)
                {
                    lbSveSerije.Items.Clear();
                    lbSveSerije.Items.AddRange(DataProvider.findTvShowReleased(year, _user).ToArray());
                }
            }
            else
                MessageBox.Show("Enter year!");
        }

        private void btnRecommended_Click(object sender, EventArgs e)
        {
            string streamingService = DataProvider.getMostFrequentSService(_user);
            List<Genre> genres = DataProvider.getMostFrequentGenre(_user);
            if (DataProvider.findRecommended(streamingService, genres, _user).ToArray() != null)
            {
                lbSveSerije.Items.Clear();
                lbSveSerije.Items.AddRange(DataProvider.findRecommended(streamingService, genres, _user).ToArray());
            }
            else
                MessageBox.Show("No recommendations!");
        }

        private void btnMostPopular_Click(object sender, EventArgs e)
        {
            lbSveSerije.Items.Clear();
            lbSveSerije.Items.AddRange(DataProvider.findMostPopular(_user).ToArray());
        }

        private void btnOceni_Click(object sender, EventArgs e)
        {
            if (lbWatched.SelectedItem != null)
            {

                if (rb1.Checked == false && rb2.Checked == false && rb3.Checked == false && rb4.Checked == false &&
                    rb5.Checked == false)
                {
                    MessageBox.Show("Choose a number!");
                }
                else
                {

                    float pom = 0;
                    TVShow tv = (TVShow)lbWatched.SelectedItem;

                    bool b = DataProvider.testRelRate(_user, tv);
                    if (b)
                    {
                        if (rb1.Checked)
                            pom = 1;
                        else if (rb2.Checked)
                            pom = 2;
                        else if (rb3.Checked)
                            pom = 3;
                        else if (rb4.Checked)
                            pom = 4;
                        else if (rb5.Checked)
                            pom = 5;
                        tv.stars = (tv.stars + pom) / 2;

                        DomainModel.DataProvider.UpdateTVShow(tv);

                        MessageBox.Show("You rated the tv show successfully:" + tv.title + "\n " +
                            " current rate is :" + tv.stars);
                        DomainModel.DataProvider.addRate(_user, tv);
                    }
                    else
                    {
                        MessageBox.Show("You already rated this tv show!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose a tv show to rate!");
            }
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            lbSveSerije.Items.Clear();
            lbSveSerije.Items.AddRange(DataProvider.findBestRated(_user).ToArray());
        }



        private void btnGenre_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1)
            {
                Genre g = (Genre)comboBox1.SelectedItem;
                if (DataProvider.getShowsWithGenre(g, _user) != null)
                {
                    lbSveSerije.Items.Clear();
                    lbSveSerije.Items.AddRange(DataProvider.getShowsWithGenre(g, _user).ToArray());
                }
            }
            else
                MessageBox.Show("Enter actors name!");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
