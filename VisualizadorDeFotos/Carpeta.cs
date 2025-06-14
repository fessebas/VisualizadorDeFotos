using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VisualizadorDeFotos
{
    internal class Carpeta
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public List<Imagen> Imagenes { get; set; }

        public Carpeta(string ruta)
        {
            
        }

        private void CargarImagenes()
        {
           
        }

        public List<Imagen> ListarImagenes() => Imagenes;
    }
}
