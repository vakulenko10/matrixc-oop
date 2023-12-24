using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ZadZaliczeniowe5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            P1();
        }
        static void P1()
        {
            
            Macierz<int> jeden = new Macierz<int>(2, 2);
            Macierz<int> dwa = new Macierz<int>(2, 2);
            Macierz<double> trzy = new Macierz<double>(2, 2);
            decimal[,] tablica1 =
            {
                {1,1 },
                {2,2 }
            };

            double[,] tablica2 = new double[2, 2]
            {
                {1 , 1 },
                {2, 2}
            };
            int[,] tablica3 = new int[2, 2] 
            {
                { 1, 1 },
                {1, 1 }
            };
            Macierz<double> cztery = new Macierz<double>(tablica2);
            for (uint i = 0; i<jeden.samaMacierzTablica.GetLength(0); i++)
            {
                for(uint j = 0; j < jeden.samaMacierzTablica.GetLength(1); j++)
                {
                    jeden[i, j] = Convert.ToInt32(Convert.ToInt32(i) - 10);
                    dwa[i, j] = Convert.ToInt32(i + 1);
                    trzy[i, j] = Convert.ToDouble(i + 1);
                }
            }
            //int z = 1;
            //WriteLine(Convert.ToDouble(1) == Convert.ToDouble(z));
            //WriteLine(jeden.samaMacierzTablica.GetType() == tablica2.GetType());
            //foreach(double n in tablica2)
            //{
            //    Write(n);
            //}
            WriteLine(jeden.Equals(tablica2));
            WriteLine(trzy.Equals(dwa));
            WriteLine(trzy.Equals(tablica1));
            WriteLine(cztery.Equals(jeden));
            //WriteLine(jeden.Equals(dwa));
            ReadLine();
        }
    }
}
