using MyWatchlist.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;
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
    public partial class Form1 : Form
    {
        public static GraphClient client;
        
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            DataProvider.Connect();
        }
       
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string serija = "The Witcher";

        //    Dictionary<string, object> queryDict = new Dictionary<string, object>();
        //    queryDict.Add("serija", serija);

        //    var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Series) and exists(n.title) and n.title =~ {serija} return n",
        //                                                    queryDict, CypherResultMode.Set);

        //    List<TVShow> ss = ((IRawGraphClient)client).ExecuteGetCypherResults<TVShow>(query).ToList();
        //    TVShow tv = ss.FirstOrDefault();
        //    pictureBox1.ImageLocation = tv.img;
        //    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        //    MessageBox.Show(tv.title);


        //}

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                Admin admin = new Admin(txtUsername.Text, txtPassword.Text);
                if(DataProvider.findAdmin(admin))
                {
                    AdminHome ah = new AdminHome();
                    ah.ShowDialog();
                }
                else
                    MessageBox.Show("Pogresni podaci.");
            }
            else
            {
                DomainModel.User user = DataProvider.findUser(txtUsername.Text, txtPassword.Text);
                if (user != null)
                {
                    //DomainModel.User u = new User();
                    //u.email = txtUsername.Text;
                    //u.password = txtPassword.Text;
                    UserForm uf = new UserForm(user);
                    uf.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Korisnik ne postoji,molimo Vas registrujte se.");

                }

            }

        }
    }
}
