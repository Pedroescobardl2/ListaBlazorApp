using ListaBlazorApp.Models;
using System.Collections;

namespace ListaBlazorApp.Services
{
    public class ListaEnlazadaSimple : IEnumerable
    {
        public Nodo PrimerNodo { get; set; }
        public Nodo UltimoNodo { get; set; }

        public int CantidadNodos { get; set; }


        public int CalcularCantidadNodos()
        {
            int cantidadNodos = 0;
            // ...
            return cantidadNodos;
        }

        public ListaEnlazadaSimple()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        public bool ListaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoAlFinal(Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }

            return "Se ha agregado el nodo al final";
        }

        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;

            }

            return "Se ha agregado el nodo al inicio";
        }
        public string AgregarNodoAntesDe(object informacionAnterior, Nodo nodoNuevo)
        {
            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo.Informacion.Equals(informacionAnterior))
            {
                nodoNuevo.Referencia = PrimerNodo;
                PrimerNodo = nodoNuevo;
                return "Se ha agregado el nodo antes del primero";
            }

            Nodo nodoActual = PrimerNodo;
            while (nodoActual.Referencia != null && !nodoActual.Referencia.Informacion.Equals(informacionAnterior))
            {
                nodoActual = nodoActual.Referencia;
            }

            if (nodoActual.Referencia == null)
            {
                return "El elemento anterior no se encontró en la lista";
            }

            nodoNuevo.Referencia = nodoActual.Referencia;
            nodoActual.Referencia = nodoNuevo;
            return "Se ha agregado el nodo antes del especificado";
        }
        public string AgregarNodoDespuesDe(object informacionAnterior, Nodo nodoNuevo)
        {
            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo.Informacion.Equals(informacionAnterior))
            {
                nodoNuevo.Referencia = PrimerNodo.Referencia;
                PrimerNodo.Referencia = nodoNuevo;
                return "Se ha agregado el nodo después del primero";
            }

            Nodo nodoActual = PrimerNodo;
            while (nodoActual.Referencia != null && !nodoActual.Referencia.Informacion.Equals(informacionAnterior))
            {
                nodoActual = nodoActual.Referencia;
            }

            if (nodoActual.Referencia == null)
            {
                return "El elemento anterior no se encontró en la lista";
            }

            nodoNuevo.Referencia = nodoActual.Referencia.Referencia;
            nodoActual.Referencia.Referencia = nodoNuevo;
            return "Se ha agregado el nodo después del especificado";
        }
        public string AgregarNodoEnPosicion(int posicion, Nodo nodoNuevo)
        {
            if (posicion < 0)
            {
                return "La posición debe ser un número no negativo";
            }

            if (posicion == 0)
            {
                AgregarNodoAlInicio(nodoNuevo);
                return "Se ha agregado el nodo en la posición 0";
            }

            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (posicion > CalcularCantidadNodos())
            {
                return "La posición especificada excede la longitud de la lista";
            }

            Nodo nodoActual = PrimerNodo;
            for (int i = 0; i < posicion - 1; i++)
            {
                nodoActual = nodoActual.Referencia;
            }

            nodoNuevo.Referencia = nodoActual.Referencia;
            nodoActual.Referencia = nodoNuevo;
            return "Se ha agregado el nodo en la posición especificada";
        }
        public string AgregarNodoAntesDePosicion(int posicion, Nodo nodoNuevo)
        {
            if (posicion < 0)
            {
                return "La posición debe ser un número no negativo";
            }

            if (posicion == 0)
            {
                AgregarNodoAlInicio(nodoNuevo);
                return "Se ha agregado el nodo antes de la posición 0";
            }

            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (posicion >= CalcularCantidadNodos())
            {
                return "La posición especificada excede la longitud de la lista";
            }

            Nodo nodoActual = PrimerNodo;
            for (int i = 0; i < posicion - 1; i++)
            {
                nodoActual = nodoActual.Referencia;
            }

            nodoNuevo.Referencia = nodoActual.Referencia;
            nodoActual.Referencia = nodoNuevo;
            return "Se ha agregado el nodo antes de la posición especificada";
        }
        public string AgregarNodoDespuesDePosicion(int posicion, Nodo nodoNuevo)
        {
            if (posicion < 0)
            {
                return "La posición debe ser un número no negativo";
            }

            if (posicion == 0)
            {
                AgregarNodoAlInicio(nodoNuevo);
                return "Se ha agregado el nodo después de la posición 0";
            }

            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (posicion >= CalcularCantidadNodos())
            {
                return "La posición especificada excede la longitud de la lista";
            }

            Nodo nodoActual = PrimerNodo;
            for (int i = 0; i < posicion; i++)
            {
                nodoActual = nodoActual.Referencia;
            }

            nodoNuevo.Referencia = nodoActual.Referencia;
            nodoActual.Referencia = nodoNuevo;
            return "Se ha agregado el nodo después de la posición especificada";
        }
        public void RecorrerLista(Nodo nodoActual, Action<Nodo> accion)
        {
            if (nodoActual == null)
            {
                return;
            }

            accion(nodoActual);
            RecorrerLista(nodoActual.Referencia, accion);
        }
        public Nodo BuscarNodo(object informacion)
        {
            Nodo nodoActual = PrimerNodo;
            while (nodoActual != null)
            {
                if (nodoActual.Informacion.Equals(informacion))
                {
                    return nodoActual;
                }
                nodoActual = nodoActual.Referencia;
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            Nodo nodoAuxiliar = PrimerNodo;

            while (nodoAuxiliar != null)
            {
                yield return nodoAuxiliar;
                nodoAuxiliar = nodoAuxiliar.Referencia;
            }
        }

        // Función para eliminar un elemento al inicio de la lista
        public string EliminarAlInicio()
        {
            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                PrimerNodo = PrimerNodo.Referencia;
            }

            return "Se ha eliminado el nodo al inicio";
        }

        // Función para eliminar un elemento al final de la lista
        public string EliminarAlFinal()
        {
            if (ListaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                Nodo nodoActual = PrimerNodo;
                while (nodoActual.Referencia != UltimoNodo)
                {
                    nodoActual = nodoActual.Referencia;
                }
                nodoActual.Referencia = null;
                UltimoNodo = nodoActual;
            }

            return "Se ha eliminado el nodo al final";
        }

        // Función para eliminar un elemento antes de un dato X
        public string EliminarAntesDeX(object datoX)
        {
            if (ListaVacia() || PrimerNodo.Referencia == null || PrimerNodo.Referencia.Informacion.Equals(datoX))
            {
                return "No se puede eliminar antes de un elemento que no existe o es el primero";
            }

            Nodo nodoActual = PrimerNodo;
            while (nodoActual.Referencia != null && !nodoActual.Referencia.Referencia.Informacion.Equals(datoX))
            {
                nodoActual = nodoActual.Referencia;
            }

            if (nodoActual.Referencia != null)
            {
                nodoActual.Referencia = nodoActual.Referencia.Referencia;
                return "Se ha eliminado el nodo antes del dato especificado";
            }
            else
            {
                return "El dato especificado no se encuentra en la lista";
            }
        }

        // Función para eliminar un elemento después de un dato X
        public string EliminarDespuésDeX(object datoX)
        {
            if (ListaVacia() || PrimerNodo == UltimoNodo || !BuscarNodo(datoX))
            {
                return "No se puede eliminar después de un elemento que no existe o es el último";
            }

            Nodo nodoActual = PrimerNodo;
            while (nodoActual != null && !nodoActual.Informacion.Equals(datoX))
            {
                nodoActual = nodoActual.Referencia;
            }

            if (nodoActual.Referencia != null)
            {
                nodoActual.Referencia = nodoActual.Referencia.Referencia;
                return "Se ha eliminado el nodo después del dato especificado";
            }
            else
            {
                return "El dato especificado no se encuentra en la lista";
            }
        }

        // Función para eliminar un nodo en una posición específica
        public string EliminarEnPosicion(int posicion)
        {
            if (posicion < 0 || posicion >= CalcularCantidadNodos())
            {
                return "La posición especificada es inválida";
            }

            if (posicion == 0)
            {
                return EliminarAlInicio();
            }
            else if (posicion == CalcularCantidadNodos() - 1)
            {
                return EliminarAlFinal();
            }
            else
            {
                Nodo nodoActual = PrimerNodo;
                for (int i = 0; i < posicion - 1; i++)
                {
                    nodoActual = nodoActual.Referencia;
                }
                nodoActual.Referencia = nodoActual.Referencia.Referencia;
                return $"Se ha eliminado el nodo en la posición {posicion}";
            }
        }

        // Función para ordenar la lista 
        public void OrdenarLista()
        {
            if (ListaVacia() || PrimerNodo == UltimoNodo)
            {
                return; 
            }

            bool intercambio; 
            do
            {
                intercambio = false;
                Nodo nodoActual = PrimerNodo;
                Nodo nodoAnterior = null;

                while (nodoActual.Referencia != null)
                {
                    
                    if ((int)nodoActual.Informacion > (int)nodoActual.Referencia.Informacion)
                    {
                        Nodo siguiente = nodoActual.Referencia;
                        nodoActual.Referencia = siguiente.Referencia;
                        siguiente.Referencia = nodoActual;

                        if (nodoAnterior != null)
                        {
                            nodoAnterior.Referencia = siguiente;
                        }
                        else
                        {
                            PrimerNodo = siguiente;
                        }

                        if (nodoActual.Referencia == null)
                        {
                            UltimoNodo = nodoActual;
                        }

                        intercambio = true;
                    }

                    nodoAnterior = nodoActual;
                    nodoActual = nodoActual.Referencia;
                }
            } while (intercambio);
        }


    }
}
