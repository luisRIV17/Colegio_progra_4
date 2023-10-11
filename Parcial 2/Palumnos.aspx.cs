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
    public partial class Palumnos : System.Web.UI.Page
    {
        
        DepartamentoTableAdapter misadepas = new DepartamentoTableAdapter();
        MunicipioTableAdapter mismunis = new MunicipioTableAdapter();
        alumno_codTableAdapter mialumnocod = new alumno_codTableAdapter();
        DataTable1TableAdapter m = new DataTable1TableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable m = new DataTable();
                m = misadepas.GetDataDepa();
                dropdepa.DataSource = misadepas.GetDataDepa();
                dropdepa.DataValueField = "cod_depto";
                dropdepa.DataTextField = "nombre_depto";
                dropdepa.SelectedValue = m.Rows[0][0].ToString();
                dropdepa.DataBind();
                actualizar();
            }
        }
        public void actualizar()
        {
            dropmuni.DataSource = mismunis.GetMuni(Convert.ToInt32(dropdepa.SelectedValue));
            dropmuni.DataValueField = "cod_municipio";
            dropmuni.DataTextField = "nombre_municipio";
            dropmuni.DataBind();
            DataTable ta = new DataTable();
            ta = m.GetAlumno();
            GridView1.DataSource = m.GetAlumno();
            GridView1.DataBind();
            Button2.Enabled = bteliminar.Enabled = false;
            Button1.Enabled = true;
            txtcod.Enabled = true;
            lbresult.Text=txtcod.Text = txtnombre.Text = txtape.Text = txtfecha.Text =txtcontraseña.Text=txttelefono.Text=txtusuario.Text= txtdirec.Text = txtcorreo.Text="";
            if (ta.Rows.Count != 0)
                txtcod.Text = (Convert.ToInt32(ta.Rows[ta.Rows.Count - 1][0].ToString()) + 1).ToString();
            else
                txtcod.Text = "1";

            txtcod.Enabled = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                m.InsertAlumnooo(txtcod.Text, txtnombre.Text, txtape.Text, Convert.ToDateTime(txtfecha.Text), txtdirec.Text, txtcorreo.Text, txttelefono.Text, txtusuario.Text, txtcontraseña.Text, dropmuni.SelectedValue.ToString());
                actualizar();
                Response.Write("<script language=javascript> alert('Datos Registrados con Exito'); </script>");
            }
            catch
            {
                lbresult.Text = "Ocurrio un error";
            }
           
        }

        protected void dropdepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropmuni.DataSource = mismunis.GetMuni(Convert.ToInt32(dropdepa.SelectedValue));
            dropmuni.DataValueField = "cod_municipio";
            dropmuni.DataTextField = "nombre_municipio";
            dropmuni.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bteliminar.Enabled = Button2.Enabled = true;
            Button1.Enabled = false;
            DataTable mitabla = new DataTable();
            mitabla = mialumnocod.GetDataalumnooocod(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            foreach(DataRow f in mitabla.Rows)
            {
                txtcod.Text = f[0].ToString();
                txtnombre.Text = f[1].ToString();
                txtape.Text = f[2].ToString();
                txtfecha.Text = f[3].ToString();
                txtdirec.Text = f[4].ToString();
                dropdepa.SelectedValue = f[10].ToString();
               
                txtcorreo.Text = f[5].ToString();
                txttelefono.Text = f[6].ToString();
                txtusuario.Text = f[7].ToString();
                txtcontraseña.Text = f[8].ToString();

            }
            dropmuni.DataSource = mismunis.GetMuni(Convert.ToInt32(dropdepa.SelectedValue));
            dropmuni.DataValueField = "cod_municipio";
            dropmuni.DataTextField = "nombre_municipio";
            dropmuni.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                m.UpdateAlumno(txtnombre.Text, txtape.Text, Convert.ToDateTime(txtfecha.Text), txtdirec.Text, txtcorreo.Text, txttelefono.Text, txtusuario.Text, txtcontraseña.Text, dropmuni.SelectedValue.ToString(), txtcod.Text);
                actualizar();
            }
            catch
            {
                lbresult.Text = "Ocurrio un error";
            }
        }

        protected void bteliminar_Click(object sender, EventArgs e)
        {
            try
            {
                m.DeleteAlumno(txtcod.Text);
                actualizar();
            }
            catch
            {
                lbresult.Text = "Ocurrio un error";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = m.Getbusqueda(txtbusqueda.Text);
            GridView1.DataBind();
        }

        protected void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = m.Getbusqueda(txtbusqueda.Text);
            GridView1.DataBind();
        }
    }
}