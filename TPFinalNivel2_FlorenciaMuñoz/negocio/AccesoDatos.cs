using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace negocio//coneccion base de datos
{
    public class AccesoDatos
    {
        //basico para leer datos con ADO
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader//leer
        {
            get { return reader; }
        }
        public AccesoDatos()//acceso
        {
            connection = new SqlConnection("server=DESKTOP-H342I2C\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            command = new SqlCommand();
        }
        public void ejecutarLectura()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if(reader != null)
                reader.Close();
            connection.Close();
        }
        
    }
}
