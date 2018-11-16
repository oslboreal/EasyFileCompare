using System;
using System.IO;

namespace Sac.AplicacionesAux.ComparadorTextos
{
    public static class ComparadorHelper
    {
        /// <summary>
        /// Método encargado de comparar dos ficheros ordenados previamente.
        /// </summary>
        /// <param name="ficheroA"></param>
        /// <param name="ficheroB"></param>
        /// <returns></returns>
        public static string DiferenciaEntre(string rutaFicheroA, string rutaFicheroB, string rutaSalida, EncodingComparacion encoding)
        {
            // Obtenemos los nombres de los archivos para asignar un nombre coherente al archivo de salida.
            var nombreFicheroA = ArchivoHelper.ObtenerNombreSinEspacios(rutaFicheroA);
            var nombreFicheroB = ArchivoHelper.ObtenerNombreSinEspacios(rutaFicheroB);

            // Ordenamos utilizando como criterio de ordenamiento toda la línea.
            ArchivoHelper.Ordenar(rutaFicheroA, rutaFicheroA, x => x, encoding.PrimerArchivo, encoding.ArchivoSalida);
            ArchivoHelper.Ordenar(rutaFicheroB, rutaFicheroB, x => x, encoding.SegundoArchivo, encoding.ArchivoSalida);

            // Formateamos la salida del archivo.
            rutaSalida = rutaSalida + $"\\{nombreFicheroA}_diff_{nombreFicheroB}.txt";

            using (StreamWriter escritorAuxiliar = new StreamWriter(rutaSalida))
            {
                var lectorA = new StreamReader(rutaFicheroA);
                var lectorB = new StreamReader(rutaFicheroB);

                var lineaActualA = "";
                var lineaActualB = "";

                bool iterateA = true;
                bool iterateB = true;

                bool work = true;

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
                            escritorAuxiliar.WriteLine(lineaActualA);
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
                        escritorAuxiliar.WriteLine(lineaActualA);

                        if (lectorA.EndOfStream)
                            work = false;
                    }
                }
                lectorA.Dispose();
                lectorB.Dispose();
                GC.Collect();
            }
            return rutaSalida;
        }

        /// <summary>
        /// Método encargado de comparar dos ficheros ordenados previamente y realizar un diferencia en un archivo Temporal empleando APPEND.
        /// </summary>
        /// <param name="ficheroA"></param>
        /// <param name="ficheroB"></param>
        /// <returns></returns>
        public static string DiferenciaTemporal(string rutaFicheroA, string rutaFicheroB, string rutaSalida, EncodingComparacion encoding)
        {
            // Obtenemos los nombres de los archivos para asignar un nombre coherente al archivo de salida.
            var nombreFicheroA = ArchivoHelper.ObtenerNombreSinEspacios(rutaFicheroA);
            var nombreFicheroB = ArchivoHelper.ObtenerNombreSinEspacios(rutaFicheroB);

            // Formateamos la salida del archivo.
            rutaSalida = rutaSalida + $"\\{Guid.NewGuid()}.temp";

            // Ordenamos utilizando como criterio de ordenamiento toda la línea.
            ArchivoHelper.Ordenar(rutaFicheroA, rutaFicheroA, x => x, encoding.PrimerArchivo, encoding.ArchivoSalida);
            ArchivoHelper.Ordenar(rutaFicheroB, rutaFicheroB, x => x, encoding.SegundoArchivo, encoding.ArchivoSalida);

            using (StreamWriter escritorAuxiliar = new StreamWriter(rutaSalida, true))
            {
                var lectorA = new StreamReader(rutaFicheroA, true);
                var lectorB = new StreamReader(rutaFicheroB, true);

                var lineaActualA = "";
                var lineaActualB = "";

                // Flags empleados para orquestar la iteración.
                bool iterateA = true;
                bool iterateB = true;
                bool work = true;

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
                            escritorAuxiliar.WriteLine(lineaActualA);
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
                        escritorAuxiliar.WriteLine(lineaActualA);

                        if (lectorA.EndOfStream)
                            work = false;
                    }
                }
                lectorA.Dispose();
                lectorB.Dispose();
                GC.Collect();
            }
            return rutaSalida;
        }

        /// <summary>
        /// Método encargado de realizar operación XOR entre dos ficheros.
        /// </summary>
        /// <param name="ficheroA"></param>
        /// <param name="ficheroB"></param>
        /// <returns></returns>
        public static bool XorEntre(string rutaFicheroA, string rutaFicheroB, string rutaSalida, EncodingComparacion encoding)
        {
            // Obtenemos las diferencias antes de realizar la UNION de los elementos.
            var rutaPrimerArchivo = DiferenciaTemporal(rutaFicheroA, rutaFicheroB, rutaSalida, encoding);
            var rutaSegundoArchivo = DiferenciaTemporal(rutaFicheroB, rutaFicheroA, rutaSalida, encoding);

            // Obtenemos los nombres de los archivos para asignar un nombre coherente al archivo de salida.
            var nombreFicheroA = ArchivoHelper.ObtenerNombreSinEspacios(rutaFicheroA);
            var nombreFicheroB = ArchivoHelper.ObtenerNombreSinEspacios(rutaFicheroB);

            // Creamos una ruta de salida para unir nuestro archivo.
            rutaSalida = rutaSalida + $"\\{nombreFicheroA}_xor_{nombreFicheroB}.txt";

            // Corroboramos existencia del archivo.
            if (!File.Exists(rutaSalida))
            {
                using (var stream = File.Create(rutaSalida)) { }
            }

            // MERGE.
            using (Stream destino = File.OpenWrite(rutaSalida))
            {
                using (Stream streamA = File.OpenRead(rutaPrimerArchivo))
                {
                    streamA.CopyTo(destino);
                    streamA.Close();
                    File.Delete(rutaPrimerArchivo);
                }
                using (Stream streamB = File.OpenRead(rutaSegundoArchivo))
                {
                    streamB.CopyTo(destino);
                    streamB.Close();
                    File.Delete(rutaSegundoArchivo);
                }
            }

            // Ordenamos el archivo conformado.
            ArchivoHelper.Ordenar(rutaSalida, rutaSalida, x => x, encoding.ArchivoSalida, encoding.ArchivoSalida);

            // Pasamos Garbage collector.
            GC.Collect();

            return true;
        }

        /// <summary>
        /// Método encargado de realizar operación AND entre dos ficheros.
        /// </summary>
        /// <param name="ficheroA"></param>
        /// <param name="ficheroB"></param>
        /// <returns></returns>
        public static bool AndEntre(string rutaFicheroA, string rutaFicheroB, string rutaSalida, EncodingComparacion encoding)
        {
            // Definimos las rutas.
            var nombreFicheroA = Path.GetFileNameWithoutExtension(new FileInfo(rutaFicheroA).Name);
            var nombreFicheroB = Path.GetFileNameWithoutExtension(new FileInfo(rutaFicheroB).Name);

            // Formateamos la salida del archivo.
            rutaSalida = rutaSalida + $"\\{nombreFicheroA}_and_{nombreFicheroB}.txt";

            // Ordenamos utilizando como criterio de ordenamiento toda la línea.
            ArchivoHelper.Ordenar(rutaFicheroA, rutaFicheroA, x => x, encoding.PrimerArchivo, encoding.ArchivoSalida);
            ArchivoHelper.Ordenar(rutaFicheroB, rutaFicheroB, x => x, encoding.SegundoArchivo, encoding.ArchivoSalida);


            using (StreamWriter escritorAuxiliar = new StreamWriter(rutaSalida))
            {
                var lectorA = new StreamReader(rutaFicheroA, encoding.ArchivoSalida);
                var lectorB = new StreamReader(rutaFicheroB, encoding.ArchivoSalida);

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
                        escritorAuxiliar.WriteLine(lineaActualA);
                    }
                    else if (lineaActualA.CompareTo(lineaActualB) < 0)
                    {
                        iterateA = true;
                    }
                }

                lectorA.Dispose();
                lectorB.Dispose();
                GC.Collect();
            }
            return true;
        }
    }
}
