using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ZadZaliczeniowe5
{
    internal class Macierz<T> : IEquatable<Macierz<T>>, IComparable<Macierz<T>>
    {
        public T[,] samaMacierzTablica;
        public Macierz(uint wierszy, uint kolumny)
        {
            this.samaMacierzTablica = new T[wierszy, kolumny];
        }
        public Macierz(T[,] samaMacierzTablica1)
        {
            this.samaMacierzTablica = samaMacierzTablica1;
        }

        public T this[uint wiersz, uint kolumna]
        {
            get
            {
                return samaMacierzTablica[wiersz, kolumna];
            }
            set
            {
                samaMacierzTablica[wiersz, kolumna] = value;
            }
        }
        public int CompareTo(Macierz<T> druga)
        {
            if(samaMacierzTablica == null || druga == null)
            {
                return 1;
            }
            else if(this.samaMacierzTablica != druga.samaMacierzTablica)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static bool operator ==(Macierz<T> pierwsza, Macierz<T> druga)
        {
            //if ((druga == null))
            //{
            //    return false;
            //}
            if ((druga.samaMacierzTablica.GetLength(0) == pierwsza.samaMacierzTablica.GetLength(0))
                    && (druga.samaMacierzTablica.GetLength(1) == pierwsza.samaMacierzTablica.GetLength(1)))
            {
                bool CzySąRówneLiczbyWTychMacierzach = false;
                for (byte i = 0; i < druga.samaMacierzTablica.GetLength(0); i++)
                {
                    for (byte j = 0; j < druga.samaMacierzTablica.GetLength(1); j++)
                    {
                        if (druga.samaMacierzTablica[i, j].Equals(pierwsza.samaMacierzTablica[i, j]))
                        {
                            CzySąRówneLiczbyWTychMacierzach = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return CzySąRówneLiczbyWTychMacierzach;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return samaMacierzTablica.GetHashCode();
        }
        public static bool operator !=(Macierz<T> pierwsza, Macierz<T> druga)
        {
            if ((druga == null) || (pierwsza == null) || (druga == null && pierwsza != null) || (druga != null && pierwsza == null)
                  //|| (druga.samaMacierzTablica.GetType() != this.samaMacierzTablica.GetType())
                  )
            {
                return true;
            }
            else if (pierwsza.samaMacierzTablica.GetLength(0) == druga.samaMacierzTablica.GetLength(0)
                || pierwsza.samaMacierzTablica.GetLength(1) == druga.samaMacierzTablica.GetLength(1))
            {
                bool CzySąRówneLiczbyWTychMacierzach = false;
                for (byte i = 0; i < druga.samaMacierzTablica.GetLength(0); i++)
                {
                    for (byte j = 0; j < druga.samaMacierzTablica.GetLength(1); j++)
                    {
                        if (druga.samaMacierzTablica[i, j].Equals(pierwsza.samaMacierzTablica[i, j]))
                        {
                            CzySąRówneLiczbyWTychMacierzach = true;
                        }
                        else
                        {
                            CzySąRówneLiczbyWTychMacierzach = false;
                        }
                    }
                }
                return !CzySąRówneLiczbyWTychMacierzach;
            }
            else
            {
                return true;
            }
        }


        // tu stworzyłem metodę która pozwala porownywać Macierz<T> z róznymi objektami(włącznie z Macierzami innych typów)
        public override bool Equals(object druga)
        {

            if (druga is Macierz<T>)
            {
                return this == (Macierz<T>)druga;
            }
            else
            {
                Type typObjectu1 = typeof(double[,]);
                Type typObjectu2 = typeof(int[,]);
                Type typObjectu3 = typeof(long[,]);
                Type typObjectu4 = typeof(short[,]);
                Type typObjectu5 = typeof(ushort[,]);
                Type typObjectu6 = typeof(uint[,]);
                Type typObjectu7 = typeof(decimal[,]);
                if (druga.GetType() == typObjectu1 || druga is Macierz<double>)
                {
                    double[,] NowaTablicaNowegoTypu = new double[this.samaMacierzTablica.GetLength(0), this.samaMacierzTablica.GetLength(1)];
                    for (uint i = 0; i < NowaTablicaNowegoTypu.GetLength(0); i++)
                    {
                        for (uint j = 0; j < NowaTablicaNowegoTypu.GetLength(1); j++)
                        {
                            NowaTablicaNowegoTypu[i, j] = Convert.ToDouble(this.samaMacierzTablica[i, j]);
                        }
                    }

                    if ((druga is double[,] drugaTablica && new Macierz<double>(drugaTablica) == new Macierz<double>(NowaTablicaNowegoTypu))
                        || (druga is Macierz<double> drugaMacierz && drugaMacierz == new Macierz<double>(NowaTablicaNowegoTypu)))
                    {
                        Console.WriteLine("są równe 'double' ");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("nie są równe 'double'");
                        return false;
                    }
                }
                else if (druga.GetType() == typObjectu2 || druga is Macierz<int>)
                {
                    int[,] NowaTablicaNowegoTypu = new int[this.samaMacierzTablica.GetLength(0), this.samaMacierzTablica.GetLength(1)];
                    for (uint i = 0; i < NowaTablicaNowegoTypu.GetLength(0); i++)
                    {
                        for (uint j = 0; j < NowaTablicaNowegoTypu.GetLength(1); j++)
                        {
                            NowaTablicaNowegoTypu[i, j] = Convert.ToInt32(this.samaMacierzTablica[i, j]);
                        }
                    }
                    //kopijuję i konwertuję Tablicę tej instancji w tymczasową tablicę NowaTablicaNowegoTypu
                    if (druga is int[,] drugaTablica && new Macierz<int>(drugaTablica) == new Macierz<int>(NowaTablicaNowegoTypu)
                        || (druga is Macierz<int> drugaMacierz && drugaMacierz == new Macierz<int>(NowaTablicaNowegoTypu)))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("nie są równe 'int'");
                        return false;
                    }
                }
                else if (druga.GetType() == typObjectu3 || druga is Macierz<long>)
                {
                    long[,] NowaTablicaNowegoTypu = new long[this.samaMacierzTablica.GetLength(0), this.samaMacierzTablica.GetLength(1)];
                    for (uint i = 0; i < NowaTablicaNowegoTypu.GetLength(0); i++)
                    {
                        for (uint j = 0; j < NowaTablicaNowegoTypu.GetLength(1); j++)
                        {
                            NowaTablicaNowegoTypu[i, j] = Convert.ToInt64(this.samaMacierzTablica[i, j]);
                        }
                    }
                    if (druga is long[,] drugaTablica && new Macierz<long>(drugaTablica) == new Macierz<long>(NowaTablicaNowegoTypu)
                        || (druga is Macierz<long> drugaMacierz && drugaMacierz == new Macierz<long>(NowaTablicaNowegoTypu)))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("nie są równe 'long'");
                        return false;
                    }
                }
                else if (druga.GetType() == typObjectu4 || druga is Macierz<short>)
                {
                    short[,] NowaTablicaNowegoTypu = new short[this.samaMacierzTablica.GetLength(0), this.samaMacierzTablica.GetLength(1)];
                    for (uint i = 0; i < NowaTablicaNowegoTypu.GetLength(0); i++)
                    {
                        for (uint j = 0; j < NowaTablicaNowegoTypu.GetLength(1); j++)
                        {
                            NowaTablicaNowegoTypu[i, j] = Convert.ToInt16(this.samaMacierzTablica[i, j]);
                        }
                    }
                    if (druga is short[,] drugaTablica && new Macierz<short>(drugaTablica) == new Macierz<short>(NowaTablicaNowegoTypu)
                        || (druga is Macierz<short> drugaMacierz && drugaMacierz == new Macierz<short>(NowaTablicaNowegoTypu)))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("nie są równe 'short'");
                        return false;
                    }
                }
                else if (druga.GetType() == typObjectu5 || druga is Macierz<ushort>)
                {
                    ushort[,] NowaTablicaNowegoTypu = new ushort[this.samaMacierzTablica.GetLength(0), this.samaMacierzTablica.GetLength(1)];
                    for (uint i = 0; i < NowaTablicaNowegoTypu.GetLength(0); i++)
                    {
                        for (uint j = 0; j < NowaTablicaNowegoTypu.GetLength(1); j++)
                        {
                            NowaTablicaNowegoTypu[i, j] = Convert.ToUInt16(this.samaMacierzTablica[i, j]);
                        }
                    }
                    if (druga is ushort[,] drugaTablica && new Macierz<ushort>(drugaTablica) == new Macierz<ushort>(NowaTablicaNowegoTypu)
                        || (druga is Macierz<ushort> drugaMacierz && drugaMacierz == new Macierz<ushort>(NowaTablicaNowegoTypu)))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("nie są równe 'ushort'");
                        return false;
                    }
                }
                else if (druga.GetType() == typObjectu6 || druga is Macierz<uint>)
                {
                    uint[,] NowaTablicaNowegoTypu = new uint[this.samaMacierzTablica.GetLength(0), this.samaMacierzTablica.GetLength(1)];
                    for (uint i = 0; i < NowaTablicaNowegoTypu.GetLength(0); i++)
                    {
                        for (uint j = 0; j < NowaTablicaNowegoTypu.GetLength(1); j++)
                        {
                            NowaTablicaNowegoTypu[i, j] = Convert.ToUInt32(this.samaMacierzTablica[i, j]);
                        }
                    }
                    if (druga is uint[,] drugaTablica && new Macierz<uint>(drugaTablica) == new Macierz<uint>(NowaTablicaNowegoTypu)
                        || (druga is Macierz<uint> drugaMacierz && drugaMacierz == new Macierz<uint>(NowaTablicaNowegoTypu)))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("nie są równe 'uint'");
                        return false;
                    }
                }
                else if (druga.GetType() == typObjectu7 || druga is Macierz<decimal>)
                {
                    decimal[,] NowaTablicaNowegoTypu = new decimal[this.samaMacierzTablica.GetLength(0), this.samaMacierzTablica.GetLength(1)];
                    for (uint i = 0; i < NowaTablicaNowegoTypu.GetLength(0); i++)
                    {
                        for (uint j = 0; j < NowaTablicaNowegoTypu.GetLength(1); j++)
                        {
                            NowaTablicaNowegoTypu[i, j] = Convert.ToDecimal(this.samaMacierzTablica[i, j]);
                        }
                    }
                    if (druga is decimal[,] drugaTablica && new Macierz<decimal>(drugaTablica) == new Macierz<decimal>(NowaTablicaNowegoTypu)
                        || (druga is Macierz<decimal> drugaMacierz && drugaMacierz == new Macierz<decimal>(NowaTablicaNowegoTypu)))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("nie są równe 'decimal'");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }
        public bool Equals(Macierz<T> druga)
        {
            if (druga == this)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
