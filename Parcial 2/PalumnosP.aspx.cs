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
    public partial class PalumnosP : System.Web.UI.Page
    {
        CursosListadoATableAdapter miscursos = new CursosListadoATableAdapter();
        AsignaAlumnProfTableAdapter misalumno = new AsignaAlumnProfTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable m = new DataTable();
                m = miscursos.GetCurso(Clasgeneral.cod);
                dropcurso.DataSource = miscursos.GetCurso(Clasgeneral.cod);
                dropcurso.DataTextField = "nombre";
                dropcurso.DataValueField = "cod";
                dropcurso.DataBind();
                if (m.Rows.Count == 0)
                {
                    lbresult.Text = "No hay Alumnos Asignados";
                    Label6.Visible = false;
                    dropcurso.Visible = false;
                }
                else
                {
                    dropcurso.SelectedValue = m.Rows[0][0].ToString();
                    actualizar();
                }
            }
        }
        public void actualizar()
        {
            lbresult.Text = "";
            int cod = Convert.ToInt32(dropcurso.SelectedValue);
            DataTable m = new DataTable();
            m = misalumno.GetAlumnosAsignaProf(cod);
            GridView1.DataSource = misalumno.GetAlumnosAsignaProf(cod);
            GridView1.DataBind();
            if (m.Rows.Count == 0)
                lbresult.Text = "No hay Alumnos Asignados";
        }
        protected void dropdepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbresult.Text = "";
            int cods = Convert.ToInt32(dropcurso.SelectedValue);
            DataTable m = new DataTable();
            m = misalumno.GetAlumnosAsignaProf(cods);
            GridView1.DataSource = misalumno.GetAlumnosAsignaProf(cods);
            GridView1.DataBind();
            if (m.Rows.Count == 0)
                lbresult.Text = "No hay Alumnos Asignados";
        }
    }
}