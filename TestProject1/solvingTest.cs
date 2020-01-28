using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace TestProject1
{
    [TestClass]
    public class solvingTest
    {
        [TestMethod]
        public void UnSolveAbleTest4()
        {
            //arrange
            string inputF4 = "0002100002000020"; // unsolveable board 4*4
            string inputT4 = "0010300003000002"; // solveable board 4*4
            board bF4 = new board(inputF4);
            board bT4 = new board(inputT4);
            bool isSolveT4, isSolveF4, expectedF = false, expectedT = true;

            //act

            isSolveF4 = bF4.solution();
            isSolveT4 = bT4.solution();

            //assert
            Assert.AreEqual(isSolveF4, expectedF);
            Assert.AreEqual(isSolveT4, expectedT);
        }

        [TestMethod]

        public void UnSolveAbleTest9()
        {
            //arrange

            string inputF9 = "516849732307605000809700065135060907472591006968370050253186074684207500791050608"; // unsolveable board 9*9
            string inputT9 = "090107000010000045003200000300000060062000300005000009000602000000000000049000057"; // solveable board 9*9
            board bF9 = new board(inputF9);
            board bT9 = new board(inputT9);
            bool isSolveT9, isSolveF9, expectedF = false, expectedT = true;

            //act

            isSolveF9 = bF9.solution();
            isSolveT9 = bT9.solution();

            //assert           
            Assert.AreEqual(isSolveF9, expectedF);
            Assert.AreEqual(isSolveT9, expectedT);
        }

        //[TestMethod]
        /*    public void UnSolveAbleTest16()
            {
                //arrange
                string inputF16 = "19023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
                string inputT16 = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
                board bF16 = new board(inputF16);
                board bT16 = new board(inputT16);
                bool isSolveT16, isSolveF16, expectedF = false, expectedT = true;

                //act

                isSolveF16 = bF16.solution();
                isSolveT16 = bT16.solution();

                //assert
                Assert.AreEqual(isSolveF16, expectedF);
                Assert.AreEqual(isSolveT16, expectedT);
            }*/

        [TestMethod]
        public void NeedToGoBackwards9() // the solvebackwards will help only on 9*9 because there isnt enough options that will make 4*4 board to be solved in more than 2 seconds and 16*16 boards wont effect too much from it so it will help only for 9*9
        {
            //arrange
            string input9F = "400000805030000000000700000000000060000080400000010000000603070500000000000000000"; // this input wont be solveable in 2 seconds so the func will return false for regular solution but will be solveable for backwards solution
           
            bool isSolveT9, isSolveF9, expectedT = true;
            board b = new board(input9F);
            //act
            isSolveF9 = b.solution();
            isSolveT9 = b.solutionBackwards();

            //assert
            Assert.AreEqual(isSolveF9, expectedT);
            Assert.AreEqual(isSolveT9, expectedT);
        }
        // will check if the algorithm can handle an 4*4 empty board
        [TestMethod]
        public void onlyzeros4()
        {
            //arrange
            string input4T = "0000000000000000";

            bool isSolveT4,expectedT = true;
            board b = new board(input4T);
            //act
            isSolveT4 = b.solution();

            //assert
           
            Assert.AreEqual(isSolveT4, expectedT);
        }
        // will check if the algorithm can handle an 9*9 empty board
        [TestMethod]
        public void onlyzeros9()
        {
            //arrange
            string input9T = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            bool isSolveT9, expectedT = true;
            board b = new board(input9T);
            //act
            isSolveT9 = b.solution();

            //assert

            Assert.AreEqual(isSolveT9, expectedT);
        }
        // will check if the algorithm can handle an 16*16 empty board
        [TestMethod]
        public void onlyzeros16()
        {
            //arrange
            string input16T = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            bool isSolveT16, expectedT = true;
            board b = new board(input16T);
            //act
            isSolveT16 = b.solution();

            //assert

            Assert.AreEqual(isSolveT16, expectedT);
        }
    }
}
