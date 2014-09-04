using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L01B
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

            /*Avrundar bellopet till ett heltal och sedan avropar metoden ReadUnit 
            och sedan räknar bellopet som ska kunden få tillbaka*/
            totalToPay = (uint)Math.Round(subtotal);
            totalAmount = ReadUint("Ange erhållet belopp: ", totalToPay);
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
            //SplitIntoDenominations(change);
        }
        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                double money = 0.00;
                Console.Write("{0}", prompt);
                string userInput = Console.ReadLine();

                try
                {

                    money = Convert.ToDouble(userInput);
                    if (money >= 1)
                    {
                        return money;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("\nFEL! '" + money + "' kan inte tolkas som en giltig summa pengar.\n\n");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("\nFEL! \'{0}\' kan inte tolkas som en giltig summa pengar.\n\n", userInput);
                    Console.ResetColor();
                }

            }
        }
        private static uint ReadUint(string prompt, uint minValue)
        {
            while (true)
            {
                uint value = 0;
                Console.Write("{0}", prompt);
                string userInput = Console.ReadLine();

                try
                {

                    value = uint.Parse(userInput);
                    if (value >= minValue)
                    {
                        return value;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("\nFEL!\'{0}\' är ett för litet belopp.\n\n", value);
                        Console.ResetColor();
                    }

                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("\nFEL! \'{0}\' kan inte tolkas som en summa pengar.\n\n", userInput);
                    Console.ResetColor();
                }

            }
        }
        private static void SplitIntoDenominations(uint change)
        {

        }
    }
}
