using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Validity
    {
        public static bool isPossibleInput(String s) // checking if the input can be solve able(there are not 2 same numbers in the row col or cube)
        {
            int [] arrrow = new int[(int)Math.Floor(Math.Sqrt(s.Length))]; // counter array for each row
            int []arrcol = new int[(int)Math.Floor(Math.Sqrt(s.Length))]; // counter array for each col
            Array.Clear(arrrow, 0, arrrow.Length);
            Array.Clear(arrcol, 0, arrcol.Length);
            //first we will check the row and col
            for (int row = 0; row < Math.Sqrt(s.Length); row++)
            {
                for (int col = 0; col < Math.Sqrt(s.Length); col++)
                {
                    if ((s[(row * (int)Math.Sqrt(s.Length)) + col]- '0') != 0) // the value 0 can appear many times in the same raw or col
                    {
                        arrrow[s[(row * (int)Math.Sqrt(s.Length)) + col] - 1 - '0']++; // ++ the index of the value 
                        if (arrrow[s[(row * (int)Math.Sqrt(s.Length)) + col] - 1 - '0'] > 1) // if same value repeated more than once in the same row  than return false
                        {
                            return false;
                        }
                    }
                    if(s[row + col * (int)Math.Sqrt(s.Length)] - '0' !=0)
                    {
                        arrcol[s[row + col * (int)Math.Sqrt(s.Length)] - '0' - 1]++;
                        if (arrcol[s[row + col * (int)Math.Sqrt(s.Length)] - '0' - 1] > 1) // if same value repeated more than once in the same col than return false
                        {
                            return false;
                        }
                    }

                }
                for (int i = 0; i < (int)Math.Sqrt(s.Length); i++) // placing 0 in every slot because we switch to the next row and col
                {
                    arrrow[i] = 0;
                    arrcol[i] = 0;
                }
            }
            return true;
        }
        public static bool IsValidInLength(String s)
        {
            double SqureRoot = Math.Sqrt(Math.Sqrt(s.Length));
            if ((SqureRoot) == Math.Floor(SqureRoot)) // checking if the number's root is round number*
            {
                return true;
            }
            return false;
        }

        public static void ResetArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
        }
        public static bool IsPossibleInputQube(String s)
        {
            int[,] arr = new int[(int)Math.Sqrt(s.Length),(int)Math.Sqrt(s.Length)];
            for (int i = 0; i < Math.Sqrt(s.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(s.Length); j++)
                {
                    arr[i, j] = s[(int)(i * Math.Sqrt(s.Length)) + j]-'0';
                    
                }
               
            }

            int cubeCol = 0, cubeRow = 0,counter =0;
            for (int k = 0; k < (int)Math.Sqrt(s.Length); k++)
			{
			 
			
                for (int z = 1 ; z <= (int)Math.Sqrt(s.Length); z++)
                {
                    for (int i = cubeRow; i < (int)Math.Sqrt(Math.Sqrt(s.Length)) + cubeRow; i++)
                    {
                        for (int j = cubeCol; j < (int)Math.Sqrt(Math.Sqrt(s.Length)) + cubeCol; j++)
                        {
                            if (arr[i, j] == z)
                            {
                                counter++;
                            }
                            if (counter > 1)
                            {
                                return false;
                            }
                        }
                    }                                
                    counter = 0;
                }
                cubeCol += (int)Math.Sqrt(Math.Sqrt(s.Length));
                if (cubeCol >= (int)Math.Sqrt(s.Length))
                {
                    cubeRow += (int)Math.Sqrt(Math.Sqrt(s.Length));                   
                    cubeCol = 0;
                }
            
                
            }
            return true;
            
        }
        public static bool IsValidInput(String s) // checks if all the chars in the input are in the needed range
        {
            char c0 = '0';
            int sqrt = (int)(Math.Sqrt(s.Length));
            for (int i = 0; i < s.Length; i++)
            {
                if ('0' <= s[i] && s[i] <= c0 + sqrt);
                else
                {
                    return false;
                }
            }
            return true;
        }


        public static bool IsValid(String s)
        {
            if (IsValidInLength(s)) // checks if the board we got is in valid length
            {
                if (IsValidInput(s)) // check if all the values we got is the needed range
                {
                    if (isPossibleInput(s)&&IsPossibleInputQube(s))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("the input in not possible");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("the input is not valid, the chars are not in the range they are suppose to be");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("the length of the board is not possible");
                Console.WriteLine(s.Length);
                return false;
            }
        }

    }
}
