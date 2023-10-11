using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parcial_2.DataSet.BDescuelaTableAdapters;
using System.Data;
using System.Drawing;

namespace Parcial_2
{
    public partial class PlistadoA : System.Web.UI.Page
    {
        CursosListadoATableAdapter miscursos = new CursosListadoATableAdapter();
        AsignaAlumnProfTableAdapter misalumno = new AsignaAlumnProfTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable m = new DataTable();
                m= miscursos.GetCurso(Clasgeneral.cod);
                dropcurso.DataSource = miscursos.GetCurso(Clasgeneral.cod);
                dropcurso.DataTextField = "nombre";
                dropcurso.DataValueField = "cod";
                dropcurso.DataBind();
                if (m.Rows.Count == 0)
                {
                    lbresult.Text = "No hay Cursos Asignados";
                    Label6.Visible = false;
                    dropcurso.Visible = false;
                }
                else
                {
                    dropcurso.SelectedValue = m.Rows[0][0].ToString();
                    actualizar();
                    foreach (GridViewRow f in GridView1.Rows)
                    {
                        bool cod = ((CheckBox)(f.FindControl("checkdele"))).Checked;
                      
                            ((CheckBox)(f.FindControl("checkdele"))).Enabled = false;
                            btdele.Visible = true;
                        
                    }
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
            btdele.Visible = false;
           
            int cods =Convert.ToInt32(dropcurso.SelectedValue);
            DataTable m = new DataTable();
                m=misalumno.GetAlumnosAsignaProf(cods);
            GridView1.DataSource = misalumno.GetAlumnosAsignaProf(cods) ;
            GridView1.DataBind();
            foreach (GridViewRow f in GridView1.Rows)
            {
                bool cod = ((CheckBox)(f.FindControl("checkdele"))).Checked;
                if (cod == true)
                {
                    foreach (GridViewRow h in GridView1.Rows)
                    {
                        ((CheckBox)(h.FindControl("checkdele"))).Enabled = false;
                    }
                    btdele.Visible = true;
                }
            }
            if (m.Rows.Count == 0)
                lbresult.Text = "No hay Alumnos Asignados";
        }

        protected void txtzona_TextChanged(object sender, EventArgs e)
        {
            bool validar = false;
            foreach (GridViewRow f in GridView1.Rows)
            {
                int p1 = Convert.ToInt32(((TextBox)(f.FindControl("txtzona"))).Text);
                int p2 = Convert.ToInt32(((TextBox)(f.FindControl("txtfinal"))).Text);
                ((TextBox)(f.FindControl("txtzona"))).BorderColor =Color.Black;
                ((TextBox)(f.FindControl("txtfinal"))).BorderColor = Color.Black;
                if ((p1 < 0 || p1 > 60))
                {
                    validar = true;
                    ((TextBox)(f.FindControl("txtzona"))).BorderColor = Color.Red;
                    
                }
                if ( (p2 < 0 || p2 > 40))
                {
                    validar = true;
                    ((TextBox)(f.FindControl("txtfinal"))).BorderColor = Color.Red;
                }
            }
                if (validar==false)
            {
                foreach (GridViewRow f in GridView1.Rows)
                {
                    int cod= Convert.ToInt32(((Label)(f.FindControl("lbcod"))).Text);
                    int pn1 = Convert.ToInt32(((TextBox)(f.FindControl("txtzona"))).Text);
                    int pn2 = Convert.ToInt32(((TextBox)(f.FindControl("txtfinal"))).Text);
                 
                    int total = pn1 + pn2;
                    string resultado="";
                    if (total >= 60)
                        resultado = "Aprobado";
                    else
                        resultado = "Reprobado";
                    misalumno.UpdateAsigacion(pn1,pn2,total,resultado, cod);
                }
                actualizar();
            }
            else
            {
                lbresult.Text = "Datos Invalidados, No se puede Asignar notas";
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            foreach (GridViewRow f in GridView1.Rows)
            {
                bool cod = ((CheckBox)(f.FindControl("checkdele"))).Checked;
            
                    int cods = Convert.ToInt32(((Label)(f.FindControl("lbcod"))).Text);
                    bool estado = ((CheckBox)(f.FindControl("checkdele"))).Checked;
                    misalumno.UpdateEstado(estado, cods);
                    
                        ((CheckBox)(f.FindControl("checkdele"))).Enabled = false;
                        btdele.Visible = true;
                    
                
            }
           
        }
        protected void btdele_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow f in GridView1.Rows)
            {
                ((CheckBox)(f.FindControl("checkdele"))).Enabled = true;
                ((CheckBox)(f.FindControl("checkdele"))).Checked = false;
                int cods = Convert.ToInt32(((Label)(f.FindControl("lbcod"))).Text);
                
                misalumno.UpdateEstado(false, cods);
              
            }
            btdele.Visible = false;
        }
    }
}