using System;

namespace RougeLike.App.Common
{
    public static class Messages
    {
        public static void AfterFight(int gainedExp, int gainedMoney)
        {
            Console.WriteLine("You got:");
            Console.WriteLine($"{gainedExp} exp");
            Console.WriteLine($"{gainedMoney} gold");
            Console.WriteLine("Press enter to continue...");
            Console.Read();
            Console.Clear();
        }

        public static void SaveResult(bool isOk)
        {
            if (isOk)
            {
                Console.Clear();
                Console.WriteLine("Your character was successfully saved");
                Console.WriteLine("Press enter to continue...");
                Console.Read();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something went wrong try again");
                Console.WriteLine("Press enter to continue...");
                Console.Read();
            }
        }

        public static bool LoadResult(bool isOk)
        {
            if (isOk)
            {
                Console.Clear();
                Console.WriteLine("Your character was successfully loaded");
                Console.WriteLine("Press enter to continue...");
                Console.Read();
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something went wrong try again");
                Console.WriteLine("Press enter to continue...");
                Console.Read();
                return true;
            }
        }

        public static void WrongOption()
        {
            Console.Clear();
            Console.WriteLine("Option you selected doesn't exist");
            Console.WriteLine("Click enter to continue");
            Console.Read();
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit?(Y/N)");
            var confirm = Console.ReadLine();
            if (confirm == "y" || confirm == "Y")
            {
                Console.WriteLine("OK so BYE!!!");
                System.Environment.Exit(1);
            }
        }
    }
}