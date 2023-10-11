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
    public partial class PnotasA : System.Web.UI.Page
    {
        VistaNotasTableAdapter misnotas = new VistaNotasTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable t = new DataTable();
            t= misnotas.GetVistanotas(Clasgeneral.cod);
            if (t.Rows.Count == 0)
            {
                lbresult.Text = "No hay cursos asignados";
            }
            else
            {
                GridView1.DataSource = misnotas.GetVistanotas(Clasgeneral.cod);
                GridView1.DataBind();
            }
        }

        
    }
}