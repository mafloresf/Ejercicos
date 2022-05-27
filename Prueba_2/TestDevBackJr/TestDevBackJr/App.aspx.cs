using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestDevBackJr.DB;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;

namespace TestDevBackJr
{
    public partial class App : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerRegistros_Click(object sender, EventArgs e)
        {
            DataSet ds;
            try
            {
                Usuario DB = new Usuario();
                string Query = "select top(10) u.userId,u.Login,u.Nombre,u.Paterno,u.Materno, e.Sueldo, e.FechaIngreso from usuarios u inner join empleados e on u.userId = e.userId";
                ds = DB.CargaDataset(Query);
                if (DB.Err == false)
                {
                    gvUsuario.DataSource = ds;
                    gvUsuario.DataBind();
                    btnGuardar.Visible = true;
                }
                else
                {
                    lblError.Text = DB.ErrString;
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

        public void limpiaControles()
        {
            txtuserId.Text = "";
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtSueldo.Text = "";
            txtFechaIngreso.Text = "";
            txtLogin.Text = "";
            txtAumento.Text = "";

            this.lbluserId.Visible = false;
            this.txtuserId.Visible = false;
            this.txtuserId.Enabled = true;
            this.lblFechaIngreso.Visible = false;
            this.txtFechaIngreso.Visible = false;
            this.lblAumento.Visible = false;
            this.txtAumento.Visible = false;

            lblError.Text = "";
            lblError.Visible = false;

            btnAgregar.Visible = true;
            btnGeneraAumento.Visible = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
                if (txtLogin.Text != "")
                {
                    if (txtSueldo.Text != "")
                    {
                        Usuario DB = new Usuario();
                        DB.Login = txtLogin.Text;
                        DB.Nombre = txtNombre.Text;
                        DB.Paterno = txtPaterno.Text;
                        DB.Materno = txtMaterno.Text;
                        DB.Sueldo = Convert.ToDecimal(txtSueldo.Text);

                        DB.IngresaUsuario();
                    if (DB.Err == false)
                    {
                        limpiaControles();
                        btnVerRegistros_Click(null,null);
                    }
                    else
                    {
                        lblError.Text = DB.ErrString;
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Text = "El sueldo es obligatorio";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "El Login es obligatorio";
                lblError.Visible = true;
            }


        }

        protected void btnGeneraAumento_Click(object sender, EventArgs e)
        {
            string Query;
            
            if (txtuserId.Text != "")
            {
                if (txtAumento.Text != "")
                {
                    Query = "UPDATE empleados SET Sueldo = ISNULL(Sueldo + Sueldo*." + txtAumento.Text + ",Sueldo) WHERE userId = '" + txtuserId.Text + "'";
                    Usuario DB = new Usuario();
                    DB.Modifica(Query);
                    if (DB.Err == false)
                    {
                        limpiaControles();
                        btnVerRegistros_Click(null,null);
                    }
                    else
                    {
                        lblError.Text = DB.ErrString;
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Text = "No ha especificado el porcentaje del aumento";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "No se puede hacer el proceso, no cuenta con los campos necesarios";
                lblError.Visible = true;
            }
      
        }

        protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                this.txtuserId.Text = gvUsuario.Rows[indice].Cells[1].Text;
                this.txtuserId.Enabled = false;
                this.txtLogin.Text = gvUsuario.Rows[indice].Cells[2].Text;
                this.txtNombre.Text = gvUsuario.Rows[indice].Cells[3].Text;
                this.txtPaterno.Text = gvUsuario.Rows[indice].Cells[4].Text;
                this.txtMaterno.Text = gvUsuario.Rows[indice].Cells[5].Text;
                this.txtSueldo.Text = gvUsuario.Rows[indice].Cells[6].Text;
                this.txtFechaIngreso.Text = gvUsuario.Rows[indice].Cells[7].Text;
                this.lbluserId.Visible = true;
                this.txtuserId.Visible = true;
                this.lblFechaIngreso.Visible = true;
                this.txtFechaIngreso.Visible = true;
                this.lblAumento.Visible = true;
                this.txtAumento.Visible = true;


                btnAgregar.Visible = false;
                btnGeneraAumento.Visible = true;
                lblError.Text = "";
                lblError.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiaControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String ruta = ConfigurationManager.AppSettings["RutaDeArchivosCreados"];
            String separador = ",";
            StringBuilder salida = new StringBuilder();
            List<String> lista = new List<string>();
            foreach (GridViewRow row in gvUsuario.Rows)
            {
                String cadena = row.Cells[2].Text + "," + row.Cells[3].Text +" "+ row.Cells[4].Text + " " + row.Cells[5].Text + "," + row.Cells[6].Text + "," + row.Cells[7].Text;

                lista.Add(cadena);
            }  

            for (int i = 0; i < lista.Count; i++)
                salida.AppendLine(string.Join(separador, lista[i]));

            File.AppendAllText(ruta, salida.ToString());


            
        }
    }
}