using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22f_Minimumkivalasztásos_rendezes
{
	internal class Program
	{


		static void Minimumkivalasztasos_rendezes<T>(List<T> lista, Func<T,T,int> comparator)
		{
			for (int i = 0; i < lista.Count-1; i++) // i mutatja a rendezetlenség elejét!
			{
				int min_helye = Minimumkereses(lista, i, comparator);
				Csere(lista, i, min_helye); // (lista[i], lista[min_helye]) = (lista[min_helye], lista[i]);
			}
		}

		static void Csere<T>(List<T> lista, int i, int j)
		{
			T temp = lista[i];
			lista[i] = lista[j];
			lista[j] = temp;
		}

		static int kisebb(int egyik, int masik)
		{
			if (egyik < masik)
				return -1;
			if (egyik > masik)
				return 1;
			return 0;
			//	return egyik < masik ? -1 : (egyik == masik ? 0 : 1);
		}

		static int abc_kisebb(string egyik, string masik)
		{
			return egyik.CompareTo(masik);
		}

		static int hossz_kisebb(string a, string b)
		{
			if (a.Length < b.Length)
				return -1;
			if (a.Length > b.Length)
				return 1;
			return 0;
		}

		static int hossz_nagyobb(string a, string b)
		{
			if (a.Length > b.Length)
				return -1;
			if (a.Length < b.Length)
				return 1;
			return 0;
		}

		static int Minimumkereses<T>(List<T> lista, int ettol, Func<T,T,int> comparator)
		{
			int min_helye = ettol;
			for (int i = ettol + 1; i < lista.Count; i++)
			{
				if (comparator(lista[i], lista[min_helye]) == -1)
				{
					min_helye = i;
				}
            }
			return min_helye;
		}

		static void Kiir<T>(List<T> lista)
		{
            foreach (T item in lista)
            {
				Console.Write(item);
				Console.Write(" ");
			}
            Console.WriteLine();
        }

		// példa általánosított eldöntésre: 

		static bool Eldont<T>(List<T> lista, Func<T, bool> predikatum )
		{
			foreach (T item in lista)
				if (predikatum(item))
					return true;
			return false;
		}

		static bool Ketbetus(string s)
		{
			return s.Length == 2;
		}

		static void Main(string[] args)
		{
			List<string> lista = new List<string> { "egy", "kettő", "három", "négy", "öt" };
			Console.WriteLine("Van-e ebben a sorozatban kétbetűs elem?");
			if (Eldont(lista, Ketbetus))
			{
				Console.WriteLine("igen");
			}
			else
			{
				Console.WriteLine("nem");
			}
			Console.WriteLine("Van-e ebben a sorozatban hárombetűs elem?");

			// f(x) = x+5
			// y = x+5
			// x => x+5
			if (Eldont(lista, s => s.Length==3)) // lambda operator: python: lambda s: len(3)==3
			{
				Console.WriteLine("igen");
			}
			else
			{
				Console.WriteLine("nem");
			}


			Console.WriteLine("ez a rendezetlen lista:");
            Kiir(lista);
			Console.WriteLine("ez a lista mégegyszer, de most már rendezve abc-sorrendben:");
			Minimumkivalasztasos_rendezes(lista, abc_kisebb);
			Kiir(lista);
			Console.WriteLine("ez a lista mégegyszer, de most már hossz szerint rendezve:");
			Minimumkivalasztasos_rendezes(lista, hossz_kisebb);
			Kiir(lista);
			Console.WriteLine("ez a lista mégegyszer, de most már hossz szerint csökkenően rendezve:");
			Minimumkivalasztasos_rendezes(lista, hossz_nagyobb);
			Kiir(lista);
			Console.ReadKey();	
        }
	}
}
