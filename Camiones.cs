using System;
using System.Collections.Generic;

namespace Examen
{
    class Camiones
    {
       public string nombre;
       public string ruta;


        public override string ToString()
        {
            return "Nombre: " + nombre + " Ruta: " + ruta;
        }
        
        public void IngresoConfirmar()
        {
            Console.WriteLine("Camión Ingresado: Nombre: " + this.nombre + " Ruta: " + this.ruta);
            Console.WriteLine();

        }

            public string GetRuta()
        {
            return ruta;
        }
           public string GetNombre()
        {
            return nombre;
        }




    }
}