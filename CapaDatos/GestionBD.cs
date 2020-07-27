using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Controlador para pegarme a BD Microsoft SQL
using CapaDatos.Entidad;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
    public class GestionBD
    {
        SqlConnection conexion;
        SqlCommand comando;
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionPruebas"].ConnectionString;

        public int actualizarAutos(Autos objAuto)
        {
            int cantidadRegistros = -1;
            //La estructura using es para crear recursos que solo van a existir en memoria dentro de su bloque de programación 
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                //Todos los recursos que se crean dentro de este bloque, serán automaticamente destruidos cuando se termine el bloque de programacion
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Autos " +
                                  "set MARCA = @MARCA, " +
                                  "    MODELO  = @MODELO, " +
                                  "    PAIS = @PAIS, " +
                                  "    COSTO = @COSTO " +
                                  "Where IDCARRO = @IDCARRO ";
                cmd.Parameters.Add(new SqlParameter("@MARCA", objAuto.MARCA));
                cmd.Parameters.Add(new SqlParameter("@MODELO", objAuto.MODELO));
                cmd.Parameters.Add(new SqlParameter("@PAIS", objAuto.PAIS));
                cmd.Parameters.Add(new SqlParameter("@COSTO", objAuto.COSTO));
                cmd.Parameters.Add(new SqlParameter("@IDCARRO", objAuto.IDCARRO));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }
        public int eliminarAutos(Autos objAuto)
        {
            int cantidadRegistros = -1;
            //La estructura using es para crear recursos que solo van a existir en memoria dentro de su bloque de programación 
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                //Todos los recursos que se crean dentro de este bloque, serán automaticamente destruidos cuando se termine el bloque de programacion
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Autos Where IDCARRO = @IDCARRO";
                cmd.Parameters.Add(new SqlParameter("@IDCARRO", objAuto.IDCARRO));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }
        public int registrarAutos(Autos objAuto)
        {
            int cantidadRegistros = -1;
            //La estructura using es para crear recursos que solo van a existir en memoria dentro de su bloque de programación 
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {

                //Todos los recursos que se crean dentro de este bloque, serán automaticamente destruidos cuando se termine el bloque de programacion
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Autos (MARCA,MODELO,PAIS,COSTO) Values (@MARCA,@MODELO,@PAIS,@COSTO)";
                cmd.Parameters.Add(new SqlParameter("@MARCA", objAuto.MARCA));
                cmd.Parameters.Add(new SqlParameter("@MODELO", objAuto.MODELO));
                cmd.Parameters.Add(new SqlParameter("@PAIS", objAuto.PAIS));
                cmd.Parameters.Add(new SqlParameter("@COSTO", objAuto.COSTO));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }
        public DataTable cargaAutos()
        {
            DataTable objTabla = new DataTable(); //Inicializamos la Tabla
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Autos";
            comando.Connection = conexion;
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
            sqlAdaptador.Fill(objTabla); //Cargamos la tabla con los datos que me retorna el Comando.
            return objTabla;
        }

    }
}
