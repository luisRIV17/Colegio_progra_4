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
    public partial class Login : System.Web.UI.Page
    {
        DataTable1TableAdapter misalumnos = new DataTable1TableAdapter();
        ProfesorTableAdapter misprofesores = new ProfesorTableAdapter();
        DataTable1TableAdapter misalumno = new DataTable1TableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            bool bandera = true;
            if(bandera==true)
            {
                DataTable tabla = new DataTable();
                tabla = misprofesores.GetDataProfesor();
                foreach(DataRow f in tabla.Rows)
                {
                    if(f[6].ToString()==txt1.Text && f[7].ToString()==txt2.Text)
                    {
                        bandera = false;
                        Session.Add("usuario", f[6].ToString());
                        Clasgeneral.nombre = f[1].ToString() + " " + f[2].ToString();
                        Clasgeneral.cod = f[0].ToString();
                        Clasgeneral.nivel = "Profesor";
                        Response.Redirect("DefaultP.aspx");
                        
                    }
                }
            }
            if (bandera == true)
            {
                DataTable tabla = new DataTable();
                tabla = misalumno.GetAlumno();
                foreach (DataRow f in tabla.Rows)
                {
                    if (f[9].ToString() == txt1.Text && f[10].ToString() == txt2.Text)
                    {
                        bandera = false;
                        Session.Add("usuario", f[9].ToString());
                        Clasgeneral.nombre = f[1].ToString() + " " + f[2].ToString();
                        Clasgeneral.cod = f[0].ToString();
                        Clasgeneral.nivel = "Alumno";
                        Response.Redirect("DefaultA.aspx");

                    }
                }
            }
            if(bandera==true)
            {
                if ("admin" == txt1.Text && "123" == txt2.Text)
                {
                    bandera = false;
                    Session.Add("usuario", "admin");
                    Clasgeneral.nombre = "Luis Rivera";
                    Clasgeneral.nivel = "Administrador";
                    Response.Redirect("Default.aspx");
                }
            }
            if (bandera==true)
            {
                lbresult.Text = "Usuario o Contraseña Incorrectos";
            }
        }
    }
}