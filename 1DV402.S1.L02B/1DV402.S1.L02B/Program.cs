using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L02B
{
    class Program
    {
        static void Main(string[] args)
        {

            //Sätter titel på Konsolfönstret
            Console.Title = "Växelpengar - nivå B";

            //Deklarerar och initialiserar variabler
            double roundingOffAmount = 0.00;
            uint totalAmount = 0;
            uint totalToPay = 0;
            uint change = 0;
            double subtotal = 0.00;

            //Anropar metod ReadPositiveDouble för att användaren ska mata in 
            subtotal = ReadPositiveDouble("Ange totalsumma     : ");

            //Avrundar bellopet till ett heltal och sedan avropar metoden ReadUnit för att användaren ska mata in en summa 
            totalToPay = (uint)Math.Round(subtotal);
            totalAmount = ReadUint("Ange erhållet belopp: ", (uint)Math.Round(subtotal));
            roundingOffAmount = totalToPay - subtotal;
            change = totalAmount - totalToPay;

            // Skriver ut ett kvitto
            Console.WriteLine("");
            Console.WriteLine("KVITTO");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-17}{1,1}{2,13:c2}", "Totalt", ":", subtotal);
            Console.WriteLine("{0,-17}{1,1}{2,13:c2}", "Öresavrundning", ":", roundingOffAmount);
            Console.WriteLine("{0,-17}{1,1}{2,13:c0}", "Att betala", ":", totalToPay);
            Console.WriteLine("{0,-17}{1,1}{2,13:c0}", "Kontant", ":", totalAmount);
            Console.WriteLine("{0,-17}{1,1}{2,13:c0}", "Tillbaka", ":", change);
            Console.WriteLine("-------------------------------");

            //anropar metoden SplitIntoDenominations
            SplitIntoDenominations(change);

        }
        private static double ReadPositiveDouble(string prompt)
        {

        }
        private static uint ReadUint (string prompt, uint minValue)
        {

        }
        private static void SplitIntoDenominations (uint change)
        {

        }
    }
}
