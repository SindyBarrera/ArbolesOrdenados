using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Clases.ArbolBinarioOrdenado
{
    
    class SoloNumeros : Comparador //IMPLEMENTANDO LA CLASE CON COMPARADOR
    {
        public int numero;
        public string descripcion;
        public bool igualQue(object q)
        {
            //Para la busqueda
            //SoloNumeros p2 = (SoloNumeros)q;
            //return numero == p2.numero;

            return true;
        }

        public bool mayorIgualQue(object q)
        {
            SoloNumeros p2 = (SoloNumeros)q;
            return numero >= p2.numero;
        }

        public bool mayorQue(object q)
        {
            SoloNumeros p2 = (SoloNumeros)q;
            return numero > p2.numero;
        }

        public bool menorIgualQue(object q)
        {
            SoloNumeros p2 = (SoloNumeros)q;
            return numero <= p2.numero;
        }

        public bool menorQue(object q)
        {
            SoloNumeros p2 = (SoloNumeros)q;
            return numero < p2.numero;
        }
    }
}
