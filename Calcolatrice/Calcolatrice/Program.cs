using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = 0, n2 = 0;
            string operazione = "0";
            bool ripetizione = false;

            Console.WriteLine("Digita il primo numero");
            n1 = double.Parse(Console.ReadLine());

            do
            {

                do
                {
                    Console.WriteLine("Scegli un'operazione matematica:\n+ Addizione\n- Sottrazione\n* Moltiplicazione\n/ divisione\nt Totale\nc Cancella\nx per uscire");
                    operazione = Console.ReadLine();
                } while (operazione != "+" && operazione != "-" && operazione != "*" && operazione != "/" && operazione != "t" && operazione != "c" && operazione != "x");

                if (operazione != "c" && operazione != "t" && operazione != "x")
                {


                    Console.WriteLine("Digita un altro numero");
                    n2 = double.Parse(Console.ReadLine());
                }

                switch (operazione)
                {
                    case "+":
                        n1 = n1 + n2;
                        ripetizione = true;
                        Console.WriteLine("Totale ultima operazione " + n1);
                        break;

                    case "-":
                        n1 = n1 - n2;
                        ripetizione = true;
                        Console.WriteLine("Totale ultima operazione " + n1);
                        break;

                    case "*":
                        n1 = n1 * n2;
                        ripetizione = true;
                        Console.WriteLine("Totale ultima operazione " + n1);
                        break;

                    case "/":
                        n1 = n1 / n2;
                        ripetizione = true;
                        Console.WriteLine("Totale ultima operazione " + n1);
                        break;

                    case "t":

                        Console.WriteLine("Totale  " + n1);
                        ripetizione = false;
                       
                       goto case "c";

                    case "c":
                            n1 = 0; n2 = 0;
                            operazione = "0";
                            ripetizione = true;
                        Console.WriteLine("Tutto è stato cancellato");
                        Console.WriteLine("Digita un numero per ricominciare");
                        n1 = double.Parse(Console.ReadLine());
                        break;
                }
            } while (ripetizione == true && operazione != "x");

            Console.ReadKey();
        }
    }



}
    

