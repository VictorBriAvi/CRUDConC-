using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDEntity.Models;
namespace CRUDEntity.Presentacion
{
    public partial class FrmTabla : Form
    {
        public int? id;

        Tabla oTabla = null;

        public FrmTabla(int? id = null)
        {
            InitializeComponent();
            this.id = id;

            if (id != null)
            {
                cargarDatos();
            }
        }

        private void cargarDatos()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                oTabla = db.Tabla.Find(id);

                txtCorreo.Text = oTabla.correo;
                txtNombre.Text = oTabla.nombre;
                dateTimePicker1.Value = oTabla.fechaNacimiento;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                if (id == null)
                {
                    oTabla = new Tabla();
                }
                oTabla.nombre = txtNombre.Text;
                oTabla.correo = txtCorreo.Text;
                oTabla.fechaNacimiento = dateTimePicker1.Value;

                if (id == null)
                {
                    db.Tabla.Add(oTabla);

                }
                else
                {
                    db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                }


                db.SaveChanges();

                this.Close();
            }
        }
    }
}
