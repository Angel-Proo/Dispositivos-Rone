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

namespace Rone_2._0.Presentacion
{
    public partial class Red : Form
    {
        public Red()
        {
            InitializeComponent();
        }

        private void Red_Load(object sender, EventArgs e)
        {
            Direccion dir = new Direccion();
            dir.ObtenerIP();
            for (int i = 0; i < dir.IPs.Count(); i++)
            {
                comboBox1.Items.Add(dir.IPs[i]);
            }
            label2.Text = comboBox1.Text;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MB.Show("Se selecciono la direccion " + comboBox1.Text + "\n ¿Estas seguro de configurar esta direccion IP?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    Direccion dir = new Direccion();
                    dir.IP_Seleccionada(comboBox1.Text);
                    label3.Text = dir.Nueva_Direccion;
                    MB.Show("La direccion a sido modificada", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MB.Show("Selecciona o ingresa la direccion IP correcta", "¡Validar!", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MB.Show(ex.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            
        }
    }
}
