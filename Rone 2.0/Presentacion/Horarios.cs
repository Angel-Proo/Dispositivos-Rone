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
    public partial class Horarios : Form
    {
        public Horarios()
        {
            InitializeComponent();
            dateTimePickerApertura.Format = DateTimePickerFormat.Time;
            dateTimePickerCierre.Format = DateTimePickerFormat.Time;
            dateTimePickerApertura.ShowUpDown = true;
            dateTimePickerCierre.ShowUpDown = true;
        }

        private void Horarios_Load(object sender, EventArgs e)
        {// carga la tabla en dgvUsuarios
            try
            {
                //Clase que actualiza la tabla
                dgvHorarios.DataSource = new Actualizar_Usuarios("HORARIOS").Buscar();
                dgvHorarios.Columns[0].HeaderText = "Día";
                dgvHorarios.Columns[1].HeaderText = "Apertura";
                dgvHorarios.Columns[2].HeaderText = "Cierre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {//rellena textbox con sus equivalentes en dgvUsuarios
            int indice = e.RowIndex;
            if (indice != -1)
            {
                textBoxDia.Text = dgvHorarios.SelectedCells[0].Value.ToString().Trim();
                dateTimePickerApertura.Text = dgvHorarios.SelectedCells[1].Value.ToString().Trim();
                dateTimePickerCierre.Text = dgvHorarios.SelectedCells[2].Value.ToString().Trim();
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {//accion del boton actualizar usuario
            if (!String.IsNullOrEmpty(textBoxDia.Text))
            {
                try
                {
                    FbCommand cmd = new FbCommand("CAMBIA_HORARIOS");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@COL1", FbDbType.Integer).Value = Convert.ToInt32(textBoxDia.Text);
                    cmd.Parameters.Add("@COL2", FbDbType.Time).Value = dateTimePickerApertura.Text;
                    cmd.Parameters.Add("@COL3", FbDbType.Time).Value = dateTimePickerCierre.Text;
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
                    dgvHorarios.DataSource = new Actualizar_Usuarios("HORARIOS").Buscar();
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
    }
}
