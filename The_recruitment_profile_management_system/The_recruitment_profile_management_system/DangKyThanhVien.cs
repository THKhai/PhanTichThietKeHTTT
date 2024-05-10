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
    public partial class DangKyThanhVien : Form
    {
        public DangKyThanhVien()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DangKyThanhVien_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Tên Công Ty";
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Tên Công Ty")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }
    }
}
