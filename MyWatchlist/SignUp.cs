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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text != String.Empty && txtLast.Text != String.Empty && txtEmail.Text != String.Empty && txtPassword.Text != String.Empty)
            {
                User u = new User(0, txtFirst.Text, txtLast.Text, txtEmail.Text, txtPassword.Text);
                if (DataProvider.addUser(u))
                {
                    MessageBox.Show("Uspesna registracija, sada se mozete ulogovati.");
                    this.Close();
                }
                else
                    MessageBox.Show("Registracija nije uspela, unesite parametre ponovo.");
            }
            else
            {
                MessageBox.Show("Unesite sve parametre.");
            }
        }
    }
}
