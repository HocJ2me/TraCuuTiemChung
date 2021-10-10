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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DangKiTiem frMain = new DangKiTiem();
            frMain.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ThongTinTiem frMain = new ThongTinTiem();
            frMain.ShowDialog();
            this.Hide();
        }
    }
}
