using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        /*Deberá ser una aplicación de escritorio que contemple la administración de artículos. 
         Las funcionalidades que deberá tener la aplicación serán:
         Listado de artículos.
         Búsqueda de artículos por distintos criterios.
         Agregar artículos.
         Modificar artículos.
         Eliminar artículos.
         Ver detalle de un artículo.*/
                /// <summary>
                /// Punto de entrada principal para la aplicación.
                /// </summary>
                [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormListadoArticulo());
        }
    }
}
