using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace The_recruitment_profile_management_system.DuyetHoSoNhanVien
{
    public partial class DuyetDKDN : Form
    {
        string current = string.Empty;
        string connectstr = string.Empty;   
        public DuyetDKDN(string ConnectStr)
        {
            connectstr = ConnectStr;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (OracleConnection conn = new OracleConnection(connectstr))
                {
                    conn.Open();
                    string query = "grant connect to " + current.ToUpper();
                    OracleCommand cmd = new OracleCommand(query,conn);
                    cmd.ExecuteNonQuery();
                }

                this.load_table();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi" + ex.Message);
            }
        }
        private void load_table()
        {
            try
            {
                    using (OracleConnection conn = new OracleConnection(connectstr))
                    {
                        conn.Open();
                        string query = "select* from sys.v_NV_NEWDN";
                        OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi" + ex.Message);
            }
        }
        private void DuyetDKDN_Load(object sender, EventArgs e)
        {
            load_table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            current = dataGridView1.Rows[e.RowIndex].Cells["MaSoThue"].Value.ToString();
            label2.Text = current;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            current = dataGridView1.Rows[e.RowIndex].Cells["MaSoThue"].Value.ToString();
            label2.Text = current;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectstr))
                {
                    conn.Open();
                    string query = "delete from SYS.DoanhNghiep where MaSoThue = '" + current +"'";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    string query2 = "Drop user " + current.ToUpper();
                    OracleCommand cmd1 = new OracleCommand(query, conn);
                    cmd1.ExecuteNonQuery();
                }
                this.load_table();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi" + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
