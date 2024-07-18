using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana6yo
{
    // Definición de la clase Estudiante para manejar los datos de los estudiantes
    class Estudiante
    {
        public string Cedula; // Cédula del estudiante
        public string Nombre; // Nombre del estudiante
        public string Apellido; // Apellido del estudiante
        public string Correo; // Correo del estudiante
        public double Nota; // Nota definitiva del estudiante
        public Estudiante Siguiente; // Puntero al siguiente estudiante

        // Constructor que inicializa el estudiante con los datos dados
        public Estudiante(string cedula, string nombre, string apellido, string correo, double nota)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Nota = nota;
            Siguiente = null;
        }
    }

    // Definición de la clase ListaEnlazadaEstudiantes para manejar la lista enlazada de estudiantes
    class ListaEnlazadaEstudiantes
    {
        private Estudiante Cabeza; // Puntero a la cabeza de la lista
        private int Aprobados; // Contador de estudiantes aprobados
        private int Reprobados; // Contador de estudiantes reprobados

        // Constructor que inicializa la lista vacía
        public ListaEnlazadaEstudiantes()
        {
            Cabeza = null;
            Aprobados = 0;
            Reprobados = 0;
        }

        // Método para agregar un nuevo estudiante a la lista
        public void AgregarEstudiante(Estudiante nuevoEstudiante)
        {
            if (nuevoEstudiante.Nota >= 6)
            {
                // Insertar al inicio si el estudiante está aprobado
                nuevoEstudiante.Siguiente = Cabeza;
                Cabeza = nuevoEstudiante;
                Aprobados++;
            }
            else
            {
                // Insertar al final si el estudiante está reprobado
                if (Cabeza == null)
                {
                    Cabeza = nuevoEstudiante;
                }
                else
                {
                    Estudiante actual = Cabeza;
                    while (actual.Siguiente != null)
                    {
                        actual = actual.Siguiente;
                    }
                    actual.Siguiente = nuevoEstudiante;
                }
                Reprobados++;
            }
        }

        // Método para buscar un estudiante por cédula
        public Estudiante BuscarEstudiante(string cedula)
        {
            Estudiante actual = Cabeza;
            while (actual != null)
            {
                if (actual.Cedula == cedula)
                {
                    return actual; // Retorna el estudiante encontrado
                }
                actual = actual.Siguiente; // Avanza al siguiente estudiante
            }
            return null; // Retorna null si no se encuentra el estudiante
        }

        // Método para eliminar un estudiante por cédula
        public bool EliminarEstudiante(string cedula)
        {
            if (Cabeza == null)
            {
                return false; // La lista está vacía
            }

            if (Cabeza.Cedula == cedula)
            {
                // Eliminar la cabeza de la lista si coincide
                if (Cabeza.Nota >= 6) Aprobados--;
                else Reprobados--;
                Cabeza = Cabeza.Siguiente;
                return true;
            }

            Estudiante actual = Cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Cedula != cedula)
            {
                actual = actual.Siguiente; // Avanza al siguiente estudiante
            }

            if (actual.Siguiente == null)
            {
                return false; // No se encontró el estudiante
            }

            if (actual.Siguiente.Nota >= 6) Aprobados--;
            else Reprobados--;
            actual.Siguiente = actual.Siguiente.Siguiente; // Eliminar el nodo encontrado
            return true;
        }

        // Método para obtener el total de estudiantes aprobados
        public int TotalAprobados()
        {
            return Aprobados;
        }

        // Método para obtener el total de estudiantes reprobados
        public int TotalReprobados()
        {
            return Reprobados;
        }

        // Método para imprimir todos los estudiantes
        public void ImprimirEstudiantes()
        {
            Estudiante actual = Cabeza;
            while (actual != null)
            {
                Console.WriteLine($"{actual.Nombre} {actual.Apellido}, Cédula: {actual.Cedula}, Correo: {actual.Correo}, Nota: {actual.Nota}");
                actual = actual.Siguiente; // Avanza al siguiente estudiante
            }
        }
    }

}
