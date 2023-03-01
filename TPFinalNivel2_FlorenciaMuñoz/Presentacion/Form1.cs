using articulo;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormListadoArticulo : Form//ACA VAN LAS FUNCIONALIDADES
    {
        private List<Articulo> listaArticulo;
        private object seleccionado;

        public FormListadoArticulo()
        {
            InitializeComponent();
        }

        private void FormListadoArticulo_Load(object sender, EventArgs e)
        {
            cargar();


        }
        private void cargar()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulo = negocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();
                cargarImagen(listaArticulo[0].ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pboxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pboxArticulo.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.ImagenUrl);
            }
        }


        private void cargarImagen(object imagenUrl)
        {
            throw new NotImplementedException();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloAgregarModificar alta = new ArticuloAgregarModificar();
            alta.ShowDialog();
            cargar();
        }

        private void DgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            ArticuloAgregarModificar modificar = new ArticuloAgregarModificar();
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar(true);

        }
        private void eliminar(bool logico = false)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    if (logico)
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminar(seleccionado.Id);
                    cargar();
                }  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}