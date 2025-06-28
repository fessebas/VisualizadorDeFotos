using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualizadorDeFotos
{
    public partial class SelecImagen : Form
    {
        public SelecImagen()
        {
            InitializeComponent();
            treeViewDirectorios.AfterSelect += treeViewDirectorios_AfterSelect;
        }

        private void BtnAbrirCarpeta_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona una carpeta con imágenes";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaSeleccionada = folderDialog.SelectedPath;
                    MostrarImagenesDesdeCarpeta(rutaSeleccionada);

                    // Mostrar carpeta en TreeView
                    MostrarCarpetaEnTreeView(rutaSeleccionada);

                    // Actualizar info en la parte superior
                    ActualizarInfoSuperior(rutaSeleccionada);
                }
            }
        }
        private void MostrarImagenesDesdeCarpeta(string ruta)
        {
            string[] extensiones = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

            var archivos = Directory.GetFiles(ruta)
                            .Where(f => extensiones.Contains(Path.GetExtension(f).ToLower()))
                            .ToArray();

            FlypGaleria.Controls.Clear();

            if (archivos.Length == 0)
                return;

            for (int i = 0; i < archivos.Length; i++)
            {
                string archivo = archivos[i];

                PictureBox pic = new PictureBox
                {
                    Size = new Size(160, 160),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(10),
                    Image = Image.FromFile(archivo),
                    Cursor = Cursors.Hand, // Para indicar que es clickeable
                    Tag = i 
                };

                // Evento de doble clic para abrir el visualizador
                pic.DoubleClick += (s, e) =>
                {
                    int indice = (int)((PictureBox)s).Tag;
                    VisualizadorImagenes visor = new VisualizadorImagenes(archivos, indice);
                    visor.ShowDialog();
                };

                FlypGaleria.Controls.Add(pic);
            }
        }

        private void treeViewDirectorios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string ruta = e.Node.Tag.ToString();
            MostrarImagenesDesdeCarpeta(ruta);
            ActualizarInfoSuperior(ruta);
        }

        private void MostrarCarpetaEnTreeView(string ruta)
        {
            treeViewDirectorios.Nodes.Clear();

            TreeNode nodoRaiz = new TreeNode(Path.GetFileName(ruta));
            nodoRaiz.Tag = ruta;

            // Agrega las subcarpetas recursivamente
            AgregarSubcarpetas(nodoRaiz, ruta);

            treeViewDirectorios.Nodes.Add(nodoRaiz);
            nodoRaiz.Expand(); // Opcional: expande la raíz al inicio
        }
        private void AgregarSubcarpetas(TreeNode nodoPadre, string rutaPadre)
        {
            try
            {
                string[] subcarpetas = Directory.GetDirectories(rutaPadre);

                foreach (string subcarpeta in subcarpetas)
                {
                    TreeNode nodoHijo = new TreeNode(Path.GetFileName(subcarpeta));
                    nodoHijo.Tag = subcarpeta;

                    // Llamada recursiva para seguir añadiendo sub-subcarpetas
                    AgregarSubcarpetas(nodoHijo, subcarpeta);

                    nodoPadre.Nodes.Add(nodoHijo);
                }
            }
            catch (UnauthorizedAccessException)
            {
               
            }
        }
        private void ActualizarInfoSuperior(string ruta)
        {
            string[] extensiones = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            var archivos = Directory.GetFiles(ruta)
                            .Where(f => extensiones.Contains(Path.GetExtension(f).ToLower()))
                            .ToArray();

            string nombreCarpeta = Path.GetFileName(ruta);
            lblInfoCarpeta.Text = $"{nombreCarpeta} - {archivos.Length} fotos";
        }
    }
}
