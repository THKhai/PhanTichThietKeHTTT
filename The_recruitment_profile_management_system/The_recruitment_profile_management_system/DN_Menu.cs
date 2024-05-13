using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace The_recruitment_profile_management_system
{
    public partial class DN_Menu : Form
    {
        string connectString;
        string MST;
        public DN_Menu(string conStr, string MaSoThue)
        {
            connectString = conStr;
            MST = MaSoThue;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DN_Dangkytuyendung dktd= new DN_Dangkytuyendung(connectString, MST);
            dktd.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DN_LichSuDangKy ls = new DN_LichSuDangKy(connectString, MST);
            ls.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DN_Menu_Load(object sender, EventArgs e)
        {
            /*try
            {
                using (OracleConnection conn = new OracleConnection(connectString))
                {
                    string query1 = "SELECT MAX(CAST(SUBSTR(MaTTDT, 3, LENGTH(MaTTDT) - 2) AS INT)) AS MaxValue FROM sys.ThongTinDangTuyen";
                    OracleCommand cmd = new OracleCommand(query1, conn);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    int maxValue = 0;
                    maxValue = Convert.ToInt32(result);
                    label1.Text = maxValue.ToString();
                    conn.Close();

                    MessageBox.Show("Thêm Thành Công! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
    }
}
