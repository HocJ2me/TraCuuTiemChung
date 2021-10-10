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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedIndex==2)
            {
                QuanLySinhVien frMain = new QuanLySinhVien();
                frMain.ShowDialog();
                this.Hide();
            }    
            else
            {
                MainForm frMain = new MainForm();
                frMain.ShowDialog();
                this.Hide();
            }    
        }
    }
}
