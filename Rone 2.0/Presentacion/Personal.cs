using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rone_2._0.Datos;
using FirebirdSql.Data.FirebirdClient;

namespace Rone_2._0.Presentacion
{
    public partial class Personal : Form
    {//Variables
        public Personal()
        {
            InitializeComponent();
        }
        private void Personal_Load(object sender, EventArgs e)
        {
            // carga la tabla en dgvUsuarios
            try
            {
                //Clase que actualiza la tabla
                dgvPersonal.DataSource = new Actualizar_Usuarios("BUSCA_PERSONAL").Buscar();
                dgvPersonal.Columns[0].HeaderText = "ID";
                dgvPersonal.Columns[1].HeaderText = "Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {//rellena textbox con sus equivalentes en dgvUsuarios
            int indice = e.RowIndex;
            if (indice != -1)
            {
                textBoxID.Text = (string)dgvPersonal.Rows[indice].Cells[0].Value.ToString().Trim();
                textBoxNombre.Text = dgvPersonal.SelectedCells[1].Value.ToString().Trim();
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {//accion del boton ingresar usuario
            if (!String.IsNullOrEmpty(textBoxNombre.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("ALTA_PERSONAL");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL2", FbDbType.Char).Value = textBoxNombre.Text.Trim();
                    using (cmd.Connection = new FbConnection(Conexion.conn()))
                    {
                        cmd.Connection.Open();
                        string mensaje = (string)cmd.ExecuteScalar();
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
                    dgvPersonal.DataSource = new Actualizar_Usuarios("BUSCA_PERSONAL").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Uno o mas campos se encuentran vacios, \npor favor ingresar la informacion faltante", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonActualizar_Click(object sender, EventArgs e)
        {//accion del boton actualizar usuario
            if (!String.IsNullOrEmpty(textBoxID.Text) && !String.IsNullOrEmpty(textBoxNombre.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("CAMBIA_PERSONAL");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = Convert.ToInt32(textBoxID.Text);
                    cmd.Parameters.Add("@COL2", FbDbType.Char).Value = textBoxNombre.Text.Trim();
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
                    dgvPersonal.DataSource = new Actualizar_Usuarios("BUSCA_PERSONAL").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Uno o mas campos se encuentran vacios, \npor favor ingresar la informacion faltante", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonEliminar_Click(object sender, EventArgs e)
        {//Accion del boton eliminar
            if (!String.IsNullOrEmpty(textBoxID.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("BAJA_PERSONAL");
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
                    //Clase que actualiza la tabla
                    dgvPersonal.DataSource = new Actualizar_Usuarios("BUSCA_PERSONAL").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Seleccione un Colaborador para eliminarlo", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
