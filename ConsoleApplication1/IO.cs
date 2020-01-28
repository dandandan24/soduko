using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class IO
    {
        private String input1;

        public IO()
        {
            int contin = 1;
            Console.WriteLine("Which kind of input you want to use? anything else-fromfile 0-from console");
            int whichone = int.Parse(Console.ReadLine()); // 1= read from file , 0= read from user 
            if (whichone == 0) // read from console
            {
                Console.WriteLine("enter a string that will represent the soduko board");
                input1 = Console.ReadLine(); // getting the string from the user
            }
            else // read from file
            {
                while (contin == 1)
                {
                    
                    Console.WriteLine("enter the path of the file:");
                    try
                    {
                        String path = Console.ReadLine();
                        input1 = System.IO.File.ReadAllText(@path);
                    }
                    catch (Exception es)
                    {
                        Console.WriteLine("the path wasnt valid,enter a new one:");
                        
                        continue;
                    }
                    contin = 0;
                    input1 = input1.Replace("\r\n", "");
                    input1 = input1.Replace(".", "0");
                }
            }
            
           
        }
        public String GetInput()
        {
            return input1;
        }
        public static String ReturnToString(boardElement[,] arr)
        {
            String output = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int J = 0; J < arr.GetLength(0); J++)
                {
                    output += arr[i, J];
                }
            }
            return output;
        }

    }
}
