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
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace forms.seguridad
{
    public partial class frmImage : Form
    {
        public frmImage()
        {
            InitializeComponent();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text=Convert.ToString(openFileDialog1.FileName);
                pictureBox1.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
        }
clase_datos dat = new clase_datos();
        private void button2_Click(object sender, EventArgs e)
        {
            clase_info clas = new clase_info();
            MemoryStream ms = new MemoryStream();
            Image.FromFile(textBox1.Text).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            
            clas.pub_id = num.Text;
            
            clas.logo = ms.ToArray();

            clas.pr_info = "";

            dat.guardarImagen(clas);
            frmImage_Load(sender, e);
        }

        private void frmImage_Load(object sender, EventArgs e)
        {
            List<Image> img = new List<Image>(); 
            foreach (var item in dat.select())
	{
        
                img.Add(Image.FromStream(item.Imagen));
                imageSlider1.Images.Add(Image.FromStream(item.Imagen));
                

	}
        }
    }
}
