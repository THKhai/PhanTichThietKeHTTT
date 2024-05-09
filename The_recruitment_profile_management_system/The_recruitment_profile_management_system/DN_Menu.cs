using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_recruitment_profile_management_system
{
    public partial class DN_Menu : Form
    {
        string connectString;
        public DN_Menu(string conStr)
        {
            connectString = conStr;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DN_Dangkytuyendung dktd= new DN_Dangkytuyendung(connectString);
            dktd.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
