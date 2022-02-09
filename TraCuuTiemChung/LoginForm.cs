using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TraCuuTiemChung
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        string userId = "";
        bool isValidUer()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ql_vaccin;";
            // Câu lệnh mySQL select tất cả bản ghi ở login
            string query = "SELECT * FROM login";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            // tránh lỗi
            try 
            {
                //Kết nối với csdl và rà soát xem có bản ghi nào ở login có username và password hợp lệ
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if ((reader.GetString(1)==tbUser.Text)&&(reader.GetString(2)==tbPassword.Text))
                        {
                            userId = reader.GetString(0);
                            MessageBox.Show("Đăng nhập thành công", "Thông báo");
                            return true;
                        } 
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            // nếu lỗi in ra mã lỗi
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Sai mật khẩu hoặc tài khoảng", "Lỗi");
            return false;
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            bool checkLogin = isValidUer();
            if ((checkedListBox1.SelectedIndex == 0) && checkLogin)
            {
                MainForm frMain = new MainForm (userId);
                frMain.ShowDialog();
                this.Hide();
            }
            if ((checkedListBox1.SelectedIndex==1)&& checkLogin)
            {
                QuanLySinhVien frMain = new QuanLySinhVien();
                frMain.ShowDialog();
                this.Hide();
            }
        }
    }
}
