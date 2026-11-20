
using System;
using System.Collections.Generic;

class Program
{
    static Queue<string> deposit = new Queue<string>();
    static Queue<string> withdraw = new Queue<string>();
    static Queue<string> inquire = new Queue<string>();
    static Queue<string> others = new Queue<string>();

    static void Main()
    {
        // DSA Activity 6.2 - Rubi, Vince Paul Ronald

        bool running = true;

        Console.WriteLine("Welcome to ECO BANK, INC.");

        while (running)
        {
            Console.WriteLine("\nSelect your transaction");
            Console.WriteLine("1 - DEPOSIT");
            Console.WriteLine("2 - WITHDRAW");
            Console.WriteLine("3 - INQUIRE");
            Console.WriteLine("4 - OTHERS");
            Console.Write("Enter code: ");

            string choice = Console.ReadLine();

            if (choice == "1" || choice == "2" ||
                choice == "3" || choice == "4")
            {
                Console.WriteLine("\nYou have chosen " +
                    GetTransactionName(choice));

                Console.Write("Please enter your account name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid account name!");
                }
                else
                {
                    AddClient(choice, name.Trim());
                    DisplayQueues();
                }
            }
            else if (choice == "10" || choice == "20" ||
                     choice == "30" || choice == "40")
            {
                if (choice == "10")
                    CompleteTransaction(deposit, "DEPOSIT");

                else if (choice == "20")
                    CompleteTransaction(withdraw, "WITHDRAW");

                else if (choice == "30")
                    CompleteTransaction(inquire, "INQUIRE");

                else if (choice == "40")
                    CompleteTransaction(others, "OTHERS");

                DisplayQueues();
            }
            else if (choice == "0")
            {
                running = false;
                Console.WriteLine("Thank you for using ECO BANK, INC.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static string GetTransactionName(string code)
    {
        if (code == "1")
            return "DEPOSIT";

        else if (code == "2")
            return "WITHDRAW";

        else if (code == "3")
            return "INQUIRE";

        else
            return "OTHERS";
    }

    static void AddClient(string code, string name)
    {
        if (code == "1")
            deposit.Enqueue(name);

        else if (code == "2")
            withdraw.Enqueue(name);

        else if (code == "3")
            inquire.Enqueue(name);

        else
            others.Enqueue(name);

        Console.WriteLine("You have been added to the waiting list.");
    }

    static void CompleteTransaction(Queue<string> queue,
                                    string transaction)
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("No client waiting for " + transaction);
        }
        else
        {
            string served = queue.Dequeue();

            Console.WriteLine("\nTransaction Completed!");
            Console.WriteLine(served + " has been served.");
        }
    }

    static void DisplayQueues()
    {
        Console.WriteLine("\nNOW SERVING!!! NOW SERVING!!!");

        Console.WriteLine("DEP : " + GetServing(deposit));
        Console.WriteLine("WID : " + GetServing(withdraw));
        Console.WriteLine("INQ : " + GetServing(inquire));
        Console.WriteLine("OTH : " + GetServing(others));

        Console.WriteLine("\nWAITING LIST!!! WAITING LIST!!!");

        Console.WriteLine("------------------------------------------");

        PrintQueue("DEPOSIT", deposit);
        PrintQueue("WITHDRAWAL", withdraw);
        PrintQueue("INQUIRE", inquire);
        PrintQueue("OTHERS", others);

        Console.WriteLine("------------------------------------------");
    }

    static string GetServing(Queue<string> queue)
    {
        if (queue.Count == 0)
            return "";

        return queue.Peek();
    }

    static void PrintQueue(string title, Queue<string> queue)
    {
        Console.WriteLine("\n" + title + " (" + queue.Count + ")");

        if (queue.Count == 0)
        {
            Console.WriteLine("No client");
        }
        else
        {
            int number = 1;

            foreach (string name in queue)
            {
                Console.WriteLine(number + ". " + name);
                number++;
            }
        }
    }
}
