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
    public partial class AddAwards : Form
    {
        private AddActorOrCreator parent1;
        private AdminHome parent2;
        private Actor actor;
        public AddAwards()
        {
            InitializeComponent();
        }

        public AddAwards(AddActorOrCreator p1,AdminHome p2,Actor a)
        {
            InitializeComponent();
            parent1 = p1;
            parent2 = p2;
            actor = a;
            txtYear.Text = String.Empty;
            txtAward.Text=String.Empty;
            txtResult.Text= String.Empty;
            txtNominated.Text= String.Empty;
            txtCategory.Text= String.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAward.Text != String.Empty && txtCategory.Text != String.Empty && txtNominated.Text != String.Empty && txtResult.Text != String.Empty && txtYear.Text != String.Empty)
            {
                Award award = new Award(0, txtYear.Text, txtAward.Text, txtCategory.Text, txtNominated.Text, txtResult.Text);
                if (parent1 != null)
                {
                    parent1.addAward(award);
                    this.Close();
                }
                else
                { 
                parent2.addAward(award);
                this.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter data!");
            }
            
        }

    }
}
