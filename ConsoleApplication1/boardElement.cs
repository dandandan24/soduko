using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class boardElement
    {
        private char value;
        private List<int> options;
        private bool isconst;


        public boardElement()
        {
            this.value = '0';
            this.options = new List<int>();
            isconst = false;
        }
        public bool getConst() // returns if the current index in the matrix is constnant(given from the input)
        {
            return this.isconst;
        }
        public void setConst(bool okay) // setting the constant value  
        {
            this.isconst = okay;            
        }
        public char getValue() // return the char of the current slot of the matrix
        {
            return this.value;
        }

        public void setValue(char c) // setting the value
        {
            this.value = c;
        }
        public void addList(int c) // adding to the list of options
        {
            if (!this.isconst)
            {
                this.options.Add(c);
            }
        }
        public List<int> getList()
        {
            return this.options;
        }
        public int getFirstOption() // returning the lowest value available for the slot
        {
            if (this.options.Any())
            {
                int First = this.options[0];
                this.options.Remove(First);
                return First;
            }
            return 0;
        }
        public void resetList()
        {
            this.options.Clear();
        }
 
    }
}
