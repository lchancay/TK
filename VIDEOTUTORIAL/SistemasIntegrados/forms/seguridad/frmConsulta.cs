using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Drawing.Image;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using datos.seguridad;
using clases.seguridad;
using System.IO;

namespace forms.seguridad
{
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();

        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            cargar();
            clase_datos clas = new clase_datos();
        }
        public void cargar() {
            clase_datos clas= new clase_datos();
            gridControl1.DataSource = clas.consulta();
            
        }
        clase_datos dat = new clase_datos();

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            cargar();
            List<clase_persona> per = new List<clase_persona>();
            per = (List<clase_persona>)gridControl1.DataSource;


            dat.guardarLista(per);

            //select grid
            var sd = from q in (List<clase_persona>)gridControl1.DataSource select q.apellido;
        }
        clase_persona clasper = new clase_persona();
        public void get() {
            clasper.codigo = Convert.ToString(gridView1.GetFocusedRowCellValue(colcodigo));
            clasper.nombre = Convert.ToString(gridView1.GetFocusedRowCellValue(colnombre));
            clasper.apellido = Convert.ToString(gridView1.GetFocusedRowCellValue(colapellido));
            clasper.genero = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colgenero));
            clasper.fechaNacimiento = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(colfechaNacimiento));
            clasper.telefono = Convert.ToString(gridView1.GetFocusedRowCellValue(coltelefono));
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmMantenimiento frm = new frmMantenimiento();
            get();
            frm.clas = clasper;
            frm.accion = "M";
            frm.Show();
            frm.event_click += new frmMantenimiento.delegate_CLICK(frm_event_click);
        }

        void frm_event_click(object sender, EventArgs e)
        {
            cargar();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmMantenimiento frm = new frmMantenimiento();
            get();
            frm.clas = clasper;
            frm.accion = "E";
            frm.Show();
            //seteamos la accion eliminar
            frm.event_click +=new frmMantenimiento.delegate_CLICK(frm_event_click);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmMantenimiento frm = new frmMantenimiento();
            get();
            frm.clas = clasper;
            frm.accion = "G";
            frm.event_click += new frmMantenimiento.delegate_CLICK(frm_event_click);

            frm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            REPORTE rpt = new REPORTE();

            REPORTECLASE clasRe = new REPORTECLASE();
           
            List<REPORTECLASE> listare = new List<REPORTECLASE>();
            
            clasRe.PERSONA = dat.consulta();
            clasRe.NombreEmpresa = "HECTOR ROMERO SA";


            listare.Add(clasRe);
            rpt.loadReport(listare);


            rpt.ShowPreview();
        }
    }
}
