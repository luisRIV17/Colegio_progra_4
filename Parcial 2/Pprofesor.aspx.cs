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
    public partial class Pprofesor : System.Web.UI.Page
    {
        ProfesorTableAdapter misprofeseores = new ProfesorTableAdapter();
        DepartamentoTableAdapter misadepas = new DepartamentoTableAdapter();
        MunicipioTableAdapter mismunis = new MunicipioTableAdapter();
        profesor_codTableAdapter misprofecod = new profesor_codTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable m = new DataTable();
                m= misprofeseores.GetDataProfesor();
                GridView1.DataSource = misprofeseores.GetDataProfesor();
                GridView1.DataBind();
                dropdepa.DataSource = misadepas.GetDataDepa();
                dropdepa.DataValueField = "cod_depto";
                dropdepa.DataTextField = "nombre_depto";
                dropdepa.DataBind();
                dropdepa.SelectedValue = m.Rows[0][0].ToString();
                actualizar();
            }
        }
        public void actualizar()
        {
            dropmuni.DataSource = mismunis.GetMuni(Convert.ToInt32(dropdepa.SelectedValue));
            dropmuni.DataValueField = "cod_municipio";
            dropmuni.DataTextField = "nombre_municipio";
            dropmuni.DataBind();
            checkestado.Checked = true;
            checkestado.Enabled = false;
            GridView1.DataSource = misprofeseores.GetDataProfesor();
            GridView1.DataBind();
            Button2.Enabled = bteliminar.Enabled = false;
            Button1.Enabled = txtdpi.Enabled=true;
            txtdpi.Enabled = true;
            lbresult.Text = txtdpi.Text = txtnombre.Text = txtape.Text  = txtcontraseña.Text = txttelefono.Text = txtusuario.Text = txtdirec.Text =  "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                misprofeseores.InsertProfesor(txtdpi.Text, txtnombre.Text, txtape.Text, txtdirec.Text, txttelefono.Text,checkestado.Checked, txtusuario.Text, txtcontraseña.Text, dropmuni.SelectedValue.ToString() );
                actualizar();
                Response.Write("<script language=javascript> alert('Datos Registrados con Exito'); </script>");
            }
            catch
            {
                lbresult.Text = "Ocurrio un error";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                misprofeseores.UpdateProfesor(txtnombre.Text, txtape.Text, txtdirec.Text, txttelefono.Text, checkestado.Checked, txtusuario.Text, txtcontraseña.Text, dropmuni.SelectedValue.ToString(), txtdpi.Text);
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
                misprofeseores.DeleteProfesor(txtdpi.Text);
                actualizar();
            }
            catch
            {
                lbresult.Text = "Ocurrio un error";
            }
        }

        protected void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = misprofeseores.Getbusqueda(txtbusqueda.Text);
            GridView1.DataBind();
        }

        protected void dropdepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropmuni.DataSource = mismunis.GetMuni(Convert.ToInt32(dropdepa.SelectedValue));
            dropmuni.DataValueField = "cod_municipio";
            dropmuni.DataTextField = "nombre_municipio";
            dropmuni.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = misprofeseores.Getbusqueda(txtbusqueda.Text);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            checkestado.Enabled = true;
            bteliminar.Enabled = Button2.Enabled = true;
            Button1.Enabled = false;
            txtdpi.Enabled = false;
            DataTable mitabla = new DataTable();
            mitabla = misprofecod.GetProfesooor(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            foreach (DataRow f in mitabla.Rows)
            {
                txtdpi.Text = f[0].ToString();
                txtnombre.Text = f[1].ToString();
                txtape.Text = f[2].ToString();
                txtdirec.Text = f[3].ToString();
                txttelefono.Text = f[4].ToString();
                checkestado.Checked = Convert.ToBoolean(f[5].ToString());
                txtusuario.Text = f[6].ToString();
                txtcontraseña.Text = f[7].ToString();
                dropdepa.SelectedValue = f[8].ToString();
            }
            dropmuni.DataSource = mismunis.GetMuni(Convert.ToInt32(dropdepa.SelectedValue));
            dropmuni.DataValueField = "cod_municipio";
            dropmuni.DataTextField = "nombre_municipio";
            dropmuni.DataBind();

        }
    }
}