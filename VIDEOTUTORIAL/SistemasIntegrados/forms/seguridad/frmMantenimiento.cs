using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clases.seguridad;
using datos.seguridad;

namespace forms.seguridad
{
    public partial class frmMantenimiento : Form
    {
        public frmMantenimiento()
        {
            InitializeComponent();
            event_click += new delegate_CLICK(frmMantenimiento_event_click);
        }

        void frmMantenimiento_event_click(object sender, EventArgs e)
        {
        }
        public clase_persona clas = new clase_persona();
        clase_datos dato = new clase_datos();
        //aqui seteamos que accion estamos haciendo guardar modificar etc
        public string accion { get; set; }
        private void frmMantenimiento_Load(object sender, EventArgs e)
        {
            //llenemos el combo
            //con eso llenamos el combogenero
            clase_datos dat = new clase_datos();
            combo.Properties.DataSource = dat.consultaGenero();
            if (accion == "M")//M de modificar
            {
                set();
            }
            if (accion == "E")//cargar antes de eliminar
            {
                set();
            }
        }

        public void set() {
            textBox1.Text = clas.codigo;
            textBox2.Text = clas.nombre;
            textBox3.Text = clas.apellido;
            textBox4.Text = clas.telefono;
            combo.EditValue = clas.genero;
            dateTimePicker1.Value = clas.fechaNacimiento;
        }
        public void get()
        {
            clas.codigo= textBox1.Text;
            clas.nombre=textBox2.Text ;
             clas.apellido=textBox3.Text;
             clas.telefono =textBox4.Text;
             clas.genero = Convert.ToInt32(combo.EditValue);
             clas.fechaNacimiento=dateTimePicker1.Value;
        }
        public delegate void delegate_CLICK(object sender, EventArgs e);
        public event delegate_CLICK event_click;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            get();
            if(accion=="G"){

                if (dato.guardar(clas))
                {
                    MessageBox.Show("Guardado con exito");
                }
                else { MessageBox.Show("No Guardado"); }
            }
            if (accion == "M")
            {
                dato.modificar(clas);

            }
            if (accion == "E")
            {
                dato.eliminar(clas);

            }
            event_click(sender, e);
            frmMantenimiento_event_click(sender, e);
        }

       
    }
}
