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
using Rone_2._0.Datos;

namespace Rone_2._0.Presentacion
{
    public partial class Dispositivos : Form
    {   //Variables
        public Dispositivos()
        {
            InitializeComponent();
        }
        private void Dispositivos_Load(object sender, EventArgs e)
        {
            // carga la tabla en dgvUsuarios
            try
            {
                //Clase que actualiza la tabla
                dgvDispositivos.DataSource = new Actualizar_Usuarios("BUSCA_DISPOSITIVOS").Buscar();
                dgvDispositivos.Columns[0].HeaderText = "ID";
                dgvDispositivos.Columns[1].HeaderText = "Direccion";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dgvDispositivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {//rellena textbox con sus equivalentes en dgvUsuarios
            int indice = e.RowIndex;
            if (indice != -1)
            {
                textBoxID.Text = (string)dgvDispositivos.Rows[indice].Cells[0].Value.ToString().Trim();
                textBoxDireccion.Text = dgvDispositivos.SelectedCells[1].Value.ToString().Trim();
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {//accion del boton ingresar usuario
            if (!String.IsNullOrEmpty(textBoxDireccion.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("ALTA_DISPOSITIVOS");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL2", FbDbType.VarChar).Value = textBoxDireccion.Text.Trim();
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
                    dgvDispositivos.DataSource = new Actualizar_Usuarios("BUSCA_DISPOSITIVOS").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message,"¡Atencion!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Uno o mas campos se encuentran vacios, \npor favor ingresar la informacion faltante", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonActualizar_Click(object sender, EventArgs e)
        {//accion del boton actualizar usuario
            if (!String.IsNullOrEmpty(textBoxID.Text) && !String.IsNullOrEmpty(textBoxDireccion.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("CAMBIA_DISPOSITIVO");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = Convert.ToInt32(textBoxID.Text);
                    cmd.Parameters.Add("@COL2", FbDbType.VarChar).Value = textBoxDireccion.Text.Trim();
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
                    dgvDispositivos.DataSource = new Actualizar_Usuarios("BUSCA_DISPOSITIVOS").Buscar();
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
                    FbCommand cmd = new FbCommand("BAJA_DISPOSITIVOS");
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
                    textBoxDireccion.Text = string.Empty;
                    //Clase que actualiza la tabla
                    dgvDispositivos.DataSource = new Actualizar_Usuarios("BUSCA_DISPOSITIVOS").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Seleccione uno de los Dispositivos para eliminarlo", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
