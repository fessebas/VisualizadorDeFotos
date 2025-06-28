using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VisualizadorDeFotos
{
    public partial class VisualizadorImagenes : Form
    {
        private string[] imagenes;
        private int indiceActual;
        private float zoom = 1.0f;
        private Image imagenOriginal;
        public VisualizadorImagenes()
        {
            InitializeComponent();
            pictureBoxVisual.MouseWheel += pictureBoxVisual_MouseWheel;
            pictureBoxVisual.Focus();
        }

        public VisualizadorImagenes(string[] rutasImagenes, int indiceInicial)
        {
            InitializeComponent();
            imagenes = rutasImagenes;
            indiceActual = indiceInicial;
            CargarImagen();
        }
        private void CargarImagen()
        {
            if (imagenes.Length == 0 || indiceActual < 0 || indiceActual >= imagenes.Length)
                return;

            if (imagenOriginal != null)
                imagenOriginal.Dispose();

            imagenOriginal = Image.FromFile(imagenes[indiceActual]);
            AplicarZoomYMostrar();
        }

        private void AplicarZoomYMostrar()
        {
            if (imagenOriginal == null)
                return;

            int nuevoAncho = (int)(imagenOriginal.Width * zoom);
            int nuevoAlto = (int)(imagenOriginal.Height * zoom);

            Bitmap imagenZoom = new Bitmap(imagenOriginal, new Size(nuevoAncho, nuevoAlto));
            pictureBoxVisual.Image = imagenZoom;
        }
        private void VisualizadorImagenes_Load(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0)
            {
                indiceActual--;
                CargarImagen();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (indiceActual < imagenes.Length - 1)
            {
                indiceActual++;
                CargarImagen();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (File.Exists(imagenes[indiceActual]))
            {
                File.Delete(imagenes[indiceActual]);
                imagenes = imagenes.Where((_, i) => i != indiceActual).ToArray();

                if (indiceActual >= imagenes.Length)
                    indiceActual = imagenes.Length - 1;

                if (imagenes.Length > 0)
                    CargarImagen();
                else
                    this.Close(); // si no quedan imágenes, cerrar
            }
        }

        private void btnRotar_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                imagenOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
                AplicarZoomYMostrar();
            }
        }
        private void pictureBoxVisual_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                zoom += 0.1f;
            else
                zoom = Math.Max(0.1f, zoom - 0.1f); // evitar zoom negativo

            AplicarZoomYMostrar();
        }
    }
}
