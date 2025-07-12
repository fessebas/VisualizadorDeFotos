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
        private bool actualizandoZoomUI = false;
        private bool infoVisible = false;
        private const int anchoPanelInfo = 300;


        public VisualizadorImagenes()
        {
            InitializeComponent();
      
            pictureBoxVisual.TabStop = true;
            this.KeyPreview = true;
            pictureBoxVisual.MouseWheel += pictureBoxVisual_MouseWheel;
            pictureBoxVisual.Focus();
        }

        public VisualizadorImagenes(string[] rutasImagenes, int indiceInicial)
        {
            InitializeComponent();
            imagenes = rutasImagenes;
            indiceActual = indiceInicial;

            panelContenedor.AutoScroll = true;       
            pictureBoxVisual.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxVisual.MouseWheel += pictureBoxVisual_MouseWheel;

            this.Resize += (s, e) => AplicarZoomYMostrar();

            CargarImagen();

        }
        private void CargarImagen()
        {
            if (imagenes.Length == 0 || indiceActual < 0 || indiceActual >= imagenes.Length)
                return;

            if (imagenOriginal != null)
            {
                imagenOriginal.Dispose();
                imagenOriginal = null;
            }

            //  Carga sin bloquear el archivo
            using (FileStream fs = new FileStream(imagenes[indiceActual], FileMode.Open, FileAccess.Read))
            {
                Image temp = Image.FromStream(fs);
                imagenOriginal = new Bitmap(temp); // Clonamos para evitar bloqueo
            }

            CalcularZoomInicial();  // 🔍 Zoom inicial al abrir
            AplicarZoomYMostrar();  // 🎯 Mostrar imagen con zoom actual

            if (infoVisible && panelInfo.Visible)
                MostrarInformacionImagen(imagenes[indiceActual]);

        }

        private void CalcularZoomInicial()
        {
            float zoomWidth = (float)panelContenedor.Width / imagenOriginal.Width;
            float zoomHeight = (float)panelContenedor.Height / imagenOriginal.Height;
            zoom = Math.Min(zoomWidth, zoomHeight);
        }
        private void AplicarZoomYMostrar()
        {
            if (imagenOriginal == null)
                return;

            int nuevoAncho = (int)(imagenOriginal.Width * zoom);
            int nuevoAlto = (int)(imagenOriginal.Height * zoom);

            Bitmap imagenZoom = new Bitmap(imagenOriginal, new Size(nuevoAncho, nuevoAlto));
            pictureBoxVisual.Image = imagenZoom;
            pictureBoxVisual.Size = imagenZoom.Size;

            pictureBoxVisual.Location = new Point(
            Math.Max((panelContenedor.Width - pictureBoxVisual.Width - (infoVisible ? anchoPanelInfo : 0)) / 2, 0),
                Math.Max((panelContenedor.Height - pictureBoxVisual.Height) / 2, 0)
              );
        }

        private void VisualizadorImagenes_Resize(object sender, EventArgs e)
        {
            // Recentrar la imagen cuando se cambia el tamaño de la ventana
            AplicarZoomYMostrar();
        }
        private void VisualizadorImagenes_Load(object sender, EventArgs e)
        {
            cmbZoomPorcentaje.Items.AddRange(new object[]
            {
        "50%", "75%", "100%", "125%", "150%", "200%", "300%"
            });

            cmbZoomPorcentaje.SelectedItem = "100%";
            trackZoom.Value = 100;
            lblZoomActual.Text = "100%";
            
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
            if (imagenes.Length == 0 || indiceActual < 0 || indiceActual >= imagenes.Length)
                return;

            string rutaImagen = imagenes[indiceActual];

            // 🔒 Confirmación antes de eliminar
            var confirmar = MessageBox.Show("¿Estás seguro de que deseas eliminar esta imagen?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                //  Liberar el PictureBox antes de eliminar el archivo
                if (pictureBoxVisual.Image != null)
                {
                    pictureBoxVisual.Image.Dispose();
                    pictureBoxVisual.Image = null;
                }

                //  Liberar imagenOriginal si está cargada
                if (imagenOriginal != null)
                {
                    imagenOriginal.Dispose();
                    imagenOriginal = null;
                }

                //  Eliminar el archivo físicamente
                File.Delete(rutaImagen);

                //  Actualiza las imágenes
                imagenes = imagenes.Where(img => img != rutaImagen).ToArray();

                MessageBox.Show("Imagen eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (imagenes.Length == 0)
                {
                    this.Close(); // Se cierra si no hay más imágenes
                    return;
                }

                if (indiceActual >= imagenes.Length)
                    indiceActual = imagenes.Length - 1;

                CargarImagen();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"No se pudo eliminar la imagen.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            float zoomPaso = 0.1f;

            if (e.Delta > 0)
                zoom += zoomPaso;
            else if (zoom > 0.2f)
                zoom -= zoomPaso;

            AplicarZoomYMostrar();

            // Sincronizar controles
            actualizandoZoomUI = true;
            int porcentaje = (int)(zoom * 100);
            porcentaje = Math.Max(trackZoom.Minimum, Math.Min(trackZoom.Maximum, porcentaje));
            trackZoom.Value = porcentaje;
            lblZoomActual.Text = $"{porcentaje}%";
            cmbZoomPorcentaje.Text = $"{porcentaje}%";
            actualizandoZoomUI = false;
        }

        private void trackZoom_Scroll(object sender, EventArgs e)
        {
            if (actualizandoZoomUI) return;

            zoom = trackZoom.Value / 100f;
            AplicarZoomYMostrar();
            lblZoomActual.Text = $"{trackZoom.Value}%";

            // Sincronizar ComboBox
            actualizandoZoomUI = true;
            cmbZoomPorcentaje.Text = $"{trackZoom.Value}%";
            actualizandoZoomUI = false;
        }

        private void cmbZoomPorcentaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizandoZoomUI) return;

            string texto = cmbZoomPorcentaje.SelectedItem.ToString().Replace("%", "");
            if (int.TryParse(texto, out int porcentaje))
            {
                zoom = porcentaje / 100f;
                AplicarZoomYMostrar();

                actualizandoZoomUI = true;
                trackZoom.Value = Math.Min(trackZoom.Maximum, Math.Max(trackZoom.Minimum, porcentaje));
                lblZoomActual.Text = $"{porcentaje}%";
                actualizandoZoomUI = false;
            }
        }

        private void MostrarInformacionImagen(string rutaImagen)
        {
            try
            {
                FileInfo info = new FileInfo(rutaImagen);
                using (var img = Image.FromFile(rutaImagen))
                {
                    lblNombreArchivo.Text = $"\ud83d\uddcb {info.Name}";
                    lblFecha.Text = $"\ud83d\udcc5 {info.LastWriteTime:dd MMM yyyy - hh:mm tt}";
                    lblDimensiones.Text = $"\ud83d\udccf {img.Width} × {img.Height} px";
                    lblTamaño.Text = $"\ud83d\udcbe {(info.Length / 1024.0):F1} KB";
                }
            }
            catch
            {
                lblNombreArchivo.Text = "Error";
                lblFecha.Text = lblDimensiones.Text = lblTamaño.Text = "";
            }
        }        

        private void cerrarPanel_Click(object sender, EventArgs e)
        {
            panelInfo.Visible = false;
            panelInfo.Dock = DockStyle.None;

            infoVisible = false; // <- actualizamos la variable de estado

            panelContenedor.Width = this.ClientSize.Width;
            AplicarZoomYMostrar(); // <- recentramos la imagen correctamente
        }

        private void btnInfo_Click_1(object sender, EventArgs e)
        {
            infoVisible = !infoVisible;

            if (infoVisible)
            {
                panelInfo.Visible = true;
                panelInfo.Dock = DockStyle.Right;
                panelContenedor.Width = this.ClientSize.Width - anchoPanelInfo;
                MostrarInformacionImagen(imagenes[indiceActual]);
            }
            else
            {
                panelInfo.Visible = false;
                panelInfo.Dock = DockStyle.None;
                panelContenedor.Width = this.ClientSize.Width;
            }

            AplicarZoomYMostrar(); // Recentrar imagen
        }
    }
}

//HOlA