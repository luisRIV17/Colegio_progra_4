using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parcial_2.DataSet.BDescuelaTableAdapters;
using System.Data;

namespace Parcial_2
{
    public partial class Pcurso : System.Web.UI.Page
    {
        CursoTableAdapter miscursos = new CursoTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizar();
            }
        }
        public void actualizar()
        {
            Button1.Enabled = true;
            txtcodigo.Enabled = false;
            txtnombre.Text = "";
            bteliminar.Enabled =  false;
            DataTable tabla = new DataTable();
            tabla = miscursos.GetCurso();
            GridView1.DataSource = miscursos.GetCurso();
            GridView1.DataBind();
            if (tabla.Rows.Count != 0)
                txtcodigo.Text = (Convert.ToInt32(tabla.Rows[tabla.Rows.Count - 1][0].ToString()) + 1).ToString();
            else
                txtcodigo.Text = 1.ToString() ;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                miscursos.InsertCurso(txtcodigo.Text,txtnombre.Text);
                actualizar();
                Response.Write("<script language=javascript> alert('Datos Registrados con Exito'); </script>");
            } catch { lbresult.Text = "Ocurrio un error"; }
        }
        protected void bteliminar_Click(object sender, EventArgs e)
        {
            try
            {
                miscursos.DeleteCurso(txtcodigo.Text);
                actualizar();
            }
            catch { lbresult.Text = "Ocurrio un error"; }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bteliminar.Enabled = true;
            Button1.Enabled = false;
          
            txtcodigo.Text= GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
           txtnombre.Text= GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
        }
    }
}