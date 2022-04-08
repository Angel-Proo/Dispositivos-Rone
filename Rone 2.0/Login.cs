using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;

namespace Rone_2._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //mover login
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //botones
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            FormMainMenu frm = new FormMainMenu();
            frm.Show();
        }

        private void textUsuario_Enter(object sender, EventArgs e)
        {
            if(textUsuario.Text == "Usuario")
            {
                textUsuario.Text = "";
                textUsuario.ForeColor = Color.FromArgb(40,40,40);
                textUsuario.Font = new Font("Helvetica", 16, FontStyle.Regular);
            }
        }

        private void textUsuario_Leave(object sender, EventArgs e)
        {
            if(textUsuario.Text == "")
            {
                textUsuario.Text = "Usuario";
                textUsuario.ForeColor = Color.FromArgb(124, 118, 114);
                textUsuario.Font = new Font("Helvetica Condensed", 16, FontStyle.Italic);
            }
        }

        private void textContraseña_Enter(object sender, EventArgs e)
        {
           // quitar los asteriscos textUsuario.PasswordChar = '\0';

            if (textContraseña.Text == "Contraseña")
            {
                textContraseña.Text = "";
                textContraseña.ForeColor = Color.FromArgb(40, 40, 40);
                textContraseña.UseSystemPasswordChar = true;
                textContraseña.Font = new Font("Helvetica",16,FontStyle.Regular);
            }
        }

        private void textContraseña_Leave(object sender, EventArgs e)
        {
            if (textContraseña.Text == "")
            {
                textContraseña.Text = "Contraseña";
                textContraseña.ForeColor = Color.FromArgb(124, 118, 114);
                textContraseña.UseSystemPasswordChar = false;
                textContraseña.Font = new Font("Helvetica Condensed", 16, FontStyle.Italic);
            }
        }

        
    }
}