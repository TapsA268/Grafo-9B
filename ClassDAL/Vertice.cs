﻿using System.Collections.Generic;
using ClassEntidades;

namespace ClassDAL
{
    public class Vertice
    {
        internal Entidad entidadInfo;
        internal ListaAristas listaEnlaces = new ListaAristas();

        public Vertice(Entidad objEntidad)
        {
            entidadInfo = objEntidad;
        }
        public string AgregarArista(int numVertice, float costo)
        {
            return listaEnlaces.Insertar(numVertice, costo);
        }
        public string[] MostrarAristas()
        {
            return listaEnlaces.MostrarDatosLista();
        }
        public string MostrarDatos()
        {
            return entidadInfo.MostrarDatos();
        }
        public List<int> ObtenerVecinos()
        {
            return listaEnlaces.ObtenerVecinos();
        }
    }
}
