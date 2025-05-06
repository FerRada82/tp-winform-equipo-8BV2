using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using dominio;
using negocio;

namespace TPWinForm_equipo_8B_V2
{
    public partial class FrmPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            dgvArticulos.DataSource = listaArticulo;
            cargarImagen(listaArticulo[0].UrlImagenes);
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e) //selecciona la grilla en el DVG
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenes);
        }

        private void cargarImagen(string imagen) //carga las imagenes en el picturebox
        {
            try
            {
                pbxArticulos.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxArticulos.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

    }
}
