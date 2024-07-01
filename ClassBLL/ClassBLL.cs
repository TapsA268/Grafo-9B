using System.Collections.Generic;
using Newtonsoft.Json;
using ClassDAL;
using ClassEntidades;

namespace ClassBLL
{
    public class ClassBL
    {
        Grafo grafo = new Grafo();
        public string AgregarVerticeBL(Entidad obj)
        {
            string temp = grafo.AgregarVertice(obj);
            return temp;
        }
        public string AgregarAristaBL(int origen, int destino, float costo)
        {
            string temp = grafo.AgregarArista(origen, destino, costo);
            return temp;
        }
        public List<string> MostrarVerticesAristas(int pVertice, ref string msj)
        {
            return grafo.MostrarAristasVertice(pVertice, ref msj);
        }
        public string[] MostrarVerticesBL()
        {
            return grafo.MostrarVertices();
        }
        public List<string> BusquedaTopologicaVerticeBL(int vertice)
        {
            return grafo.BusquedaTopologicaVertice(vertice);
        }
        public List<string> BusquedaTopologicaAristaBL(int origen, int destino)
        {
            return grafo.BusquedaTopologicaArista(origen, destino);
        }
        public List<string> RecorrerDFS_BL(int vertice)
        {
            return grafo.RecorrerDFS(vertice);
        }
        public List<string> RecorrerBFS_BL(int verticeInicio)
        {
            return grafo.RecorrerBFS(verticeInicio);
        }
        public string[] Djikstra(int vertInicio, ref string msj)
        {
            return grafo.Djikstra(vertInicio, ref msj);
        }
        public string SerializarGrafo()
        {
            string grafoSerializado=JsonConvert.SerializeObject(grafo);
            return grafoSerializado;
        }
    }
}
