using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using articulo;

namespace negocio
{
    public class ArticuloNegocio
    {
        public void eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void eliminarLogico(int id)
        {
            throw new NotImplementedException();
        }

        public List<Articulo>listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection connection = new SqlConnection();//objetos creados  para establecer la conexion tipo conextada
            SqlCommand command = new SqlCommand();//obejos creados para establecer la conexion tipo conextada
            SqlDataReader reader;//obejos creados para establecer la conexion tipo conextada

            try
            {
                //configuracion de cadena de conexion
                connection.ConnectionString = "server=DESKTOP-H342I2C\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Select Codigo, Nombre, M.Descripcion, C.Descripcion, A.Descripcion, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id AND A.IdCategoria= C.Id";
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)reader["Id"];
                    art.Codigo = (string)reader["Codigo"];
                    art.Nombre = (string)reader["Nombre"];
                    art.Descripcion = (string)reader["Descrípcion"];
                    if (!(reader.IsDBNull(reader.GetOrdinal("ImagenUrl"))))
                    art.ImagenUrl = (string)reader["ImagenUrl"];
                    art.Precio = (int)reader["Precio"];
                    art.IdMarca = new Marca();
                    art.IdMarca.Id = (int)reader["Id"];
                    art.IdMarca.Descripcion = (string)reader["Descripcion"];
                    art.IdCategoria = new Categoria();
                    art.IdCategoria.Id = (int)reader["Id"];
                    art.IdCategoria.Descripcion = (string)reader["Descripcion"];
                        lista.Add(art);
                }   
                connection.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static implicit operator List<object>(ArticuloNegocio v)
        {
            throw new NotImplementedException();
        }
    }
}
