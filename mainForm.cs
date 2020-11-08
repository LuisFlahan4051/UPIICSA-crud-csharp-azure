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

namespace zapatosUPIICSA
{
    public partial class mainForm : Form
    {
        public mainForm()
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


        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #region Hover en los botones
        private void btnUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnUsers.ForeColor = Color.White;
            btnUsers.BackColor = Color.FromArgb(126, 1, 63);
        }

        private void btnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsers.ForeColor = Color.FromArgb(112, 112, 112);
            btnUsers.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void btnClients_MouseHover(object sender, EventArgs e)
        {
            btnClients.ForeColor = Color.White;
            btnClients.BackColor = Color.FromArgb(126, 1, 63);
        }

        private void btnClients_MouseLeave(object sender, EventArgs e)
        {
            btnClients.ForeColor = Color.FromArgb(112, 112, 112);
            btnClients.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void btnModels_MouseHover(object sender, EventArgs e)
        {
            btnModels.ForeColor = Color.White;
            btnModels.BackColor = Color.FromArgb(126, 1, 63);
        }

        private void btnModels_MouseLeave(object sender, EventArgs e)
        {
            btnModels.ForeColor = Color.FromArgb(112, 112, 112);
            btnModels.BackColor = Color.FromArgb(245, 245, 245);
        }
        #endregion

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new usersForm());
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            openChildForm(new clientsForm());
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            openChildForm(new modelsForm());
        }
    }
}
