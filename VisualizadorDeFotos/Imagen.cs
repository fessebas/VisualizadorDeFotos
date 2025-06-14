using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VisualizadorDeFotos
{
    internal class Imagen
    {
        public string Ruta { get; set; }
        public string Nombre { get; set; }
        public string Formato { get; set; }
        public long Tamaño { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Rotacion { get; set; }

        public Imagen(string ruta)
        {
           
        }

        public Image Mostrar()
        {
            
        }

        public void Rotar(int grados)
        {
            
        }

        public string ObtenerInfo()
        {
            
        }
    }
}
