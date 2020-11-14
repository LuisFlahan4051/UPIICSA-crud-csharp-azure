using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices; //Movimiento del form sin bordes.

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

        MainUserCapsule userCapsule = new MainUserCapsule();
        Authentication newAuthentication = new Authentication();

        public void validate()
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;

            if (!"".Equals(user) && !"".Equals(password))
            {
                userCapsule = newAuthentication.authentication(user, password);
                if (userCapsule == null)
                {
                    var msjResult = MessageBox.Show("Error al obtener el usuaior, es nulo.", "Error interno", MessageBoxButtons.OK , MessageBoxIcon.Error);
                    if (msjResult == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }

                if (userCapsule.Email_user != null && userCapsule.Password_user != null)
                {
                    this.Hide();
                    mainForm mainForm = new mainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("¡Los datos proporcionados no coinciden en nuestro registro!", "Fallo de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Text = "";
                    txtPassword.Text = "";
                }
            }
            else
            {
                MessageBox.Show("¡Rellene todos los campos!", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }




        private void btnEnter_Click(object sender, EventArgs e)
        {
            validate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
