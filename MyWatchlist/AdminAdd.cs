using MyWatchlist.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWatchlist
{
    public partial class AdminAdd : Form
    {
        private TVShow tvShow;
        private List<Actor> actors;
        private List<Creator> creators;
        public AdminAdd()
        {
            InitializeComponent();
            tvShow = new TVShow();
            actors = new List<Actor>();
            creators = new List<Creator>();
            lbGenres.Items.AddRange(DataProvider.getGenres().ToArray());
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files(*.jpg;*.jpeg;*.gif;*.bmp;)|*.jpg;*.gif;*.bmp;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtImage.Text = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != String.Empty && txtReleased.Text != String.Empty && txtDescription.Text != String.Empty && txtStreamingService.Text != String.Empty && txtSeasons.Text != String.Empty)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string path = Directory.GetParent(workingDirectory).Parent.FullName;
                path = path + "\\Images\\";
                string fileName = Path.GetFileName(txtImage.Text);
                File.Copy(txtImage.Text, Path.Combine(@path, fileName), true);

                tvShow.title = txtTitle.Text;
                tvShow.released = txtReleased.Text;
                tvShow.img = fileName;
                tvShow.seasons = txtSeasons.Text;
                tvShow.streamingService = txtStreamingService.Text;
                tvShow.stars = 0;
                tvShow.description = txtDescription.Text;
                List<Genre> genres = new List<Genre>();
                foreach (Genre g in lbGenres.SelectedItems)
                {
                    genres.Add(g);
                }
                
                bool b = DataProvider.addTVShow(tvShow, actors, creators,genres);
                if (b)
                {
                    MessageBox.Show("TV show with actors and creators added to database.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error.");
                }
            }
            else
            {
                MessageBox.Show("Morate popuniti sva polja!");
            }
        }

        private void btnActors_Click(object sender, EventArgs e)
        {
            AddActorOrCreator forma = new AddActorOrCreator(this, null,"actor");
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

        private void btnCreators_Click(object sender, EventArgs e)
        {
            AddActorOrCreator forma = new AddActorOrCreator(this,null, "creator");
            forma.ShowDialog();
        }
    }
}
