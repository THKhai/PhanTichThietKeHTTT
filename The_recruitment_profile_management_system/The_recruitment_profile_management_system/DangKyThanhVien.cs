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
    public partial class DangKyThanhVien : Form
    {
        string ConnectionStr = string.Empty;
        public DangKyThanhVien(string ConnectStr)
        {
            ConnectionStr = ConnectStr;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DangKyThanhVien_Load(object sender, EventArgs e)
        {
            textBox1.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
            textBox4.TabStop = false;
            textBox5.TabStop = false;
            textBox1.Text = "Tên Công Ty";
            textBox2.Text = "Mã số thuế";
            textBox3.Text = "Người đại diện";
            textBox4.Text = "Địa chỉ";
            textBox5.Text = "Email (VD: ABC@gmail.com)";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Tên Công Ty";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Tên Công Ty")
            {
                textBox1.Text = "";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Mã số thuế";
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Mã số thuế")
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "Người đại diện";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Người đại diện")
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Địa chỉ";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Địa chỉ")
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                textBox5.Text = "Email (VD: ABC@gmail.com)";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Email (VD: ABC@gmail.com)")
            {
                textBox5.Text = "";
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.TabStop == false)
            {
                textBox1.TabStop = true;
                textBox2.TabStop = true;
                textBox3.TabStop = true;
                textBox4.TabStop = true;
                textBox5.TabStop = true;
            } 
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if(textBox1.TabStop == false)
            {
                textBox1.TabStop = true;
                textBox2.TabStop = true;
                textBox3.TabStop = true;
                textBox4.TabStop = true;
                textBox5.TabStop = true;
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.TabStop == false)
            {
                textBox1.TabStop = true;
                textBox2.TabStop = true;
                textBox3.TabStop = true;
                textBox4.TabStop = true;
                textBox5.TabStop = true;
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox1.TabStop == false)
            {
                textBox1.TabStop = true;
                textBox2.TabStop = true;
                textBox3.TabStop = true;
                textBox4.TabStop = true;
                textBox5.TabStop = true;
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox1.TabStop == false)
            {
                textBox1.TabStop = true;
                textBox2.TabStop = true;
                textBox3.TabStop = true;
                textBox4.TabStop = true;
                textBox5.TabStop = true;
            }
        }
        private  bool CheckValidTextBox()
        {
            Boolean valid = true;
            if (textBox1.Text == "Tên Công Ty")
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Vui lòng nhập tên công ty";
                valid = false;
            }
            if (textBox2.Text == "Mã số thuế")
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Vui lòng nhập mã số thuế của công ty";
                valid = false;
            }
            if (textBox3.Text == "Người đại diện")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Vui lòng nhập tên người đai diện";
                valid = false;
            }
            if (textBox4.Text == "Địa chỉ")
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Vui lòng nhập Địa chỉ";
                valid = false;
            }
            if (textBox5.Text == "Email (VD: ABC@gmail.com)")
            {
                label6.ForeColor = Color.Red;
                label6.Text = "Vui lòng nhập Email";
                valid = false;
            }
            return valid;
        }
        private void button1_Click(object sender, EventArgs e)
        {  if (this.CheckValidTextBox())
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(ConnectionStr))
                    {
                        conn.Open();
                        string query = "insert into DoanhNghiep values ('DN" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                        OracleCommand cmd = new OracleCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        OracleCommand proc = new OracleCommand("USP_CREATEUSER_DN", conn);
                        proc.CommandType = CommandType.StoredProcedure;
                        
                    }
                    MessageBox.Show("Đăng ký thành công", "Thông Báo");
                    MessageBox.Show("Vui lòng đợi nhân viên liên lạc để xác thực lại thông tin", "Thông Báo");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi!" + ex.Message ,"Lỗi",MessageBoxButtons.OK);
                }
            }
        }
    }
}
