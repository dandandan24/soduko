using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isSolveableInTime,Continue = true;
            board b;
            
            while(Continue)
            {
                IO in1 = new IO();  // creating an input object that will create the string
                
                if (Validity.IsValid(in1.GetInput()))
                {
                    b = new board(in1.GetInput()); // creating a board with char array that represents the board  
                    b.filltheBoard();
                    isSolveableInTime = b.solution(); // the algorithm that solves the given board and returns a string
                    if (isSolveableInTime)
                    {
                        b.solutionBackwards();
                    }
                    String s = b.returnString();
                    Console.WriteLine(s);
                }            
                    Console.WriteLine("do you want to enter other soduko board?  enter 1 to continue or 0 to break");
                    int toContinue = int.Parse(Console.ReadLine());
                    if (toContinue <= 0)
                    {
                        Continue = false;
                    }
            }

            
         }
    }
}
