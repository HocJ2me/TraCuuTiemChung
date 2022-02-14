using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraCuuTiemChung
{
    public partial class ThongTinTiem : Form
    {
        public ThongTinTiem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ql_vaccin;";
            // Select all
            string query = "SELECT * FROM `vaccinontime`";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            int numRes = 0;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // Success, now list 

                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(1) == tbxArea.SelectedIndex.ToString())
                        {
                            numRes++;
                            string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                                reader.GetString(4) };
                            var listViewItem = new ListViewItem(row);
                            listView1.Items.Add(listViewItem);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy kết quả.");
                }
                MessageBox.Show("Có " + numRes.ToString() + " kết quả", "Kết quả");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
