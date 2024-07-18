using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana6yo
{
    // Definición de la clase Nodo para la lista enlazada de números aleatorios
    class Nodo
    {
        public int Dato; // Dato que almacena el nodo
        public Nodo Siguiente; // Puntero al siguiente nodo

        // Constructor que inicializa el nodo con el dato dado
        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Definición de la clase ListaEnlazadaNumeros para manejar la lista enlazada de números aleatorios
    class ListaEnlazadaNumeros
    {
        public Nodo Cabeza; // Puntero a la cabeza de la lista

        // Constructor que inicializa la lista vacía
        public ListaEnlazadaNumeros()
        {
            Cabeza = null;
        }

        // Método para insertar un nuevo nodo al final de la lista
        public void Insertar(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo; // Si la lista está vacía, el nuevo nodo es la cabeza
            }
            else
            {
                Nodo actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente; // Recorre la lista hasta el final
                }
                actual.Siguiente = nuevoNodo; // Inserta el nuevo nodo al final
            }
        }

        // Método para eliminar nodos que están fuera del rango dado
        public void EliminarNodosFueraDeRango(int min, int max)
        {
            // Elimina los nodos al inicio que están fuera del rango
            while (Cabeza != null && (Cabeza.Dato < min || Cabeza.Dato > max))
            {
                Cabeza = Cabeza.Siguiente;
            }

            if (Cabeza == null) return;

            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente; // Elimina el nodo fuera de rango
                }
                else
                {
                    actual = actual.Siguiente; // Avanza al siguiente nodo
                }
            }
        }

        // Método para imprimir todos los nodos de la lista
        public void Imprimir()
        {
            Nodo actual = Cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " "); // Imprime el dato del nodo
                actual = actual.Siguiente; // Avanza al siguiente nodo
            }
            Console.WriteLine();
        }
    }
}
