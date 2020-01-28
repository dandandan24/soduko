using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace ConsoleApplication1
{
    public class board//board
    {
        private boardElement[,] array_Board;
        private Stack<int> stack_Row = new Stack<int>();
        private Stack<int> stack_Col = new Stack<int>();
        public board(String s) // creating the board depends on if we got valid input or not
        {
            array_Board = new boardElement[(int)(Math.Sqrt(s.Length)), (int)(Math.Sqrt(s.Length))];
                for (int i = 0; i < Math.Sqrt(s.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(s.Length); j++)
                    {
                        array_Board[i, j] = new boardElement();
                        if (s[i * (int)(Math.Sqrt(s.Length)) + j] != '0')
                        {
                            array_Board[i, j].setConst(true);
                        }
                        array_Board[i,j].setValue(s[i * (int)(Math.Sqrt(s.Length)) + j]);
                       
                    }
                }
                PrintBoard();       
        }

        public void PrintBoard() // printing the board
        {
            int SizeOfSide = (int)(Math.Sqrt(array_Board.GetLength(0))); // the size of one cube of the board, for example for 9*9 it will be 3
            for (int i = 0; i < array_Board.GetLength(0); i++)
            {
                if (i != 0 && i % SizeOfSide == 0)
                {
                    Console.WriteLine();
                }
                
                for (int j = 0; j < array_Board.GetLength(1); j++)
                {
                    if(j%SizeOfSide==0)
                    {

                        Console.Write("   ");
                    }
                    if (array_Board[i, j].getConst())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(array_Board[i, j].getValue());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(array_Board[i, j].getValue());
                    }
                }
                Console.WriteLine();
                
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
       

        public int roundDownRow(int row) // get an row number and round it to the closest start of cube( for example for row 4 on 9*9 board it will return 3
        {
            int length = (int)(Math.Sqrt(array_Board.GetLength(0)));
            if (row % length == 0)
            {
                return row;
            }
            return roundDownCol(row - 1);
        }


        public int roundDownCol(int col) // get an col number and round it to the closest start of cube( for example for col 4 on 9*9 board it will return 3
        {
       
            int length = (int)(Math.Sqrt(array_Board.GetLength(0)));
            if (col % length == 0)
            {
                return col;
            }
            return roundDownCol(col - 1);
        }

        public void ResetLists()
        {
            for (int k = 0; k < array_Board.GetLength(1); k++)
            {
                for (int z = 0; z < array_Board.GetLength(1); z++)
                {
                    array_Board[k, z].resetList();
                }
            }
        }
        public void filltheBoard()
        {
            for (int w = 0; w < 100; w++) // we will go over the board 30 times because after we got constant on the last cube we might get dicover a new one on a cube we already checked 
            {


                //every slot in the array got his list of options
                for (int k = 0; k < array_Board.GetLength(1); k++)
                {
                    for (int z = 0; z < array_Board.GetLength(1); z++)
                    {
                        checkoptions(k, z);
                    }
                }
                int i = 0, j = 0;
                while (i <= array_Board.GetLength(1) - 1)
                {
                    while (j <= array_Board.GetLength(1) - 1)
                    {
                        getConst(i, j);
                        j += (int)Math.Sqrt(array_Board.GetLength(0));
                    }
                    j = 0;
                    i += (int)Math.Sqrt(array_Board.GetLength(0)) ;
                }
                
                ResetLists(); // in the end reset the list so the solution wont have problems

            }
            PrintBoard();
        }

        public void getConst(int cubeR,int cubeC ) // this func discovers all the constant items on the board
        {
            //4100030000000014
            // now we will run on every one of the lists in the same cube and will check if there is any unique numbers that we can assume as constant
            int counterC = cubeC,counterR= cubeR;
        
             // will get we the unique items. from {2,3,4},{1,3,4} return 2
            
            for (int z = 0; z < (int)(array_Board.GetLength(0)) + 0; z++) // running on all the slots in the cube
            {                               
                    List<int> currentlist = array_Board[counterR, counterC].getList();
                    for (int i = cubeR; i < (int)Math.Sqrt(array_Board.GetLength(0)) + cubeR; i++) // these loops will run on the specified cube and will check equality between the lists
                    {

                        for (int j = cubeC; j < (int)Math.Sqrt(array_Board.GetLength(0)) + cubeC; j++)
                        {
                            if (counterR != i || (counterR == i && counterC != j))
                            {
                                currentlist = currentlist.Except(array_Board[i, j].getList()).ToList(); // remove the repeated value from the other lists with the list we are checking so we will remain only with constant


                            }
                        }
                    }
                    if (currentlist.Count != 0) // if the distinct value list is not empty it means this item has to be constant because all the other slots in that cube cant be this value
                    {
                        //updating the board
                        array_Board[counterR, counterC].setValue((char)(currentlist.Sum() + '0'));
                        array_Board[counterR, counterC].setConst(true);
                       
                    }
                   
               
                counterC++; // moving to the next slot in the cube
                if (counterC % (int)Math.Sqrt(array_Board.GetLength(0)) == 0)
                {
                    counterC = cubeC;
                    counterR++;
                }               
              
            }

            
        }
        public bool checkoptions(int row ,int col)
        {

            //array_Board[row, col].restartList();
            bool[] arr = new bool[array_Board.GetLength(0)];
            for (int w = 0; w < array_Board.GetLength(0); w++) 
            {
                arr[w] = true;// initializing an array with true values
            }
            for (int k = 0; k < array_Board.GetLength(0); k++) // running from 0-size of side of the soduko(3 for 4*4 , 8 for 9*9) and so on
			{
			 
			
                for (int z = 0; z < array_Board.GetLength(0); z++) // for each value in the row sent index checking if the value of k+1 is showing so we can erase it from the options list of that board element
                {
                    if (array_Board[z, col].getValue() - '0' == k + 1&&(array_Board[z, col].getConst()||z<row)) // checks if the number is already in the row of index we sent if it's not const we dont consider any number that after the indexes we have because it will be changed accordingly in a moment
                    {
                        if (!array_Board[z,col].getConst()) 
                        {
                            if (z <= row)
                            {
                                arr[k] = false; // change the value in the k th index to false cause this number wont be on the options list
                            }
                        }
                        else
                        {

                            arr[k] = false;
                        }
                    }
                    if (array_Board[row, z].getValue() - '0' == k + 1 && (array_Board[row, z].getConst() || z < col)) // checking if the number is already in the col of index we sent without considering everything that is not const and after the indexes we sent
                    {
                        if (!array_Board[row, z].getConst())
                        {
                            if (z <= col)
                            {
                                arr[k] = false;
                            }
                        }
                        else
                        {

                            arr[k] = false;
                        }
                    }
                       
                }
                int newrow = roundDownRow(row); // getting to row of the start of the cube, for example if the board is 9*9 and we got row 4 so it will go to 3
                int newcol = roundDownCol(col) ;// getting to col of the start of the cube, for example if the board is 9*9 and we got col 4 so it will go to 3
                for (int i = newrow; i < (int)Math.Sqrt(array_Board.GetLength(0)) + newrow; i++) // these two loops will check if the k+1 value is in the cube we are in(for 9*9 board we will check cube of 3*3)
                {
                    for (int j = newcol; j < (int)Math.Sqrt(array_Board.GetLength(0)) + newcol; j++)
                    {
                        if (array_Board[i, j].getValue() - '0' == k + 1 && (i != row || j != col) && ((array_Board[i, j].getConst())||((i == row && j < col) || i < row)))
                        {
                            if (!array_Board[i, j].getConst())
                            {
                                if ((i < row) || (i == row && j < col))
                                {
                                    arr[k] = false;
                                }
                            }
                            else
                            {
                                arr[k] = false;
                            }

                        }
                    }
                }
            }
            bool isoption = false; // if there isnt an option return false
            for (int  u= 0;  u< array_Board.GetLength(0); u++) // this loop will insert the options available for the slots to the options list
            {
                if (arr[u] == true) // if it remained true which means it is not in the row col and cube of the indexes we got than insert the value in the options list
                {
                    array_Board[row, col].addList(u + 1); 
                    isoption = true;
                }

            }
            return isoption;
                    
        }
        public bool solution()
        {          
            Stopwatch stopWatch = new Stopwatch(); // starting take time because if the solution function will get stuck we want to try and solve it from the bottom to the top
            stopWatch.Start();            
            bool check;
            for (int i = 0; i < array_Board.GetLength(0); i++) // two loops that runs on every slot in the matrix
            {

                for (int j = 0; j < array_Board.GetLength(0); j++)
                {
                    TimeSpan ts = stopWatch.Elapsed;
                    
                    if (ts.Seconds > 2 && array_Board.GetLength(0) == 9) // if the algorithm took more than 2 seconds we will try from the bottom 
                    {
                        Console.WriteLine("could'nt solve from the top to the bottom, now trying from the bottom to the top");
                        return true;
                        
                    }
                    if (!array_Board[i, j].getConst()) // if the current slot had value from the start(from the input) we will never change it 
                    {
                        
                        check = checkoptions(i, j);  // checking all the optional values for array_board[i,j] and inserting them to its list of options                      
                        if (check == false) // if there are no available options to put value then we will go back to the most recent value we changed and try other option of it so we can now see if the current slot as an optional value 
                        {                           
                            // // back progagate 
                  
                            int n = 0;
                            while (n == 0) // while there are no other options for the recent slots we changed continue going backwards until we will encounter a value that has more options and change it
                            {
                                if (stack_Row.Count() == 0) // if the stack of recent indexes that we changed is empty it means we cant change anything and the soduko is unsolveable
                                {
                                    Console.WriteLine("unsolveable");
                                    return false;
                                } // else we wil pop the recent indexes of the value we changed
                                i = stack_Row.Pop();
                                j = stack_Col.Pop();
                                n = array_Board[i, j].getFirstOption(); // n gets 0 if there is no other option for this slot and then we will continue going backwards
                            }
                            array_Board[i, j].setValue((char)(n + '0')); // updating the value of the current slot to the first option in its list
                            stack_Row.Push(i); // pushing the indexes of the value we changed so we can come back later and modify if neeeded
                            stack_Col.Push(j);             
                        }
                        else // if checks isnt false and there are options for the current slot then insert it, print the board and continue
                        {
                            array_Board[i, j].setValue((char)(array_Board[i, j].getFirstOption() + '0')); // the current slot value will be the first option of the current board element options list
                            stack_Row.Push(i); // pushing the indexes of the value we changed
                            stack_Col.Push(j);
                            
                        }
                     
                    }
                }               
            }
            PrintBoard();
            return true;
        }           
    

     public bool solutionBackwards() // does the solution from the bottom of the board upwards
        {
            bool check;
            for (int i = array_Board.GetLength(0)-1; i >= 0; i--) // two loops that runs on every slot in the matrix
            {
                for (int j = array_Board.GetLength(0)-1; j >=0; j--)
                {

                    if (!array_Board[i, j].getConst()) // if the current slot had value from the start(from the input) we will never change it 
                    {
                        
                        check = checkoptionsbackwards(i, j);  // checking all the optional values for array_board[i,j] and inserting them to its list of options                      
                        if (check == false) // if there are no available options to put value then we will go back to the most recent value we changed and try other option of it so we can now see if the current slot as an optional value 
                        {                           
                            // // back progagate 
                  
                            int n = 0;
                            while (n == 0) // while there are no other options for the recent slots we changed continue going backwards until we will encounter a value that has more options and change it
                            {
                                if (stack_Row.Count() == 0) // if the stack of recent indexes that we changed is empty it means we cant change anything and the soduko is unsolveable
                                {
                                    Console.WriteLine("unsolveable");
                                    return false;
                                } // else we wil pop the recent indexes of the value we changed
                                i = stack_Row.Pop();
                                j = stack_Col.Pop();
                                n = array_Board[i, j].getFirstOption(); // n gets 0 if there is no other option for this slot and then we will continue going backwards
                            }
                            array_Board[i, j].setValue((char)(n + '0')); // updating the value of the current slot to the first option in its list
                            stack_Row.Push(i); // pushing the indexes of the value we changed so we can come back later and modify if neeeded
                            stack_Col.Push(j);             
                        }
                        else // if checks isnt false and there are options for the current slot then insert it, print the board and continue
                        {
                            array_Board[i, j].setValue((char)(array_Board[i, j].getFirstOption() + '0')); // the current slot value will be the first option of the current board element options list
                            stack_Row.Push(i); // pushing the indexes of the value we changed
                            stack_Col.Push(j);
                          
                        }
                     
                    }
                }               
            }
            PrintBoard();
            return true;
        }

     public bool checkoptionsbackwards(int row, int col)
     {

         //array_Board[row, col].restartList();
         bool[] arr = new bool[array_Board.GetLength(0)];
         for (int w = 0; w < array_Board.GetLength(0); w++)
         {
             arr[w] = true;// initializing an array with true values
         }
         for (int k = 0; k < array_Board.GetLength(0); k++) // running from 0-size of side of the soduko(3 for 4*4 , 8 for 9*9) and so on
         {
             for (int z = 0; z < array_Board.GetLength(0); z++) // for each value in the row sent index checking if the value of k+1 is showing so we can erase it from the options list of that board element
             {
                 if (array_Board[z, col].getValue() - '0' == k + 1 && (array_Board[z, col].getConst() || z > row)) // checks if the number is already in the row of index we sent if it's not const we dont consider any number that after the indexes we have because it will be changed accordingly in a moment
                 {
                     if (!array_Board[z, col].getConst())
                     {
                         if (z >= row)
                         {
                             arr[k] = false; // change the value in the k th index to false cause this number wont be on the options list
                         }
                     }
                     else
                     {

                         arr[k] = false;
                     }
                 }
                 if (array_Board[row, z].getValue() - '0' == k + 1 && (array_Board[row, z].getConst() || z > col)) // checking if the number is already in the col of index we sent without considering everything that is not const and after the indexes we sent
                 {
                     if (!array_Board[row, z].getConst())
                     {
                         if (z >= col)
                         {
                             arr[k] = false;
                         }
                     }
                     else
                     {

                         arr[k] = false;
                     }
                 }

             }
             int newrow = roundDownRow(row); // getting to row of the start of the cube, for example if the board is 9*9 and we got row 4 so it will go to 3
             int newcol = roundDownCol(col);// getting to col of the start of the cube, for example if the board is 9*9 and we got col 4 so it will go to 3
             for (int i = newrow; i < (int)Math.Sqrt(array_Board.GetLength(0)) + newrow; i++) // these two loops will check if the k+1 value is in the cube we are in(for 9*9 board we will check cube of 3*3)
             {
                 for (int j = newcol; j < (int)Math.Sqrt(array_Board.GetLength(0)) + newcol; j++)
                 {
                     if (array_Board[i, j].getValue() - '0' == k + 1 && (i != row || j != col) && ((array_Board[i, j].getConst()) || ((i == row && j > col) || i > row)))
                     {
                         if (!array_Board[i, j].getConst())
                         {
                             if ((i > row) || (i == row && j > col))
                             {
                                 arr[k] = false;
                             }
                         }
                         else
                         {
                             arr[k] = false;
                         }

                     }
                 }
             }
         }
         bool isoption = false; // if there isnt an option return false
         for (int u = 0; u < array_Board.GetLength(0); u++) // this loop will insert the options available for the slots to the options list
         {
             if (arr[u] == true) // if it remained true which means it is not in the row col and cube of the indexes we got than insert the value in the options list
             {
                 array_Board[row, col].addList(u + 1);
                 isoption = true;
             }

         }
         return isoption;

     }



     public String returnString()
     {
         String output = "";
         for (int i = 0; i < array_Board.GetLength(0); i++)
         {
             for (int j = 0; j < array_Board.GetLength(0); j++)
             {
                 output += (char)(array_Board[i,j].getValue());
             }
         }
         return output;
     }
            
   }
}
