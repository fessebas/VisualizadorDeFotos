using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private bool esFavorito = false;

        private bool modoRecorte = false;
        private Point puntoInicioRecorte;
        private Rectangle rectanguloRecorte;
        private bool estaArrastrando = false;

        private float brillo = 0.0f;     
        private float contraste = 1.0f;

        private Image imagenOriginalBase; // Nueva copia base sin efectos
        private Bitmap imagenEditable; // Nueva imagen con recortes/ajustes acumulados
        private string rutaImagenActual;

        private Bitmap imagenRecortada = null;
        private Bitmap imagenAjustada = null;

        
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

            //  Guardamos ruta actual de la imagen cargada
            rutaImagenActual = imagenes[indiceActual]; 

            // Carga sin bloquear el archivo
            using (FileStream fs = new FileStream(rutaImagenActual, FileMode.Open, FileAccess.Read))
            {
                Image temp = Image.FromStream(fs);
                imagenOriginal = new Bitmap(temp);      // Clonamos para evitar bloqueo
                imagenOriginalBase = new Bitmap(temp);  // Base para aplicar ajustes
                imagenEditable = new Bitmap(temp);      // Imagen que se modificará y guardará
            }

            CalcularZoomInicial();  //  Zoom inicial al abrir
            AplicarZoomYMostrar();  //  Mostrar imagen con zoom actual

            if (infoVisible && panelInfo.Visible)
                MostrarInformacionImagen(rutaImagenActual);

            MostrarInfoImagenBreve(rutaImagenActual);

            // 🔁 Reiniciar sliders y valores de brillo/contraste si quieres (opcional)
            trackBrillo.Value = 0;
            trackContraste.Value = 0;
            brillo = 0;
            contraste = 1.0f;
            
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

            string rutaOriginal = imagenes[indiceActual]; // Imagen original a eliminar

            var confirmar = MessageBox.Show("¿Estás seguro de que deseas eliminar esta imagen?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                //  Liberar todas las referencias a imágenes
                pictureBoxVisual.Image?.Dispose();
                pictureBoxVisual.Image = null;

                imagenOriginal?.Dispose();
                imagenOriginal = null;

                imagenOriginalBase?.Dispose();
                imagenOriginalBase = null;

                imagenRecortada?.Dispose();
                imagenRecortada = null;

                imagenAjustada?.Dispose();
                imagenAjustada = null;

                //  Forzar recolección de basura para liberar manejadores de archivo
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //  Eliminar la imagen del disco
                File.Delete(rutaOriginal);

                //  Actualizar lista de imágenes
                imagenes = imagenes.Where(img => img != rutaOriginal).ToArray();

                MessageBox.Show("Imagen eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //  Verificar si quedan imágenes
                if (imagenes.Length == 0)
                {
                    this.Close(); // Cierra el visor si no hay más imágenes
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

        private void pictureBoxVisual_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoRecorte && e.Button == MouseButtons.Left)
            {
                estaArrastrando = true;
                puntoInicioRecorte = e.Location;
                rectanguloRecorte = new Rectangle(e.Location, new Size(0, 0));
                pictureBoxVisual.Invalidate();
            }
        }

        private void pictureBoxVisual_MouseMove(object sender, MouseEventArgs e)
        {
            if (modoRecorte && estaArrastrando)
            {
                rectanguloRecorte = new Rectangle(
                    Math.Min(puntoInicioRecorte.X, e.X),
                    Math.Min(puntoInicioRecorte.Y, e.Y),
                    Math.Abs(e.X - puntoInicioRecorte.X),
                    Math.Abs(e.Y - puntoInicioRecorte.Y));
                pictureBoxVisual.Invalidate();
            }
        }

        private void pictureBoxVisual_MouseUp(object sender, MouseEventArgs e)
        {
            if (modoRecorte && estaArrastrando)
            {
                estaArrastrando = false;
                // Muestra botón "Aplicar Recorte"
                btnAplicarRecorte.Visible = true;
            }
        }

        private void pictureBoxVisual_Paint(object sender, PaintEventArgs e)
        {
            if (modoRecorte && rectanguloRecorte != Rectangle.Empty)
            {
                // Crea un área sombreada afuera del rectángulo
                using (Brush sombra = new SolidBrush(Color.FromArgb(120, Color.Black)))
                {
                    Region regionExterior = new Region(pictureBoxVisual.ClientRectangle);
                    regionExterior.Exclude(rectanguloRecorte);
                    e.Graphics.FillRegion(sombra, regionExterior);
                }

                // Dibuja un borde blanco alrededor del área de recorte
                using (Pen borde = new Pen(Color.White, 2))
                {
                    e.Graphics.DrawRectangle(borde, rectanguloRecorte);
                }

                // Opcional: dibujar una línea discontinua interna como estilo Windows
                using (Pen punteado = new Pen(Color.LightGray))
                {
                    punteado.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    Rectangle interno = rectanguloRecorte;
                    interno.Inflate(-4, -4);
                    e.Graphics.DrawRectangle(punteado, interno);
                }
            }
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

            infoVisible = false; //  actualizamos la variable de estado

            panelContenedor.Width = this.ClientSize.Width;
            AplicarZoomYMostrar(); //  recentramos la imagen correctamente
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
        private void MostrarInfoImagenBreve(string ruta)
        {
            FileInfo info = new FileInfo(ruta);
            using (var img = Image.FromFile(ruta))
            {
                lblInfoImagen.Text = $"{img.Width}×{img.Height}px, {(info.Length / 1024.0):F1} KB";
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panelEditar.Visible = !panelEditar.Visible;
        }

       
        private void pictureBoxFavorito_Click(object sender, EventArgs e)
        {
            esFavorito = !esFavorito;

            pictureBoxFavorito.Image = esFavorito
                ? Properties.Resources.star_filled // Estrella amarilla
                : Properties.Resources.star_empty; // Estrella vacía
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            modoRecorte = true;
            estaArrastrando = false;
            rectanguloRecorte = Rectangle.Empty;
            btnAplicarRecorte.Visible = false;
   
            pictureBoxVisual.Cursor = Cursors.Cross; // Cursor tipo cruz
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            panelAjustes.Visible = !panelAjustes.Visible;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (imagenEditable == null)
            {
                MessageBox.Show("No hay cambios para guardar.");
                return;
            }

            string rutaOriginal = imagenes[indiceActual];
            string carpeta = Path.GetDirectoryName(rutaOriginal);
            string nombreSinExtension = Path.GetFileNameWithoutExtension(rutaOriginal);
            string extension = Path.GetExtension(rutaOriginal);
            string nuevaRuta = Path.Combine(carpeta, nombreSinExtension + "_editado" + extension);

            try
            {
                imagenEditable.Save(nuevaRuta);
                MessageBox.Show("Imagen guardada como:\n" + nuevaRuta, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicarRecorte_Click(object sender, EventArgs e)
        {
            if (imagenOriginal == null || rectanguloRecorte == Rectangle.Empty)
                return;

            Bitmap bmpOriginal = new Bitmap(imagenOriginal);
            Rectangle recorteReal = new Rectangle(
                (int)(rectanguloRecorte.X / zoom),
                (int)(rectanguloRecorte.Y / zoom),
                (int)(rectanguloRecorte.Width / zoom),
                (int)(rectanguloRecorte.Height / zoom)
            );

            if (recorteReal.Width <= 0 || recorteReal.Height <= 0)
                return;

            Bitmap bmpRecortado = bmpOriginal.Clone(recorteReal, bmpOriginal.PixelFormat);

            imagenEditable?.Dispose();
            imagenEditable = bmpRecortado;

            imagenOriginalBase?.Dispose();
            imagenOriginalBase = (Bitmap)bmpRecortado.Clone();

            imagenOriginal?.Dispose();
            imagenOriginal = (Bitmap)bmpRecortado.Clone();

            modoRecorte = false;
            btnAplicarRecorte.Visible = false;
            AplicarZoomYMostrar();
            pictureBoxVisual.Cursor = Cursors.Default;

        }

        private void trackBrillo_ValueChanged(object sender, EventArgs e)
        {        
            AplicarAjustes(); // Se aplica directamente sin esperar nada
        }

        private void trackContraste_ValueChanged(object sender, EventArgs e)
        {            
            AplicarAjustes();
        }
       
        private void AplicarAjustes()
        {
            if (imagenOriginalBase == null)
                return;

            // Suponiendo que los valores del TrackBar van de -100 a 100
            float valorBrillo = trackBrillo.Value / 100f;  // -1.0 a 1.0
            float valorContraste = (100f + trackContraste.Value) / 100f; // Normalizado: 0.0 a 2.0

            Bitmap imagenAjustada = new Bitmap(imagenOriginalBase.Width, imagenOriginalBase.Height);

            using (Graphics g = Graphics.FromImage(imagenAjustada))
            {
                float[][] ptsArray = {
            new float[] { valorContraste, 0, 0, 0, 0 },
            new float[] { 0, valorContraste, 0, 0, 0 },
            new float[] { 0, 0, valorContraste, 0, 0 },
            new float[] { 0, 0, 0, 1f, 0 },
            new float[] { valorBrillo, valorBrillo, valorBrillo, 0, 1 }
        };

                ColorMatrix cm = new ColorMatrix(ptsArray);
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);

                g.DrawImage(imagenOriginalBase,
                    new Rectangle(0, 0, imagenOriginalBase.Width, imagenOriginalBase.Height),
                    0, 0, imagenOriginalBase.Width, imagenOriginalBase.Height,
                    GraphicsUnit.Pixel, ia);
            }

            imagenEditable?.Dispose();
            imagenEditable = (Bitmap)imagenAjustada.Clone();

            imagenOriginal?.Dispose();
            imagenOriginal = (Bitmap)imagenAjustada.Clone();

            pictureBoxVisual.Image = imagenAjustada;
            pictureBoxVisual.Size = imagenAjustada.Size;

            AplicarZoomYMostrar();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (modoRecorte && keyData == Keys.Escape)
            {
                modoRecorte = false;
                rectanguloRecorte = Rectangle.Empty;
                btnAplicarRecorte.Visible = false;
                pictureBoxVisual.Cursor = Cursors.Default;
                pictureBoxVisual.Invalidate();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

       
    }
}
