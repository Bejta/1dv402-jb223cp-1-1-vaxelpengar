using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DV402.S1.L01C.Properties;

namespace _1DV402.S1.L01C
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console title
            Console.Title = "Växelpengar - nivå C";

            do
            {
                /* 
                 * Declaration and initialization of variables that will be 
                 * used in program. Some simple calculations are also done here.
                 */
                double subtotal = ReadPositiveDouble(Resources.Total_Prompt);
                uint totalToPay = (uint)Math.Round(subtotal);
                uint totalAmount = ReadUint(Resources.Cash_Prompt, totalToPay);
                double roundingOffAmount = totalToPay - subtotal;
                uint change = totalAmount - totalToPay;

                /* 
                 * Array with valid valuse for Swedish coins and paper money, and call to
                 * method that calculates change and sorts it in different values of specific
                 * denomination
                 */
                uint[] validValues = new uint[] { 500, 100, 50, 20, 10, 5, 1 };
                uint[] inscriptions = SplitIntoDenominations(change, validValues);

                /* 
                 * Writes one receipt in console.
                 * All possible arguments are sent to this method
                 */
                ViewReceipt(subtotal, roundingOffAmount, totalToPay, totalAmount, change, inscriptions, validValues);

                /* 
                 * I don´t need to send second parameter to ViewMessage method, 
                 * as it has default value
                 */
                ViewMessage(Resources.Continue_Prompt);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }

        private static double ReadPositiveDouble(string prompt)
        {
            double money = 0.00;

            while (true)
            {
                /*
                 * Detailed comments around exceptions are in ReadUint method,
                 * which contains very similar code when it comes to throwing exceptions
                 */
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
                        throw new ArgumentOutOfRangeException(userInput + Resources.FailReadDouble_Prompt);
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    ViewMessage(e.ParamName, true);
                }
                catch
                {
                    ViewMessage(userInput + Resources.FailReadDouble_Prompt, true);
                }
            }
        }
        private static uint ReadUint(string prompt, uint minValue)
        {
            while (true)
            {
                uint value = 0;
                Console.Write(prompt);
                /* 
                 * userInput has to be declared outside of try-catch block
                 * so it can be reachable in catch parts...
                 */
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
                        throw new ArgumentOutOfRangeException(userInput + Resources.LowReadInt_Prompt);
                    }
                }
                /*
                 * ArgumentOutOfRangeException class inherite from Exception class.
                 * One of the objects of class is ParamName which sends Parameter from
                 * place where exception is thrown.
                 */
                catch (ArgumentOutOfRangeException e)
                {
                    ViewMessage(e.ParamName, true);
                }
                /*
                 * Default Exception doesn´t have ParamName object, and instead I could use e.Message,
                 * but in that case I didn´t find the solution how to send an argument as Exception is trown
                 * on uint.Parse(userInput) line.
                 */
                catch
                {
                    ViewMessage(userInput + Resources.FailReadInt_Prompt, true);
                }
            }
        }
        private static uint[] SplitIntoDenominations(uint change, uint[] denominations)
        {
            /* 
             * By use of % and / I can determine remainder of simple division
             * between two integers. In Array that will be returned from method
             * I write even zeros, as I need that denominations array is identical in size as 
             * returned array. Later on, in method ViewReceipt I can iterate throught both arrays
             * at the same time by simple index iteration.
             */
            uint[] myArray = new uint[denominations.Length];
            uint remain = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                remain = change / denominations[i];
                change %= denominations[i];
                myArray[i] = remain;
            }
            return myArray;
        }
        private static void ViewMessage(string message, bool isError = false)
        {
            /* 
             * This method changes color on messages in dependence
             * if message is error message or normal message
             */
            Console.WriteLine();
            if (isError)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("FEL! "); // Every error message begins with this part
                Console.WriteLine(message);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(message);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        private static void ViewReceipt(double subtotal, double RoundingOffAmount, uint total, uint cash, uint change, uint[] notes, uint[] denominations)
        {
            /* First part of ViewReceipt method writes out one receipt
             * */
            Console.WriteLine("");
            Console.WriteLine("KVITTO");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-17}{1,1}{2,13:c2}", "Totalt", ":", subtotal);
            Console.WriteLine("{0,-17}{1,1}{2,13:c2}", "Öresavrundning", ":", RoundingOffAmount);
            Console.WriteLine("{0,-17}{1,1}{2,13:c0}", "Att betala", ":", total);
            Console.WriteLine("{0,-17}{1,1}{2,13:c0}", "Kontant", ":", cash);
            Console.WriteLine("{0,-17}{1,1}{2,13:c0}", "Tillbaka", ":", change);
            Console.WriteLine("-------------------------------");

            /* * Iterate index of both arrays trought one for-loop
               * so I can work with corresponding values in one iteration
               */
            for (int i = 0; i < denominations.Length; i++)
            {
                /* Writes only these values from notes array that
                 * are not equal to zero
                 * */
                if (notes[i] != 0)
                {
                    /* This switch has only task to decide if it will show
                     * -kronor or -lappar in console, and write out formated values.
                     * */
                    switch (denominations[i])
                    {
                        case 10:
                        case 5:
                        case 1:
                            Console.WriteLine("{0,3}{1,-14}{2}{3}", denominations[i], "-kronor", ": ", notes[i]);
                            break;
                        default:
                            Console.WriteLine("{0,3}{1,-14}{2}{3}", denominations[i], "-lappar", ": ", notes[i]);
                            break;
                    }
                }
            }
        }
    }
}
