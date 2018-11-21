using Sac.AplicacionesAux.ComparadorTextos;
using System;
using System.IO;
using System.Text;

namespace Sac.AplicacionesAux.ComparadorTextos
{
    public enum TipoComparacion
    {
        Diferencia,
        XOR,
        AND
    }

    public class ProcesoComparador
    {
        private Encoding encodingPrimerArchivo;
        private Encoding encodingSegundoArchivo;
        private Encoding encodingArchivoSalida;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="encodingPrimerArchivo"></param>
        /// <param name="encodingSegundoArchiv"></param>
        /// <param name="encodingArchivoSalida"></param>
        public ProcesoComparador(Encoding encodingPrimerArchivo, Encoding encodingSegundoArchivo, Encoding encodingArchivoSalida)
        {
            this.encodingArchivoSalida = encodingArchivoSalida;
            this.encodingPrimerArchivo = encodingPrimerArchivo;
            this.encodingSegundoArchivo = encodingSegundoArchivo;
        }

        /// <summary>
        /// Método encargado de realizar una operacion según el tipo especificado.
        /// </summary>
        public string RealizarOperacion(string rutaFicheroA, string rutaFicheroB, string rutaSalida, TipoComparacion tipoComparacion)
        {
            string retorno;

            // Validacion ruta textbox tres.
            char caracter = (char)92;
            while (true)
            {
                if (rutaSalida.StartsWith(caracter.ToString()))
                {
                    rutaSalida = rutaSalida.Remove(0, 1);
                }
                else
                {
                    break;
                }
            }

            // Ordenamos utilizando como criterio de ordenamiento toda la línea.
            ArchivoHelper.Ordenar(rutaFicheroA, rutaFicheroA, x => x, encodingPrimerArchivo, encodingArchivoSalida);
            ArchivoHelper.Ordenar(rutaFicheroB, rutaFicheroB, x => x, encodingSegundoArchivo, encodingArchivoSalida);

            // Obtenemos los nombres de los archivos para asignar un nombre coherente al archivo de salida.
            var nombreFicheroB = ProcesoComparador.ObtenerNombreSinEspacios(rutaFicheroB);
            var nombreFicheroA = ProcesoComparador.ObtenerNombreSinEspacios(rutaFicheroA);

            // Formateamos la salida del archivo.
            if (!File.Exists(rutaSalida))
            {
                if (Directory.Exists(rutaSalida))
                    rutaSalida = rutaSalida + $"\\{nombreFicheroA}_comp_{nombreFicheroB}.txt";
                else
                    using (File.Create(rutaSalida)) { }
            }

            using (StreamWriter escritorSalida = new StreamWriter(rutaSalida, true, encodingArchivoSalida))
            using (StreamReader lectorB = new StreamReader(rutaFicheroB, encodingSegundoArchivo))
            using (StreamReader lectorA = new StreamReader(rutaFicheroA, encodingPrimerArchivo))
            {
                switch (tipoComparacion)
                {
                    case TipoComparacion.Diferencia:
                        retorno = DiferenciaEntre(escritorSalida, lectorA, lectorB);
                        break;
                    case TipoComparacion.XOR:
                        retorno = XorEntre(escritorSalida, lectorA, lectorB);
                        break;
                    case TipoComparacion.AND:
                        retorno = AndEntre(escritorSalida, lectorA, lectorB);
                        break;
                    default:
                        return null;
                }
            }

            ArchivoHelper.Ordenar(rutaSalida, rutaSalida, x => x, encodingArchivoSalida, encodingArchivoSalida);
            return retorno;
        }

