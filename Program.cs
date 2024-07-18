using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana6yo
{
    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main()
        {
            ListaEnlazadaNumeros listaNumeros = new ListaEnlazadaNumeros();
            ListaEnlazadaEstudiantes listaEstudiantes = new ListaEnlazadaEstudiantes();

            while (true)
            {
                Console.WriteLine("\nMenu Principal:");
                Console.WriteLine("1. Problema 1: Manejo de lista enlazada de números aleatorios");
                Console.WriteLine("2. Problema 2: Registro de estudiantes de Redes III");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int opcionPrincipal))
                {
                    switch (opcionPrincipal)
                    {
                        case 1:
                            // Menú del Problema 1
                            bool volverAlMenuPrincipal1 = false;
                            while (!volverAlMenuPrincipal1)
                            {
                                Console.WriteLine("\nMenu Problema 1:");
                                Console.WriteLine("1. Crear lista enlazada con números aleatorios");
                                Console.WriteLine("2. Eliminar nodos fuera de un rango");
                                Console.WriteLine("3. Imprimir lista");
                                Console.WriteLine("4. Volver al menú principal");
                                Console.Write("Seleccione una opción: ");
                                string entrada1 = Console.ReadLine();

                                if (int.TryParse(entrada1, out int opcion1))
                                {
                                    switch (opcion1)
                                    {
                                        case 1:
                                            Random rand = new Random();
                                            listaNumeros = new ListaEnlazadaNumeros(); // Reiniciar la lista
                                            for (int i = 0; i < 50; i++)
                                            {
                                                listaNumeros.Insertar(rand.Next(1, 1000));
                                            }
                                            Console.WriteLine("Lista creada con 50 números aleatorios.");
                                            break;
                                        case 2:
                                            Console.Write("Ingrese el valor mínimo del rango: ");
                                            string entradaMin = Console.ReadLine();
                                            if (int.TryParse(entradaMin, out int min))
                                            {
                                                Console.Write("Ingrese el valor máximo del rango: ");
                                                string entradaMax = Console.ReadLine();
                                                if (int.TryParse(entradaMax, out int max))
                                                {
                                                    listaNumeros.EliminarNodosFueraDeRango(min, max);
                                                    Console.WriteLine("Nodos fuera del rango eliminados.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Valor máximo no válido.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Valor mínimo no válido.");
                                            }
                                            break;
                                        case 3:
                                            Console.WriteLine("Lista actual:");
                                            listaNumeros.Imprimir();
                                            break;
                                        case 4:
                                            volverAlMenuPrincipal1 = true;
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida.");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
                                }
                            }
                            break;

                        case 2:
                            // Menú del Problema 2
                            bool volverAlMenuPrincipal2 = false;
                            while (!volverAlMenuPrincipal2)
                            {
                                Console.WriteLine("\nMenu Problema 2:");
                                Console.WriteLine("1. Agregar estudiante");
                                Console.WriteLine("2. Buscar estudiante por cédula");
                                Console.WriteLine("3. Eliminar estudiante");
                                Console.WriteLine("4. Total estudiantes aprobados");
                                Console.WriteLine("5. Total estudiantes reprobados");
                                Console.WriteLine("6. Imprimir todos los estudiantes");
                                Console.WriteLine("7. Volver al menú principal");
                                Console.Write("Seleccione una opción: ");
                                string entrada2 = Console.ReadLine();

                                if (int.TryParse(entrada2, out int opcion2))
                                {
                                    switch (opcion2)
                                    {
                                        case 1:
                                            Console.Write("Ingrese la cédula: ");
                                            string cedula = Console.ReadLine();
                                            Console.Write("Ingrese el nombre: ");
                                            string nombre = Console.ReadLine();
                                            Console.Write("Ingrese el apellido: ");
                                            string apellido = Console.ReadLine();
                                            Console.Write("Ingrese el correo: ");
                                            string correo = Console.ReadLine();
                                            Console.Write("Ingrese la nota definitiva (1-10): ");
                                            string entradaNota = Console.ReadLine();

                                            if (double.TryParse(entradaNota, out double nota))
                                            {
                                                Estudiante nuevoEstudiante = new Estudiante(cedula, nombre, apellido, correo, nota);
                                                listaEstudiantes.AgregarEstudiante(nuevoEstudiante);
                                                Console.WriteLine("Estudiante agregado exitosamente.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Nota no válida.");
                                            }
                                            break;
                                        case 2:
                                            Console.Write("Ingrese la cédula del estudiante a buscar: ");
                                            cedula = Console.ReadLine();
                                            Estudiante estudianteEncontrado = listaEstudiantes.BuscarEstudiante(cedula);
                                            if (estudianteEncontrado != null)
                                            {
                                                Console.WriteLine($"Estudiante encontrado: {estudianteEncontrado.Nombre} {estudianteEncontrado.Apellido}, Correo: {estudianteEncontrado.Correo}, Nota: {estudianteEncontrado.Nota}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Estudiante no encontrado.");
                                            }
                                            break;
                                        case 3:
                                            Console.Write("Ingrese la cédula del estudiante a eliminar: ");
                                            cedula = Console.ReadLine();
                                            bool eliminado = listaEstudiantes.EliminarEstudiante(cedula);
                                            if (eliminado)
                                            {
                                                Console.WriteLine("Estudiante eliminado exitosamente.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Estudiante no encontrado.");
                                            }
                                            break;
                                        case 4:
                                            Console.WriteLine($"Total de estudiantes aprobados: {listaEstudiantes.TotalAprobados()}");
                                            break;
                                        case 5:
                                            Console.WriteLine($"Total de estudiantes reprobados: {listaEstudiantes.TotalReprobados()}");
                                            break;
                                        case 6:
                                            Console.WriteLine("Lista de todos los estudiantes:");
                                            listaEstudiantes.ImprimirEstudiantes();
                                            break;
                                        case 7:
                                            volverAlMenuPrincipal2 = true;
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida.");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
                                }
                            }
                            break;

                        case 3:
                            // Salir del programa
                            return;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
                }
            }
        }
    }
}
