using System;

namespace NQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N Queens Problem!");
            Console.WriteLine("-----------------");

            Console.WriteLine("Enter the number of queens for which this" +
                " problem has to be solved");
            try
            {               
                int numberOfQueens = int.Parse(Console.ReadLine());
                new SolveNQueens(numberOfQueens).PlaceQueens();
            }
            catch (Exception exception) {
                Console.WriteLine(" Thrown exception is " +
                    ""+exception.Message);
            }

            Console.ReadLine();
        }
    }
}
