using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace articulo
{
    public class Articulo//es lo que contiene la tabla, las columnas
    {
        public static Articulo seleccionado;

        public static Articulo seleccion { get; set; }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public int Precio { get; set; }
        public Marca IdMarca { get; set; }
        public Categoria IdCategoria { get; set; }

    }
}
