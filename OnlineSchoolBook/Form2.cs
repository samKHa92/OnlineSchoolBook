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
    public partial class Form2 : Form
    {
        private User CurrentUser;
        public Form2(User user)
        {
            InitializeComponent();
            this.CurrentUser = user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
