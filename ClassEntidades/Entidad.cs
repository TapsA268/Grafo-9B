﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Entidad
    {
        public string Nombre { get; set; }
        public int Edad { get; set;}

        public string MostrarDatos()
        {
            return $"Nombre: {Nombre} Edad: {Edad}";
        }
    }
}