        /// <summary>
        /// Método encargado de comparar dos ficheros ordenados previamente.
        /// </summary>
        /// <param name="ficheroA"></param>
        /// <param name="ficheroB"></param>
        /// <returns></returns>
        public string DiferenciaEntre(StreamWriter escritor, StreamReader lectorA, StreamReader lectorB)
        {
            var lineaActualA = "";
            var lineaActualB = "";

            bool iterateA = true;
            bool iterateB = true;

            bool work = true;

            lectorA.BaseStream.Position = 0;
            lectorB.BaseStream.Position = 0;

            //Mientras no se haya llegado al final del fichero.
            while (work)
            {
                // Orquestamos la Iteración.
                if (!lectorB.EndOfStream && iterateB)
                {
                    lineaActualB = lectorB.ReadLine();
                    iterateB = false;
                }

                if (!lectorA.EndOfStream && iterateA)
                {
                    lineaActualA = lectorA.ReadLine();
                    iterateA = false;
                }

                // Definicion del conjunto.
                if (lineaActualA.CompareTo(lineaActualB) > 0)
                {
                    iterateB = true;

                    if (lectorB.EndOfStream)
                    {
                        work = false;
                        escritor.WriteLine(lineaActualA);
                    }

                }
                else if (lineaActualA.CompareTo(lineaActualB) == 0)
                {
                    iterateA = true;
                    iterateB = true;

                    if (lectorA.EndOfStream)
                        work = false;
                }
                else if (lineaActualA.CompareTo(lineaActualB) < 0)
                {
                    // El elemento pertenece unicamente al conjunto A.
                    iterateA = true;
                    escritor.WriteLine(lineaActualA);

                    if (lectorA.EndOfStream)
                        work = false;
                }
            }

            string rutaFinal = ((FileStream)(escritor.BaseStream)).Name;
            return rutaFinal;
        }

        /// <summary>
        /// Método encargado de realizar operación XOR entre dos ficheros.
        /// </summary>
        /// <param name="ficheroA"></param>
        /// <param name="ficheroB"></param>
        /// <returns></returns>
        public string XorEntre(StreamWriter escritor, StreamReader lectorA, StreamReader lectorB)
        {
            string rutaA = this.DiferenciaEntre(escritor, lectorA, lectorB);
            string rutaB = this.DiferenciaEntre(escritor, lectorB, lectorA);
            string rutaSalida = ((FileStream)(escritor.BaseStream)).Name;
            return rutaSalida;
        }

        /// <summary>
        /// Método encargado de realizar operación AND entre dos ficheros.
        /// </summary>
        /// <param name="ficheroA"></param>
        /// <param name="ficheroB"></param>
        /// <returns></returns>
        public string AndEntre(StreamWriter escritor, StreamReader lectorA, StreamReader lectorB)
        {
            var lineaActualA = "";
            var lineaActualB = "";

            bool iterateA = true;
            bool iterateB = true;

            //Mientras no se haya llegado al final del fichero.
            while (!lectorA.EndOfStream)
            {
                // Orquestamos la Iteración.
                if (!lectorB.EndOfStream && iterateB)
                {
                    lineaActualB = lectorB.ReadLine();
                    iterateB = false;
                }

                if (!lectorA.EndOfStream && iterateA)
                {
                    lineaActualA = lectorA.ReadLine();
                    iterateA = false;
                }

                // Definicion del conjunto.
                if (lineaActualA.CompareTo(lineaActualB) > 0)
                {
                    iterateB = true;
                }
                else if (lineaActualA.CompareTo(lineaActualB) == 0)
                {
                    iterateA = true;
                    iterateB = true;
                    escritor.WriteLine(lineaActualA);
                }
                else if (lineaActualA.CompareTo(lineaActualB) < 0)
                {
                    iterateA = true;
                }
            }

            string rutaFinal = ((FileStream)(escritor.BaseStream)).Name;
            return rutaFinal;
        }

        /// <summary>
        /// Método encargado de retornar el nombre del archivo sin espacios.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ObtenerNombreSinEspacios(string path)
        {
            // Obtenemos los nombres de los archivos para asignar un nombre coherente al archivo de salida.
            var nombreFicheroA = new FileInfo(path).Name;
            nombreFicheroA = Path.GetFileNameWithoutExtension(nombreFicheroA).Replace(" ", "");
            return nombreFicheroA;
        }
    }
}