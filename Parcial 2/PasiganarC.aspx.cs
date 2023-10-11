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
    public partial class PasiganarC : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                actualizar();
            }

        }
        CursoAsigTableAdapter miscursos =new CursoAsigTableAdapter();
        AsignacionAlumnoTableAdapter misasig = new AsignacionAlumnoTableAdapter();
        ProfcurcodTableAdapter miprofesor = new ProfcurcodTableAdapter();
        filroAsignacionTableAdapter repe = new filroAsignacionTableAdapter();
        
         public void actualizar()
        {
            txtcurso.Text=txtprofe.Text= "";
            gridcurso.DataSource = miscursos.GetProfCursoAsignar();
            gridcurso.DataBind();
            GridView1.DataSource = misasig.GetAsiganaalumno(Clasgeneral.cod);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           try {
                if(txtcurso.Text != "")
                {
                    misasig.InsertAsignacionAlumn(DateTime.Now, 0, 0, 0, "-", false, Clasgeneral.cod, Convert.ToInt32(gridcurso.Rows[gridcurso.SelectedIndex].Cells[1].Text));
                    Response.Write("<script language=javascript> alert('Curso Aignado con Exito'); </script>");
                    actualizar();
                }
            }
          catch {
                lbresult.Text = "Ocurrio un error";
           }
        }
       
        protected void gridcurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bandera = false;
            DataTable ta = new DataTable();
            ta =repe.Getfiltrocursorepe(Clasgeneral.cod);
            foreach (DataRow f in ta.Rows)
            {
                if (gridcurso.Rows[gridcurso.SelectedIndex].Cells[1].Text == f[2].ToString())
                    bandera = true;
            }
            if (bandera == false)
            {
                lbresult.Text = "";
                txtcurso.Text = gridcurso.Rows[gridcurso.SelectedIndex].Cells[2].Text;
                txtprofe.Text = gridcurso.Rows[gridcurso.SelectedIndex].Cells[3].Text;
            }
            else
            {
                lbresult.Text = "Curso ya Asignado";
            }
        }
    }
}