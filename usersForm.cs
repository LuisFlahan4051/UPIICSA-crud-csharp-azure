using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zapatosUPIICSA.Properties;
using System.Runtime.InteropServices; //Movimiento del form sin bordes.

namespace zapatosUPIICSA
{
    public partial class usersForm : Form
    {
        public usersForm()
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.Close_2;
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(126, 1, 63);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.Close;
            btnClose.ForeColor = Color.FromArgb(126, 1, 63);
            btnClose.BackColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
