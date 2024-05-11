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
            // textbox1
            if (textBox1.Text == "Tên Công Ty")
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Vui lòng nhập tên công ty";
                valid = false;
            }
            else if (textBox1.Text.Length >= 50 )
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Tối đa chỉ nhập 50 ký tự!!!";
                valid = false;
            }
            else
            {
                label2.Text = "";
            } 
            //textbox2
            if (textBox2.Text == "Mã số thuế")
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Vui lòng nhập mã số thuế của công ty";
                valid = false;
            }
            else if (textBox2.Text.Length >= 8)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Tối đa chỉ nhập 8 ký tự!!!";
                valid = false;
            }
            else
            {
                label3.Text = "";
            }
            //textbox3
            if (textBox3.Text == "Người đại diện")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Vui lòng nhập tên người đai diện";
                valid = false;
            }
            else if (textBox3.Text.Length >= 50)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Tối đa chỉ nhập 50 ký tự!!!";
                valid = false;
            }
            else
            {
                label4.Text = "";
            }
            //textbox4
            if (textBox4.Text == "Địa chỉ")
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Vui lòng nhập Địa chỉ";
                valid = false;
            }
            else if (textBox4.Text.Length >= 50)
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Tối đa chỉ nhập 50 ký tự!!!";
                valid = false;
            }
            else
            {
                label5.Text = "";
            }
            //textbox5
            if (textBox5.Text == "Email (VD: ABC@gmail.com)")
            {
                label6.ForeColor = Color.Red;
                label6.Text = "Vui lòng nhập Email";
                valid = false;
            }
            else if (textBox5.Text.Length >= 50)
            {
                label6.ForeColor = Color.Red;
                label6.Text = "Tối đa chỉ nhập 50 ký tự!!!";
                valid = false;
            }
            else
            {
                label6.Text = "";
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
                        string query = "insert into DoanhNghiep values ('DN" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox1.Text + "')";
                        OracleCommand cmd = new OracleCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        OracleCommand proc = new OracleCommand();
                        proc.Connection = conn;
                        proc.CommandText = "USP_CREATEUSER_DN";
                        proc.CommandType = CommandType.StoredProcedure;
                        proc.ExecuteNonQuery(); 
                        
                    }
                    MessageBox.Show("Đăng ký thành công", "Thông Báo");
                    MessageBox.Show("Vui lòng đợi nhân viên liên lạc để xác thực lại thông tin", "Thông Báo");
                    this.Close();
                }
                catch (Exception ex)
                {
                   if (ex.Message == "ORA-00001: unique constraint (SYS.SYS_C008618) violated")
                        MessageBox.Show("Mã số thuế đã tồn tại" ,"Lỗi",MessageBoxButtons.OK);
                   else
                        MessageBox.Show("Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK);
                }
            }
        }
    }
}
