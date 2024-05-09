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
namespace The_recruitment_profile_management_system
{
    public partial class DN_LichSuDangKy : Form
    {
        string connectString;
        public DN_LichSuDangKy(string connStr)
        {
            connectString = connStr;
            InitializeComponent();
        }
        private void DN_LichSuDangKy_Load(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    var query = "select * from dba_users order by USERNAME";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đủ quyền hạn để truy vấn " + ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
