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
    public partial class Asignar_Dispositivos : Form
    {
        string conn = Conexion.conn();
        public Asignar_Dispositivos()
        {
            InitializeComponent();
        }
        private void Asignar_Dispositivos_Load(object sender, EventArgs e)
        {// Lee los ID de dispositivos
            FbCommand cmd = new FbCommand("Select ID from DISPOSITIVOS")
            {
                CommandType = CommandType.Text
            };
            using (cmd.Connection = new FbConnection(Conexion.conn()))
            {
                cmd.Connection.Open();
                FbDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    comboBoxIDDispositivos.Items.Add(registro["ID"].ToString());
                }
            }
        // Lee los Nombres de Personal    
            FbCommand cmds = new FbCommand("Select ID from PERSONAL")
            {
                CommandType = CommandType.Text
            };
            using (cmds.Connection = new FbConnection(Conexion.conn()))
            {
                cmds.Connection.Open();
                FbDataReader registro = cmds.ExecuteReader();
                while (registro.Read())
                {
                    comboBoxPersonal.Items.Add(registro["ID"].ToString());
                }
            }
         // carga la tabla en dgvUsuarios
            try
            {
                //Clase que actualiza la tabla
                dgvAsignacion.DataSource = new Actualizar_Usuarios("BUSCA_ASIGNACION").Buscar();
                dgvAsignacion.Columns[0].HeaderText = "ID Dispositivo";
                dgvAsignacion.Columns[1].HeaderText = "ID Colaborador";
                dgvAsignacion.Columns[2].HeaderText = "Nombre del Colaborador";
            }
            catch (Exception ex)
            {
                MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvAsignacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {//rellena textbox con sus equivalentes en dgvUsuarios
            int indice = e.RowIndex;
            if (indice != -1)
            {
                comboBoxIDDispositivos.Text = dgvAsignacion.SelectedCells[0].Value.ToString().Trim();
                comboBoxPersonal.Text = dgvAsignacion.SelectedCells[1].Value.ToString().Trim();
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {//accion del boton ingresar usuario
            if (!String.IsNullOrEmpty(comboBoxIDDispositivos.Text) && !String.IsNullOrEmpty(comboBoxPersonal.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("ALTA_ASIGNACION");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = comboBoxIDDispositivos.Text.Trim();
                    cmd.Parameters.Add("@COL2", FbDbType.Integer).Value = comboBoxPersonal.Text.Trim();
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
                    dgvAsignacion.DataSource = new Actualizar_Usuarios("BUSCA_ASIGNACION").Buscar();
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
            if (!String.IsNullOrEmpty(comboBoxIDDispositivos.Text) && !String.IsNullOrEmpty(comboBoxPersonal.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("CAMBIA_ASIGNACION");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = Convert.ToInt32(comboBoxIDDispositivos.Text);
                    cmd.Parameters.Add("@COL2", FbDbType.Integer).Value = comboBoxPersonal.Text.Trim();
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
                    dgvAsignacion.DataSource = new Actualizar_Usuarios("BUSCA_ASIGNACION").Buscar();
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
            if (!String.IsNullOrEmpty(comboBoxIDDispositivos.Text) && !String.IsNullOrEmpty(comboBoxPersonal.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("BAJA_ASIGNACION");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = Convert.ToInt32(comboBoxIDDispositivos.Text);
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
                    comboBoxIDDispositivos.Text = string.Empty;
                    comboBoxPersonal.Text = string.Empty;
                    //Clase que actualiza la tabla
                    dgvAsignacion.DataSource = new Actualizar_Usuarios("BUSCA_ASIGNACION").Buscar();
                }
                catch (Exception ex)
                {
                    MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MB.Show("Seleccione un Dispositivo para eliminarlo", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
