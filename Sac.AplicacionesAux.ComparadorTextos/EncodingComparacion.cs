using System.Text;

namespace Sac.AplicacionesAux.ComparadorTextos
{
    /// <summary>
    /// Clase empleada para establecer la configuracion de Codificacion que se empleará en la comparación de dos ficheros.
    /// </summary>
    public class EncodingComparacion
    {
        private Encoding primerArchivo;
        private Encoding segundoArchivo;
        private Encoding archivoSalida;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="primerArchivo"></param>
        /// <param name="segundoArchivo"></param>
        /// <param name="archivoSalida"></param>
        public EncodingComparacion(Encoding primerArchivo, Encoding segundoArchivo, Encoding archivoSalida)
        {
            this.primerArchivo = primerArchivo;
            this.segundoArchivo = segundoArchivo;
            this.archivoSalida = archivoSalida;
        }

        public Encoding PrimerArchivo
        {
            get
            {
                return primerArchivo;
            }

            set
            {
                primerArchivo = value;
            }
        }

        public Encoding SegundoArchivo
        {
            get
            {
                return segundoArchivo;
            }

            set
            {
                segundoArchivo = value;
            }
        }

        public Encoding ArchivoSalida
        {
            get
            {
                return archivoSalida;
            }

            set
            {
                archivoSalida = value;
            }
        }

    }
}
