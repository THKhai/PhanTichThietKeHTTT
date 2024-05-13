using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;

namespace The_recruitment_profile_management_system
{
    public partial class DN_LichSuDangKy : Form
    {
        string connectString;
        string MST;
        public DN_LichSuDangKy(string connStr, string MaSoThue)
        {
            connectString = connStr;
            MST = MaSoThue;
            InitializeComponent();
        }
        private void DN_LichSuDangKy_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.HideSelection = true;

            label3.Hide();
            label4.Hide(); 
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    var query = "select tt.* from sys.ThongTinDangTuyen tt join sys.QuangCao qc on tt.MaTTDT = qc.MaTTDT where upper(qc.MaSoThue) = '" + MST + "'";
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
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
    {
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                try
                {
                    using (OracleConnection conn = new OracleConnection(connectString))
                    {
                        string query = "select qc.* from sys.ThongTinDangTuyen tt join sys.QuangCao qc on tt.MaTTDT = qc.MaTTDT where upper(qc.MaSoThue) = '" + MST + "'";
                        OracleCommand cmd = new OracleCommand(query, conn);

                        // Add parameter for YourVariable
                        //cmd.Parameters.Add(":YourVariable", OracleDbType.Varchar2).Value = yourVariable;

                        // Open the connection
                        conn.Open();

                        // Execute the command and retrieve the result into a OracleDataReader
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string column1Value = reader.GetString(0);
                                string column2Value = reader.GetString(1);
                                string column3Value = reader.GetString(2);
                                string column4Value = reader.GetString(3);
                                string column5Value = reader.GetString(4);

                                label3.Text = "Mã số thuế: " + column1Value;
                                label4.Text = "Mã TTDT: " + column2Value;
                                label5.Text = "Hình thức đăng tuyển: " + column3Value;
                                label6.Text = "Hình thức thanh toán: " + column4Value;
                                label7.Text = "Tổng tiền: " + column5Value + " đ";

                                label3.Show();
                                label4.Show();
                                label5.Show();
                                label6.Show();
                                label7.Show();
                                label8.Show();
                                label9.Show();
                            }
                            else
                            {
                                label3.Hide();
                                label4.Hide();
                                label5.Hide();
                                label6.Hide();
                                label7.Hide();
                                label8.Hide();
                                label9.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //MessageBox.Show("Clicked cell value: " + cellValue.ToString());
            }
        }
    }
}
