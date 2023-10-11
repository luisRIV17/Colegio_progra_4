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
    public partial class PasignarP : System.Web.UI.Page
    {
        AsignarProfesorTableAdapter misprofeseores = new AsignarProfesorTableAdapter();
        CicloTableAdapter miciclo = new CicloTableAdapter();
        CursoTableAdapter micurso = new CursoTableAdapter();
        Profesor_CursoTableAdapter profcurs = new Profesor_CursoTableAdapter();
        ProfcurcodTableAdapter profcurcod = new ProfcurcodTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizar();
                dropciclo.DataSource = miciclo.GetCiclo();
                dropciclo.DataTextField = "nombre";
                dropciclo.DataValueField = "cod";
                dropciclo.DataBind();
               
            }
        }
         public void actualizar()
        {
            bteliminar.Enabled = false;
            Button1.Enabled = true;
            lbresult.Text=txtdpi.Text=txtnombreprof.Text = "";
            gridprofe.DataSource = misprofeseores.GetProfesorAsignar();
            gridprofe.DataBind();
            txtfecha.Text= DateTime.Now.ToShortDateString();
            GridView1.DataSource = profcurs.GetAsignacionP();
            GridView1.DataBind();
            dropcruso.DataSource = micurso.GetCurso();
            dropcruso.DataTextField = "Nombre";
            dropcruso.DataValueField = "Codigo";
            dropcruso.DataBind();
           
        }

        protected void gridprofe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtdpi.Text= gridprofe.Rows[gridprofe.SelectedIndex].Cells[1].Text;
            txtnombreprof.Text = gridprofe.Rows[gridprofe.SelectedIndex].Cells[2].Text+ " "+ gridprofe.Rows[gridprofe.SelectedIndex].Cells[3].Text;
        }

        protected void bteliminar_Click(object sender, EventArgs e)
        {
            try
            {
                profcurs.DeleteProfcur(Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text));
                actualizar();
            }
            catch
            {
                lbresult.Text = "Ocurrio un error";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable tasig = new DataTable();
            tasig = profcurcod.GetProfcurCod();
            bool bandera = false;
            foreach (DataRow f in tasig.Rows)
            {
                if (f[4].ToString() == dropcruso.SelectedValue.ToString())
                    if (Convert.ToDateTime(f[1].ToString()).Year == DateTime.Now.Year)
                        bandera = true;
            }
            if(bandera==false)
            {
                try {

                    profcurs.InsertProfCuso(Convert.ToDateTime(txtfecha.Text),Convert.ToInt32( dropciclo.SelectedValue),txtdpi.Text,dropcruso.SelectedValue.ToString());
                    actualizar();
                    Response.Write("<script language=javascript> alert('Datos Registrados con Exito'); </script>");
                }
                catch
                {
                    lbresult.Text = "Ocurrio un error";
                }
            }
            else
            {
                lbresult.Text = "Curso ya asignado, Seleccione otro";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bteliminar.Enabled =  true;
            Button1.Enabled = false;
            DataTable mitabla = new DataTable();
            mitabla = profcurcod.Getprofcurcodfil(Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text));
            foreach (DataRow f in mitabla.Rows)
            {
                txtdpi.Text = f[3].ToString();
                txtnombreprof.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[3].Text;
                txtfecha.Text = f[1].ToString();
                dropcruso.SelectedValue = f[4].ToString();


            }
        }
    }
}