using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PruebaTecnica_Punto2
{
    public class GestionLista
    {
        List<string> lstObjetos = new List<string>();

        public void MostrarMenu()
        {
            Console.WriteLine("Bienvenido, Seleccione la opcion deseada.");
            Console.WriteLine("\nA.Agregar Elemento.");
            Console.WriteLine("B.Buscar Elemento.");
            Console.WriteLine("C.Listar Elementos Repetidos.");
            Console.WriteLine("D.Ordenar de Menor a Mayor.");
            Console.WriteLine("E.Ordenar de Mayor a Menor.");
            Console.WriteLine("F.Imprimir Lista Original");
            Console.WriteLine("G.Salir.");

            Console.WriteLine("\nDigite Opcion:");
            var t = Console.ReadLine();
            bool _continue = true;
            switch (t.ToUpper())
            {
                case "A": AgregarElemento(); break;
                case "B": BuscaryMostrarElemento(); break;
                case "C": MostrarElementosRepetidos(); break;
                case "D": MostarListaOrdenadaAscendente(); break;
                case "E": MostarListaOrdenadaDescendente(); break;
                case "F": ImprimirListaOriginal(); break;
                case "G": _continue = false; break;
                default:
                    Console.WriteLine("Opcion No se encuentra en el Menú.\n");                    
                    break;
            }
            if (_continue)
            {
                Console.WriteLine();
                MostrarMenu();
            }
        }

        private void ImprimirListaOriginal()
        {
            ImprimirList(lstObjetos);
        }

        private void ImprimirList(List<string> lst)
        {
            if (lst.Count == 0)
            {
                Console.WriteLine("No hay elementos para mostrar en esta lista.");
            }
            foreach(var y in lst)
            {
                Console.WriteLine("Elemento: "+y);
            }
        }

        private void MostarListaOrdenadaDescendente()
        {
            List<string> lstOrdAsc = lstObjetos;
            ImprimirList(lstOrdAsc.OrderByDescending(i => i).ToList());
        }

        private void MostarListaOrdenadaAscendente()
        {
            List<string> lstOrdAsc = lstObjetos;
            lstOrdAsc.Sort();
            ImprimirList(lstOrdAsc);
        }

        private void MostrarElementosRepetidos()
        {
            List<string> repetidos = new List<string>();

            foreach (var y in lstObjetos)
            {
                int count = 0;
                foreach (var x in lstObjetos)
                {
                    if (y == x)
                    {
                        count++;
                    }
                    if (count > 1)
                    {
                        if(!repetidos.Contains(x))
                            repetidos.Add(x);
                        break;
                    }
                }
            }
            ImprimirList(repetidos);
            
        }

        private void BuscaryMostrarElemento()
        {
            Console.WriteLine("\nDigite Elemento a Buscar: ");
            var t = Console.ReadLine();
            string result = lstObjetos.SingleOrDefault(s => s.Equals(t));
            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Elemento no encontrado");
            }
            else
            {
                Console.WriteLine("El elemento "+result+" fue encontrado en la Lista.");    
            }
        }

        private void AgregarElemento()
        {
            Console.WriteLine("\nDigite Elemento a Agregar: ");
            var t = Console.ReadLine();
            lstObjetos.Add(t);
        }
    }
}
