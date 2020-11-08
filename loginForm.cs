using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //Movimiento del form sin bordes.
using System.Net.NetworkInformation;

namespace zapatosUPIICSA
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        #region Movimiento del formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void loginForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm mainForm = new mainForm();
            mainForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnter_MouseHover(object sender, EventArgs e)
        {
            btnEnter.ForeColor = Color.White;
            btnEnter.BackColor = Color.FromArgb(0, 125, 60);
        }

        private void btnEnter_MouseLeave(object sender, EventArgs e)
        {
            btnEnter.ForeColor = Color.FromArgb(0, 125, 60);
            btnEnter.ForeColor = Color.White;
        }
    }
}
