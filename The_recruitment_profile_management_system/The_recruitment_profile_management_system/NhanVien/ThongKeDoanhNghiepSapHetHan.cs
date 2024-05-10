using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không thể in được danh sách rỗng");
            }   
            else
            {
                MessageBox.Show("In Thành công");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(connect))
                {
                    var query = "select * from sys.v_NhanVien_DoanhNghiepSapHetHan";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch 
            {
                MessageBox.Show("Thao Tác Thất bại");
            }
        }
    }
}
