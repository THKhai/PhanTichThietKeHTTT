using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_recruitment_profile_management_system.NhanVien_UI
{
    public partial class ThongKeDoanhNghiepSapHetHan : Form
    {
        string connect = null;
        public ThongKeDoanhNghiepSapHetHan(string conn)
        {
            InitializeComponent();
            connect = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
