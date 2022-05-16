using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineSchoolBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<User> Users = new List<User>();
        public void LoadUsers()
        {
            DataTable dt = SQLProcedures.SelectUsers();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                User user = new User();
                user.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                user.Name = dt.Rows[i]["Name"].ToString();
                user.Lastname = dt.Rows[i]["LastName"].ToString();
                user.Username = dt.Rows[i]["Username"].ToString();
                user.Password = dt.Rows[i]["Password"].ToString();
                Users.Add(user);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_passwordRegister.PasswordChar = '*';
            textBox_passwordLogin.PasswordChar = '*';
            textBox_confirmPasswordRegister.PasswordChar = '*';
            LoadUsers();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            if (textBox_confirmPasswordRegister.Text == string.Empty || textBox_lastnameRegister.Text == string.Empty || textBox_nameRegister.Text == string.Empty || textBox_passwordRegister.Text == string.Empty || textBox_usernameRegister.Text == string.Empty)
                MessageBox.Show("Fill all the fields!");

            else if (textBox_confirmPasswordRegister.Text != textBox_passwordRegister.Text)
                MessageBox.Show("Passwords do not match!");
            else
            {
                SQLProcedures.InsertUser(textBox_nameRegister.Text, textBox_lastnameRegister.Text, textBox_usernameRegister.Text, textBox_passwordRegister.Text);
            }
            LoadUsers();

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            foreach(User user in Users)
            {
                if(user.Username == textBox_usernameLogin.Text && user.Password == textBox_passwordLogin.Text)
                {
                    Form2 f2 = new Form2(user);
                    f2.ShowDialog();
                    this.Hide();
                }
            }
        }
    }
}
