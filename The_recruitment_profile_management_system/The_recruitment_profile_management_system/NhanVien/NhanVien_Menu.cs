using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_recruitment_profile_management_system.DuyetHoSoNhanVien;

namespace The_recruitment_profile_management_system.NhanVien_UI
{
    public partial class NhanVien_Menu : Form
    {
        string connect = null;
        public NhanVien_Menu(string Connect)
        {
            InitializeComponent();
            connect = Connect;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThongKeDoanhNghiepSapHetHan tk = new ThongKeDoanhNghiepSapHetHan(connect);
            tk.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DuyetDKDN a = new DuyetDKDN(connect);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
