﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using The_recruitment_profile_management_system.NhanVien_UI;

namespace The_recruitment_profile_management_system
{
    public partial class LogIn : Form
    {
        string SERVICE_NAME = null;
        string id = null;
        string password = null;
        string connectString = null;
        public LogIn()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SERVICE_NAME = "XE";
                id = textBox1.Text;
                password = textBox2.Text;
                if (id.StartsWith("sys"))
                {
                    connectString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + SERVICE_NAME + ")));User Id=" + id + ";Password=" + password + ";DBA Privilege = SYSDBA;";
                }
                else if (id.StartsWith("NV") || id.StartsWith("DN") || id.StartsWith("UV"))
                {
                    connectString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + SERVICE_NAME + ")));User Id=" + id + ";Password=" + password;
                }

                else
                {
                    //connectString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + SERVICE_NAME + ")));User Id=" + id + ";Password=" + password + ";";
                    MessageBox.Show("Thao tác thất bại");
                    return;
                }
                //connectString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = khainehaha)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = XE)));User Id = " + id + ";password =" + password + ";";

                using (OracleConnection con = new OracleConnection(connectString))
                {

                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Kết nối thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        this.Hide();
                        if (id.StartsWith("sys"))
                        {
                            
                        }
                        else if (id.StartsWith("NV"))
                        {
                            NhanVien_Menu nhanVien_Menu = new NhanVien_Menu(connectString);
                            nhanVien_Menu.ShowDialog();
                            this.Show();
                        }
                        else if (id.StartsWith("DN"))
                        {
                            DN_Menu mn = new DN_Menu(connectString, textBox1.Text.ToString());
                            mn.ShowDialog();
                            this.Show();
                        }
                        else if (id.StartsWith("UV"))
                        {
                            
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ", "Đăng Nhập Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SERVICE_NAME = "XE";
            id = "sys";
            password = "0971618896";
            connectString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + SERVICE_NAME + ")));User Id=" + id + ";Password=" + password + ";DBA Privilege = SYSDBA;";
            this.Hide();
            DangKyThanhVien dk = new DangKyThanhVien(connectString);
            dk.ShowDialog();
            this.Show();
        }
    }
}
