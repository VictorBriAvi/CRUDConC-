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
namespace CRUDEntity
{
    public partial class Form1 : Form
    {

        public int? id;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region HELPER
        private void refrescar()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                var lst = from d in db.Tabla
                          select d;
                dataGridView1.DataSource = lst.ToList();

            }
        }

        private int? GetId()
        {
            try
            {
              return  int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Presentacion.FrmTabla oFrmTabla = new Presentacion.FrmTabla();
            oFrmTabla.ShowDialog();

            refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Presentacion.FrmTabla oFrmTabla = new Presentacion.FrmTabla(id);

                oFrmTabla.ShowDialog();

                refrescar();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            int? id = GetId();
            if (id != null)
            {
                using(CRUDEntities db = new CRUDEntities())
                {
                    Tabla oTabla = db.Tabla.Find(id);
                    db.Tabla.Remove(oTabla);

                    db.SaveChanges();
                }

                refrescar();
            }

        }
    }
}
