using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Oracle.ManagedDataAccess.Client;

namespace The_recruitment_profile_management_system
{
    public partial class DN_Dangkytuyendung : Form
    {
        string connectString;
        string MST;
        int step = 1;
        public DN_Dangkytuyendung(string conStr, string MaSoThue)
        {
            connectString = conStr;
            MST = MaSoThue;
            InitializeComponent();
        }
        private void DN_Dangkytuyendung_Load(object sender, EventArgs e)
        {
            label7.Hide();
            comboBox1.Hide();
            label8.Hide();
            comboBox2.Hide();

            label10.Hide();
            label11.Hide();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Add("Bao Giay");
            comboBox1.Items.Add("Banner");
            comboBox1.Items.Add("Mang");

            comboBox2.Items.Add("Chuyen Khoan");
            comboBox2.Items.Add("Tien Mat");

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (step == 1)
            {
                if (dateTimePicker1.Value == dateTimePicker2.Value)
                {
                    MessageBox.Show("Ngày bắt đầu không được sau ngày kết thúc", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(richTextBox1.Text))
                {
                    MessageBox.Show("Không được bỏ trống các ô", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (int.TryParse(textBox1.Text, out int value))
                {
                    if (value < 0)
                    {
                        MessageBox.Show("Giá trị số lược không hợp lệ", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    step++;
                    label1.Text = "Đăng ký quảng cáo";
                    label2.Hide();
                    textBox1.Hide();
                    label3.Hide();
                    textBox2.Hide();
                    label4.Hide();
                    dateTimePicker1.Hide();
                    label5.Hide();
                    dateTimePicker2.Hide();
                    label6.Hide();
                    richTextBox1.Hide();

                    label7.Show();
                    comboBox1.Show();

                }
            }
            else if (step == 2)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn hình thức đăng tuyển", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    step++;
                    label1.Text = "Thanh toán";
                    button2.Text = "Đăng ký";
                    label7.Hide();
                    comboBox1.Hide();
                    label8.Hide();
                    comboBox2.Hide();

                    label8.Show();
                    comboBox2.Show();

                    label10.Show();
                    label11.Show();
                }
            }
            else if (step == 3)
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn hình thức thanh toán", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        using (OracleConnection conn = new OracleConnection(connectString))
                        {

                            string query1 = "select MAX(CAST(substr(MaTTDT, 3, length(MaTTDT) - 2) AS INT)) AS MaxValue FROM sys.ThongTinDangTuyen";
                            OracleCommand cmd1 = new OracleCommand(query1, conn);

                            conn.Open();
                            object result = cmd1.ExecuteScalar();
                            int maxMaTTDT = 0;
                            maxMaTTDT = Convert.ToInt32(result);
                            maxMaTTDT++;
                            string formattedNumber = maxMaTTDT.ToString("D8");
                            string newMaTTDT = "DT" + formattedNumber;
                            conn.Close();

                            string query2 = "insert into sys.ThongTinDangTuyen values ('"
                                + newMaTTDT + "','"
                                + textBox2.Text.ToString() + "', to_date('"
                                + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', 'YYYY-MM-DD'), to_date('"
                                + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', 'YYYY-MM-DD') ,'"
                                + textBox1.Text.ToString() + "','"
                                + richTextBox1.Text.ToString() +"', 2)";
                            string query3 = "insert into sys.QuangCao values ('" +
                                MST + "','" +
                                newMaTTDT + "','" +
                                comboBox1.SelectedItem.ToString() + "','" +
                                comboBox2.SelectedItem.ToString() + "','" +
                                label11.Text.ToString() + "')";

                            OracleCommand cmd2 = new OracleCommand(query2, conn);
                            OracleCommand cmd3 = new OracleCommand(query3, conn);


                            conn.Open();
                            cmd2.ExecuteNonQuery();
                            cmd3.ExecuteNonQuery();
                            conn.Close();
                        }
                        MessageBox.Show("Thêm Thành Công! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (step == 1)
            {
                this.Close();
            }
            else if (step == 2)
            {
                step--;
                label1.Text = "Đăng ký tuyển dụng";
                label2.Show();
                textBox1.Show();
                label3.Show();
                textBox2.Show();
                label4.Show();
                dateTimePicker1.Show();
                label5.Show();
                dateTimePicker2.Show();
                label6.Show();
                richTextBox1.Show();

                label7.Hide();
                comboBox1.Hide();
                
            }
            else if (step == 3)
            {
                step--;
                label1.Text = "Đăng ký quảng cáo";
                button2.Text = "Tiếp theo";
                label7.Show();
                comboBox1.Show();
                label8.Show();
                comboBox2.Show();

                label8.Hide();
                comboBox2.Hide();

                label10.Hide();
                label11.Hide();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
