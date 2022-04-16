using Application;
using Domain;
using System;
using System.Collections.Generic;

namespace ZombieSurvivor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game Booting....");
            var turnService = new TurnService();
            List<Survivor> survivors = new List<Survivor>();
            survivors.Add(new Survivor("Briton"));
            bool quitting = false;
            while (!quitting)
            {
                foreach(var survivor in survivors)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player {survivor.Name}'s turn");
                    turnService.TakeTurn(survivor);
                }
                Console.WriteLine("Do you want to play another round? y/n");
                ConsoleKeyInfo response = Console.ReadKey();
                quitting = response.Key == ConsoleKey.Y; 
            }
        }
    }
}
