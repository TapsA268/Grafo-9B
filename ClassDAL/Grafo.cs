using System;
using System.Linq;
using ClassEntidades;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClassDAL
{
    public class Grafo
    {
        [JsonProperty]
        internal List<Vertice> ListaAdyacencia = new List<Vertice>();

        public string AgregarVertice(Entidad obj)
        {
            string msj;
            msj = $"Vertice {obj.MostrarDatos()} agregado";
            ListaAdyacencia.Add(new Vertice(obj));
            return msj;
        }
        public string AgregarArista(int origen, int dest, float costo)
        {
            string msj;
            if (origen >= 0 && origen <= (ListaAdyacencia.Count - 1))
            {
                if (dest >= 0 && dest <= (ListaAdyacencia.Count - 1))
                {
                    ListaAdyacencia[origen].AgregarArista(dest, costo);
                    msj = "Arista agregada";
                }
                else
                {
                    msj = "La posición del vertice destino no existe en la lista de adyacencia";
                }
            }
            else
            {
                msj = "La posición del vertice origen no existe en la lista de adyacencia";
            }
            return msj;
        }
        public List<string> MostrarAristasVertice(int posVertice, ref string msj)
        {
            NodoLista temp;
            List<string> salida = new List<string>();

            if (posVertice >= 0 && posVertice <= (ListaAdyacencia.Count - 1))
            {
                temp = ListaAdyacencia[posVertice].listaEnlaces.inicio;

                while (temp != null)
                {
                    salida.Add($"Vertice destino: {ListaAdyacencia[temp.numVertices].entidadInfo.Nombre} "
                        + $"posición de enlace a {temp.numVertices} costo {temp.costo}");
                    temp = temp.next;
                }

                msj = "Correcto";
            }
            else
            {
                msj = "La posición del vertice destino no existe en la lista de adyacencia";
            }
            return salida;
        }
        public string[] MostrarVertices()
        {
            string[] salida = new string[ListaAdyacencia.Count];
            int cont;
            for (cont = 0; cont <= ListaAdyacencia.Count - 1; cont++)
            {
                salida[cont] = ListaAdyacencia[cont].MostrarDatos();
            }
            return salida;
        }
        public List<string> RecorrerDFS(int vertice)
        {
            Boolean[] visitados = new Boolean[ListaAdyacencia.Count];
            Stack<int> pilaResult = new Stack<int>();
            List<string> listaResultados = new List<string>();

            pilaResult.Push(vertice);

            while (pilaResult.Count != 0)
            {
                int v = pilaResult.Pop();
                if (!visitados[v])
                {
                    visitados[v] = true;
                    listaResultados.Add($"Vértice {ListaAdyacencia[v].entidadInfo.Nombre} con índice {v}");
                    foreach (int i in ListaAdyacencia[v].ObtenerVecinos())
                    {
                        if (!visitados[i])
                        {
                            pilaResult.Push(i);
                        }
                    }
                }
            }
            return listaResultados;
        }
        public List<string> RecorrerBFS(int verticeInicio)
        {
            Boolean[] visitado = new Boolean[ListaAdyacencia.Count];
            Queue<int> colaResultado = new Queue<int>();
            List<string> resultados = new List<string>();

            visitado[verticeInicio] = true;
            colaResultado.Enqueue(verticeInicio);

            while (colaResultado.Count != 0)
            {
                verticeInicio = colaResultado.Dequeue();
                resultados.Add($"Vértice {ListaAdyacencia[verticeInicio].entidadInfo.Nombre} con índice {verticeInicio}");

                foreach (int v in ListaAdyacencia[verticeInicio].ObtenerVecinos())
                {
                    if (!visitado[v])
                    {
                        visitado[v] = true;
                        colaResultado.Enqueue(v);
                    }
                }
            }
            return resultados;
        }
        private void BusquedaTopologicaRecursiva(int vertice, Boolean[] visitados, Stack<int> pilaResults)
        {
            visitados[vertice] = true;
            foreach (int v in ListaAdyacencia[vertice].ObtenerVecinos())
            {
                if (!visitados[v])
                {
                    BusquedaTopologicaRecursiva(v, visitados, pilaResults);
                }
            }
            pilaResults.Push(vertice);
        }
        public List<string> BusquedaTopologicaVertice(int vertice)
        {
            Stack<int> pila = new Stack<int>();
            Boolean[] visitados = new Boolean[ListaAdyacencia.Count];
            List<string> result = new List<string>();

            BusquedaTopologicaRecursiva(vertice, visitados, pila);

            while (pila.Count > 0)
            {
                int vert = pila.Pop();
                result.Add($"Vértice {ListaAdyacencia[vert].entidadInfo.Nombre} con índice: {vert}");
            }
            return result;
        }
        public List<string> BusquedaTopologicaArista(int origen, int destino)
        {
            Stack<int> pila = new Stack<int>();
            List<string> camino = new List<string>();
            Boolean[] visitados = new Boolean[ListaAdyacencia.Count];

            BusquedaTopologicaRecursiva(origen, visitados, pila);

            Boolean encontrado = false;

            while (pila.Count != 0)
            {
                int vertice = pila.Pop();
                if (vertice == origen)
                {
                    encontrado = true;
                }
                if (encontrado)
                {
                    camino.Add($"Vértice {ListaAdyacencia[vertice].entidadInfo.Nombre} con índice: {vertice}");
                    if (vertice == destino)
                    {
                        return camino;
                    }
                }
            }
            return Enumerable.Empty<string>().ToList();
        }       
        private int DistanciaMinima(float[] distancia, Boolean[] visitado)
        {
            float minimo = float.MaxValue;
            int indiceMin = -1;
            for (int i = 0; i < distancia.Length; i++)
            {
                if (!visitado[i] && distancia[i] < minimo)
                {
                    minimo = distancia[i];
                    indiceMin = i;
                }
            }
            return indiceMin;
        }
        private float ObtenerCosto(int origen, int destino)
        {
            NodoLista temp = ListaAdyacencia[origen].listaEnlaces.inicio;
            while (temp != null)
            {
                if (temp.numVertices == destino) return temp.costo;
                temp = temp.next;
            }
            return float.MaxValue;
        }
        private string[] MostrarDjikstra(float[] distancia, int verticeInicio, ref string msj)
        {
            string[] resultado = new string[ListaAdyacencia.Count];
            msj = $"Vértice de inicio: {ListaAdyacencia[verticeInicio].entidadInfo.Nombre}";
            for (int i = 0; i < distancia.Length; i++)
            {
                resultado[i] = $"{ListaAdyacencia[i].entidadInfo.Nombre} está en una distancia {distancia[i]}";
            }
            return resultado;
        }
        public string[] Djikstra(int verticeInicio, ref string msj)
        {
            Boolean[] visitado = new Boolean[ListaAdyacencia.Count];
            float[] distancias = new float[ListaAdyacencia.Count];

            for (int i = 0; i < ListaAdyacencia.Count; i++)
            {
                distancias[i] = float.MaxValue;
                visitado[i] = false;
            }

            distancias[verticeInicio] = 0;

            for (int cont = 0; cont < ListaAdyacencia.Count - 1; cont++)
            {
                int dist = DistanciaMinima(distancias, visitado);
                if (dist == -1) break;
                visitado[dist] = true;

                List<int> vecinos = ListaAdyacencia[dist].ObtenerVecinos();
                foreach (int vecino in vecinos)
                {
                    float costo = ObtenerCosto(dist, vecino);
                    if (!visitado[vecino] && distancias[dist] != float.MaxValue && distancias[dist] + costo < distancias[vecino])
                    {
                        distancias[vecino] = distancias[dist] + costo;
                    }
                }
            }
            return MostrarDjikstra(distancias, verticeInicio, ref msj);
        }
    }
}
