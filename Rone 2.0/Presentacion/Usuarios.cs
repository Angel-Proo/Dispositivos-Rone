using Rone_2._0.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Rone_2._0.Presentacion
{
    public partial class Usuarios : Form
    {//Variables
        int pr;
        public Usuarios()
        {
            InitializeComponent();
        }
        string perfil(string valor)
        {//convierte id perfil a nombre perfil
            switch (valor)
             {
              case "1":
                valor = "ADMINISTRADOR";
                break;
              case "2":
                valor = "USUARIO";
                break;
              case "3":
                 valor = "CONSULTA";
                 break;
             }          
            return valor;
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {// carga la tabla en dgvUsuarios
            try
            {
                //Clase que actualiza la tabla
                dgvUsuarios.DataSource = new Actualizar_Usuarios("BUSCA_USUARIOS").Buscar();
                dgvUsuarios.Columns[0].HeaderText = "ID";
                dgvUsuarios.Columns[1].HeaderText = "Nombre";
                dgvUsuarios.Columns[2].HeaderText = "Usuario";
                dgvUsuarios.Columns[3].HeaderText = "Perfil";
                dgvUsuarios.Columns[4].HeaderText = "Contraseña";
            }
            catch (Exception ex)
            {
                MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {//accion del boton ingresar usuario
            if (!String.IsNullOrEmpty(textBoxID.Text) && !String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxUsuario.Text) && !String.IsNullOrEmpty(comboBoxPerfiles.Text) && !String.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("ALTA_USUARIOS");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.VarChar).Value = textBoxNombre.Text.Trim();
                    cmd.Parameters.Add("@COL2", FbDbType.VarChar).Value = textBoxUsuario.Text.Trim();
                    cmd.Parameters.Add("@COL3", FbDbType.Integer).Value = pr;
                    cmd.Parameters.Add("@COL4", FbDbType.VarChar).Value = textBoxPassword.Text;
                    using (cmd.Connection = new FbConnection(Conexion.conn()))
                    {
                        cmd.Connection.Open();
                        string mensaje = (string) cmd.ExecuteScalar();
                        if (mensaje.Contains("Registrado"))
                        {
                            MB.Show(mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MB.Show(mensaje, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                    }
                    //Clase que actualiza la tabla
                    dgvUsuarios.DataSource = new Actualizar_Usuarios("BUSCA_USUARIOS").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Uno o mas campos se encuentran vacios, \npor favor ingresar la informacion faltante","¡Advertencia!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }          
        }
        private void buttonActualizar_Click(object sender, EventArgs e)
        {//accion del boton actualizar usuario
            if (!String.IsNullOrEmpty(textBoxID.Text) && !String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxUsuario.Text) && !String.IsNullOrEmpty(comboBoxPerfiles.Text) && !String.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("CAMBIA_USUARIOS");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = Convert.ToInt32(textBoxID.Text);
                    cmd.Parameters.Add("@COL2", FbDbType.VarChar).Value = textBoxNombre.Text.Trim();
                    cmd.Parameters.Add("@COL3", FbDbType.VarChar).Value = textBoxUsuario.Text.Trim();
                    cmd.Parameters.Add("@COL4", FbDbType.Integer).Value = pr;
                    cmd.Parameters.Add("@COL5", FbDbType.VarChar).Value = textBoxPassword.Text;
                    using (cmd.Connection = new FbConnection(Conexion.conn()))
                    {
                        cmd.Connection.Open();
                        string mensaje = (string)cmd.ExecuteScalar();
                        if (mensaje.Contains("Actualizado"))
                        {
                            MB.Show(mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MB.Show(mensaje, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    //Clase que actualiza la tabla
                    dgvUsuarios.DataSource = new Actualizar_Usuarios("BUSCA_USUARIOS").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Uno o mas campos se encuentran vacios, \npor favor ingresar la informacion faltante","¡Advertencia!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {//cambiar la contraseña a asteriscos

            if (e.ColumnIndex == 4 && e.Value != null)
            {
                e.Value = new string('*', 10);
            }
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                pr = Convert.ToInt32(e.Value.ToString());
                e.Value = perfil(e.Value.ToString());
            }
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {//rellena textbox con sus equivalentes en dgvUsuarios
            int indice = e.RowIndex;
            if (indice != -1)
            {
                textBoxID.Text = (string)dgvUsuarios.Rows[indice].Cells[0].Value.ToString().Trim();
                textBoxNombre.Text = dgvUsuarios.SelectedCells[1].Value.ToString().Trim();
                textBoxUsuario.Text = dgvUsuarios.SelectedCells[2].Value.ToString().Trim();
                comboBoxPerfiles.Text = perfil(dgvUsuarios.SelectedCells[3].Value.ToString());
                textBoxPassword.Text = dgvUsuarios.SelectedCells[4].Value.ToString().Trim();
            }
        }
        private void buttonEliminar_Click(object sender, EventArgs e)
        {//Accion del boton eliminar
            if (!String.IsNullOrEmpty(textBoxID.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("BAJA_USUARIOS");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = Convert.ToInt32(textBoxID.Text);
                    using (cmd.Connection = new FbConnection(Conexion.conn()))
                    {
                        cmd.Connection.Open();
                        string mensaje = (string)cmd.ExecuteScalar();
                        if (mensaje.Contains("Eliminado"))
                        {
                            MB.Show(mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MB.Show(mensaje, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    textBoxID.Text = string.Empty;
                    textBoxNombre.Text = string.Empty;
                    comboBoxPerfiles.Text = string.Empty;
                    textBoxUsuario.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
                    //Clase que actualiza la tabla
                    dgvUsuarios.DataSource = new Actualizar_Usuarios("BUSCA_USUARIOS").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Seleccione uno de los Usuarios para eliminarlo", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
