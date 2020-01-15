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
    public partial class AddActorOrCreator : Form
    {
        private AdminAdd parent;
        private AdminUpdate parent1;
        private String type;
        private List<Award> awards;
        private Actor actor;

        public AddActorOrCreator()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(DataProvider.getActors().ToArray());

        }

        public AddActorOrCreator(AdminAdd ah, AdminUpdate au, string actorOrCreator)
        {
            InitializeComponent();
            txtFirst.Text = string.Empty;
            txtLast.Text = string.Empty;
            if (ah != null)
                parent = ah;
            else
                parent1 = au;
            type = actorOrCreator;
            listBox1.Items.Clear();
            if (type == "actor")
            {
                listBox1.Items.AddRange(Actors().ToArray());
                label3.Visible = true;
                btnAwards.Visible = true;
                awards = new List<Award>();
            }
            else
            {
                listBox1.Items.AddRange(Creators().ToArray());
                label3.Visible = false;
                btnAwards.Visible = false;
            }
        }
        
        public List<Actor> Actors()
        {
            if (parent1 != null)
                return parent1.getActors();
            else
                return DataProvider.getActors();
        }
        public List<Creator> Creators()
        {
            if (parent1 != null)
                return parent1.getCreators();
            else
                return DataProvider.getCreators();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text;
            if (DataProvider.getActor(text) != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(DataProvider.getActor(text).ToArray());
            }
            else if (DataProvider.getCreator(text) != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(DataProvider.getCreator(text).ToArray());
            }
            else MessageBox.Show("No match.");
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text != String.Empty && txtLast.Text != String.Empty)
            {
                if (type == "actor")
                {

                    actor = new Actor();
                    actor.firstName = txtFirst.Text;
                    actor.lastName = txtLast.Text;

                    DataProvider.addActor(actor, awards);

                    if (parent != null)
                    {
                        parent.addActor(actor);
                        this.Close();
                    }
                    if (parent1 != null)
                    {
                        parent1.addActor(actor);
                        this.Close();
                    }
                }
                else
                {
                    Creator creator = new Creator();
                    creator.firstName = txtFirst.Text;
                    creator.lastName = txtLast.Text;
                    DataProvider.addCreator(creator);
                    if (parent != null)
                    {
                        parent.addCreator(creator);
                        this.Close();
                    }
                    if (parent1 != null)
                    {
                        parent1.addCreator(creator);
                        this.Close();
                    }
                }
            }
            else MessageBox.Show("Enter data!");
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (type == "actor")
            {
                Actor actor = (Actor)listBox1.SelectedItem;
                if (parent != null)
                {
                    parent.addActor(actor);
                    this.Close();
                }
                if (parent1 != null)
                {
                    parent1.addActor(actor);
                    this.Close();
                }
            }
            else
            {
                Creator creator = (Creator)listBox1.SelectedItem;
                if (parent != null)
                {
                    parent.addCreator(creator);
                    this.Close();
                }
                if (parent1 != null)
                {
                    parent1.addCreator(creator);
                    this.Close();
                }
            }
        }
        public void addAward(Award a)
        {
            awards.Add(a);
            lbAwards.Items.Clear();
            lbAwards.Items.AddRange(awards.ToArray());
        }

        private void btnAwards_Click(object sender, EventArgs e)
        {
            AddAwards forma = new AddAwards(this,null, actor);
            forma.ShowDialog();
        }
    }
}
