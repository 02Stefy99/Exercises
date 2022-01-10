using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listino
{
    class Program
    {
        static void Main(string[] args)
        {
            // array per ogni articolo

            string[] articolo = new string[0];
            decimal[] prezzo = new decimal[0];
            double[] ivaApplicata = new double[0];
            double[] ivaCalcolata = new double[0];

            int quantitàArticolo = 0;

            Console.WriteLine("Quanti articoli vuoi inserire?");
            quantitàArticolo = int.Parse(Console.ReadLine());


            for(int i = 0; i < quantitàArticolo; i++)
            {
                Array.Resize(ref articolo, i + 1);
                Array.Resize(ref prezzo, i + 1);
                Array.Resize(ref ivaApplicata, i + 1);
                Array.Resize(ref ivaCalcolata, i + 1);

                Console.Write("\nNome articolo:");
                articolo[i] = Console.ReadLine();

                Console.Write("\nPrezzo:");
                prezzo[i] = Convert.ToDecimal(Console.ReadLine());

                Console.Write("\nIva:");
                ivaApplicata[i] = Convert.ToDouble(Console.ReadLine());

                ivaCalcolata[i] = (Convert.ToDouble(prezzo[i]) * ivaApplicata[i]) / 100;
               
                
            }

            for(int i = 0; i < quantitàArticolo; i++)
            {
                Console.WriteLine($"Articolo: {articolo[i]}\nIva: {ivaApplicata[i]}% - {ivaCalcolata[i]}%\nPrezzo: {prezzo[i]}€");
            }

            Console.ReadKey();

        }
    }
}
