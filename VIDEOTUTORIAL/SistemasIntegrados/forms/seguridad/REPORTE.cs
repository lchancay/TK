using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using clases.seguridad;
namespace forms.seguridad
{
    public partial class REPORTE : DevExpress.XtraReports.UI.XtraReport
    {
        public REPORTE()
        {
            InitializeComponent();
        }

        public void loadReport(List<REPORTECLASE> datos) {
            try
            {
                this.DataSource = datos;
            }
            catch (Exception)
            {
            }
        }

    }
}
