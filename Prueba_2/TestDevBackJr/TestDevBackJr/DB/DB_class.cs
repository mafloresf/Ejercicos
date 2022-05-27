using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TestDevBackJr.DB
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public decimal Sueldo { get; set; }
        public string FechaIngreso { get; set; }

        public Boolean Err { get; set; }
        public string ErrString { get; set; }
        public string CadenaConexion = ConfigurationManager.AppSettings["SQLConexion"];

        public DataSet CargaDataset(string Query)
        {
            SqlConnection coneccion;
            coneccion = new SqlConnection(CadenaConexion);
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(Query, coneccion);
                adaptador.SelectCommand.CommandTimeout = 0;
                adaptador.Fill(ds);
            }
            catch (Exception ex)
            {
                this.Err = true;
                this.ErrString = ex.Message;
            }
            finally
            {
                coneccion.Close();
                coneccion.Dispose();
            }

            return ds;
        }
        public bool IngresaUsuario ()
        {

            SqlDataReader DR;
            SqlCommand Comm;
            SqlConnection coneccion;
            coneccion = new SqlConnection(CadenaConexion);
            string Query;
            try
            {
                Query = " Insert into usuarios(Login, Nombre, Paterno, Materno)Values( ";
                Query += Login != "" ? " '" + Login + "'," : "'NULL',";
                Query += Nombre != "" ? " '" + Nombre + "'," : "'NULL',";
                Query += Paterno != "" ? " '" + Paterno + "'," : "'NULL',";
                Query += Materno != "" ? " '" + Materno + "'" : "'NULL'";
                Query += " )";
                Comm = new System.Data.SqlClient.SqlCommand();
                coneccion.Open();
                Comm.Connection = coneccion;
                Comm.CommandText = Query;
                DR = Comm.ExecuteReader();
                coneccion.Close();
                íngresaEmpleado();
            }
            catch (Exception ex)
            {
                this.Err = true;
                this.ErrString = ex.Message;
            }
            finally
            {
                
                coneccion.Dispose();
            }

            return Err;
        }
        public bool íngresaEmpleado()
        {

            SqlDataReader DR;
            SqlCommand Comm;
            SqlConnection coneccion;
            coneccion = new SqlConnection(CadenaConexion);
            string Query;
            try
            {
                Query = " Insert into empleados (userId,Sueldo,FechaIngreso) ";
                Query += "select userId,"+ Sueldo +",GETDATE() from usuarios";
                Query += " where Login = '" + Login + "'";

                Comm = new System.Data.SqlClient.SqlCommand();
                coneccion.Open();
                Comm.Connection = coneccion;
                Comm.CommandText = Query;
                DR = Comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                this.Err = true;
                this.ErrString = ex.Message;
            }
            finally
            {
                coneccion.Close();
                coneccion.Dispose();
            }

            return Err;
        }
        public bool Modifica(string Query)
        {
            SqlDataReader DR;
            SqlCommand Comm;
            SqlConnection coneccion;
            coneccion = new SqlConnection(CadenaConexion);
            try
            {
                Comm = new System.Data.SqlClient.SqlCommand();
                coneccion.Open();
                Comm.Connection = coneccion;
                Comm.CommandText = Query;
                DR = Comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                this.Err = true;
                this.ErrString = ex.Message;
            }
            finally
            {
                coneccion.Close();
                coneccion.Dispose();
            }

            return Err;
        }
    }
}