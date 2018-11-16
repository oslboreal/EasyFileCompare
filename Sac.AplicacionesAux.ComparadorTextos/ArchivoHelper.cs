using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sac.AplicacionesAux.ComparadorTextos
{
    public class ArchivoHelper
    {
        public static void Ordenar(string rutaArchivoOrigen, string rutaArchivoDestino, Func<string, string> ordernarPor, Encoding codificacionEntrada, Encoding codificacionSalida)
        {
            // Si no hay funcion de ordenamiento el archivo de salida es el de entrada.
            if (ordernarPor == null)
            {
                File.Copy(rutaArchivoOrigen, rutaArchivoDestino);
                return;
            }

            var nombreArchivoOrigen = new FileInfo(rutaArchivoOrigen).Name;
            var directorioTemp = Path.Combine(new FileInfo(rutaArchivoDestino).DirectoryName, string.Format("{0}_Temp", nombreArchivoOrigen));
            if (!Directory.Exists(directorioTemp))
                Directory.CreateDirectory(directorioTemp);

            try
            {
                DividirArchivo(rutaArchivoOrigen, directorioTemp, codificacionEntrada, codificacionSalida);
                OrdenarParticiones(ordernarPor, directorioTemp, codificacionSalida);
                UnirParticiones(rutaArchivoOrigen, ordernarPor, directorioTemp, codificacionSalida);
            }
            catch
            {
                // log
            }
            finally
            {
                // Elimino el archivo desordenado
                Directory.Delete(directorioTemp, true);
            }
        }

        public static String[] DividirArchivo(string rutaArchivo, string directorioTemp, Encoding codificacionEntrada, Encoding codificacionSalida)
        {
            //string nombreArchivoActual = new FileInfo(rutaArchivo).Name;
            String[] retorno;
            List<string> rutasParaRetornar = new List<string>();
            StreamWriter sw = null;
            int split_num = 1;
            try
            {
                // Creo primer particion.
                sw = new StreamWriter(Path.Combine(directorioTemp, string.Format("split{0:d5}.dat", split_num)), false, codificacionSalida);
                rutasParaRetornar.Add(Path.Combine(directorioTemp, string.Format("split{0:d5}.dat", split_num)));

                using (var sr = new StreamReader(rutaArchivo, codificacionEntrada))
                {
                    int corte = sr.BaseStream.Length > 100000000
                        ? 100000000
                        : 10000000;

                    while (sr.Peek() >= 0)
                    {
                        // Copio linea
                        var linea = sr.ReadLine();
                        if (linea.Trim() != string.Empty)
                            sw.WriteLine(linea);

                        // Si el archivo es grande lo particiono (si esta era la última línea, entonces no te molestes)
                        if (sw.BaseStream.Length > corte && sr.Peek() >= 0)
                        {
                            // Cierro conexion anterior
                            sw.Close();

                            // Incremento nro particion
                            split_num++;

                            // Creo n particion
                            rutasParaRetornar.Add(Path.Combine(directorioTemp, string.Format("split{0:d5}.dat", split_num)));
                            sw = new StreamWriter(Path.Combine(directorioTemp, string.Format("split{0:d5}.dat", split_num)), false, codificacionSalida);
                        }
                    }

                    // Establecemos el tamaño del arreglo en función de la cantidad de Splits.
                    retorno = new String[split_num];

                    // Cargamos el arreglo para el retorno.
                    for (int i = 0; i < rutasParaRetornar.Count; i++)
                    {
                        retorno[i] = rutasParaRetornar[i];
                    }

                    // Vaciamos la lista auxiliar..
                    rutasParaRetornar.Clear();
                }
                return retorno;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        public static String[] DividirArchivo(string rutaArchivo, string directorioTemp, string nombreParticion, Encoding codificacionEntrada, Encoding codificacionSalida)
        {
            String[] retorno;
            List<string> rutasParaRetornar = new List<string>();
            StreamWriter sw = null;
            int split_num = 1;
            try
            {
                // Creo 1ra particion.
                sw = new StreamWriter(Path.Combine(directorioTemp, string.Format(nombreParticion + "split{0:d5}.dat", split_num)), false, codificacionSalida);
                rutasParaRetornar.Add(Path.Combine(directorioTemp, string.Format(nombreParticion + "split{0:d5}.dat", split_num)));
                using (var sr = new StreamReader(rutaArchivo, codificacionEntrada))
                {
                    int corte = sr.BaseStream.Length > 100000000
                        ? 100000000
                        : 10000000;

                    while (sr.Peek() >= 0)
                    {
                        // Copio linea
                        var linea = sr.ReadLine();
                        if (linea.Trim() != string.Empty)
                            sw.WriteLine(linea);

                        // Si el archivo es grande lo particiono (si esta era la última línea, entonces no te molestes)
                        if (sw.BaseStream.Length > corte && sr.Peek() >= 0)
                        {
                            // Cierro conexion anterior
                            sw.Close();

                            // Incremento nro particion
                            split_num++;

                            // Creo n particion
                            rutasParaRetornar.Add(Path.Combine(directorioTemp, string.Format(nombreParticion + "split{0:d5}.dat", split_num)));
                            sw = new StreamWriter(Path.Combine(directorioTemp, string.Format(nombreParticion + "split{0:d5}.dat", split_num)), false, codificacionSalida);
                        }
                    }

                    // Establecemos el tamaño del arreglo en función de la cantidad de Splits.
                    retorno = new String[split_num];

                    // Cargamos el arreglo para el retorno.
                    for (int i = 0; i < rutasParaRetornar.Count; i++)
                    {
                        retorno[i] = rutasParaRetornar[i];
                    }

                    // Vaciamos la lista auxiliar..
                    rutasParaRetornar.Clear();
                }
                return retorno;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        /// <summary>
        /// Método encargado de obtener todos los ficheros de particion de un fichero y ordenarlos.
        /// </summary>
        /// <param name="ordernarPor"></param>
        /// <param name="directorioTemp"></param>
        /// <param name="codificacion"></param>
        private static void OrdenarParticiones(Func<string, string> ordernarPor, string directorioTemp, Encoding codificacion)
        {
            foreach (string ruta in Directory.GetFiles(directorioTemp, "split*.dat"))
            {
                // Leo todas las lineas del archivo.
                string[] lineas = File.ReadAllLines(ruta, codificacion);

                lineas = lineas.OrderBy(x => ordernarPor(x)).ToArray();

                // Escribo el resultado en un nuevo archivo.
                string nuevaRuta = ruta.Replace("split", "sorted");
                File.WriteAllLines(nuevaRuta, lineas, codificacion);

                // Elimino el archivo desordenado.
                File.Delete(ruta);

                // Libero memoria.
                lineas = null;
                GC.Collect();
            }
        }

        public static void BorrarParticiones(string directorioTemp)
        {
            // Traigo todas las rutas del directorio.
            foreach (string ruta in Directory.GetFiles(directorioTemp, "split*.dat"))
            {
                // Elimino el archivo.
                File.Delete(ruta);

                // Libero memoria.
                GC.Collect();
            }
        }

        private static void UnirParticiones(string archivoDestino, Func<string, string> keySelector, string directorioTemp, Encoding codificacion)
        {
            var rutas = Directory.GetFiles(directorioTemp, "sorted*.dat");
            var cantParticiones = rutas.Length;
            var recordsize = 100;
            var memoriaMax = 500000000;
            var buffersize = memoriaMax / cantParticiones;
            var recordoverhead = 7.5; // TODO: Preguntar a mati de donde sale esta constante
            var buffer = (int)(buffersize / recordsize / recordoverhead);

            // Abro los archivos de las particiones
            var archivos = new StreamReader[cantParticiones];
            for (int i = 0; i < cantParticiones; i++)
                archivos[i] = new StreamReader(rutas[i], codificacion);

            // Por cada particion creo una cola de pendientes de ordenamiento.
            var colas = new Queue<string>[cantParticiones];
            for (int i = 0; i < cantParticiones; i++)
                colas[i] = new Queue<string>(buffer);

            // Cargo las colas con lineas de las particiones.
            for (int i = 0; i < cantParticiones; i++)
                CargoCola(colas[i], archivos[i], buffer);

            // Empieza el MERGE!

            using (var sw = new StreamWriter(archivoDestino, false, codificacion))
            {
                bool done = false;
                while (!done)
                {
                    // Busco en las particiones la siguente linea ordernada.
                    var lowestIndex = -1;
                    var lowestValue = string.Empty;
                    var lowestValueTransform = string.Empty;

                    for (int j = 0; j < cantParticiones; j++)
                    {
                        if (colas[j] != null)
                        {
                            var peekvalue = colas[j].Peek();
                            var peekValueTransform = keySelector(peekvalue);
                            if (lowestIndex < 0 || string.CompareOrdinal(peekValueTransform, lowestValueTransform) < 0)
                            {
                                lowestIndex = j;
                                lowestValue = peekvalue;
                                lowestValueTransform = peekValueTransform;
                            }
                        }
                    }

                    // No hay nada pendiente de ordenar en la cola.
                    if (lowestIndex == -1)
                    {
                        // Archivo ordenado.
                        done = true;
                        break;
                    }

                    // Escribo linea ordernada.
                    sw.WriteLine(lowestValue);

                    // Remuevo de la cola de pendientes de marge.
                    colas[lowestIndex].Dequeue();

                    // Have we emptied the queue? Top it up
                    if (colas[lowestIndex].Count == 0)
                    {
                        CargoCola(colas[lowestIndex], archivos[lowestIndex], buffer);

                        // Was there nothing left to read?
                        if (colas[lowestIndex].Count == 0)
                            colas[lowestIndex] = null;
                    }
                }
            }

            // Cierro los archivos de particiones y los elimino.
            for (int i = 0; i < cantParticiones; i++)
            {
                archivos[i].Close();
                File.Delete(rutas[i]);
            }
        }

        /// <summary>
        /// Método encargado de recorrer un archivo y encolar todos sus registros.
        /// </summary>
        /// <param name="cola"></param>
        /// <param name="archivo"></param>
        /// <param name="buffer"></param>
        private static void CargoCola(Queue<string> cola, StreamReader archivo, int buffer)
        {
            for (int i = 0; i < buffer; i++)
            {
                if (archivo.Peek() < 0)
                    break;

                cola.Enqueue(archivo.ReadLine());
            }
        }

        /// <summary>
        /// Método encargado de corroborar cual es la codificación de un archivo.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Encoding obtenerEncoding(string path)
        {
            Encoding retorno;
            using (var reader = new StreamReader(path, Encoding.GetEncoding(20127), true))
            {
                reader.Peek();
                retorno = reader.CurrentEncoding;
            }
            return retorno;
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