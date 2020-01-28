using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace TestProject1
{
    [TestClass]
    public class validityTest
    {
        [TestMethod]
        public void TwoInTheSameQube4()
        {
            //arrange
            string inputF = "1023100000000000"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.IsPossibleInputQube(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }

        [TestMethod]
        public void TwoInTheSameQube9()
        {
            //arrange
            string inputF = "090107000910000045003200000300000060062000300005000009000602000000000000049000057"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.IsPossibleInputQube(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }

        [TestMethod]
        public void TwoInTheSameQube16()
        {
            //arrange
            string inputF = "10023400<06000701080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.IsPossibleInputQube(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }


        [TestMethod]
        public void TwoInTheSameRow4()
        {
            //arrange
            string inputF = "1123000000000000"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.isPossibleInput(inputF);

            // assert
            Assert.AreEqual(expected,ispossibleinput) ;


        }
        
        [TestMethod]
        public void TwoInTheSameRow9()
        {
            //arrange
            string inputF = "000000000000112300000000000000000000000000000000000000000000000000000000000000000"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.isPossibleInput(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }
        [TestMethod]
        public void TwoInTheSameRow16()
        {
            //arrange
            string inputF = "0000000000001123000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.isPossibleInput(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }
        [TestMethod]
        public void TwoInTheSameCol16()
        {
            //arrange
            string inputF = "1000000000000000100000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.isPossibleInput(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }
        [TestMethod]
        public void TwoInTheSameCol4()
        {
            //arrange
            string inputF = "1000100010000000"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.isPossibleInput(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }
        [TestMethod]
        public void TwoInTheSameCol9()
        {
            //arrange
            string inputF = "100000000100000000100000000000000000000000000000000000000000000000000000000000000"; // there are two 1 in the same row from the input, should return false
            bool ispossibleinput, expected = false;

            //act
            ispossibleinput = Validity.isPossibleInput(inputF);

            // assert
            Assert.AreEqual(expected, ispossibleinput);


        }
        

        [TestMethod]
        public void TooLongInput4()
        {
            //arrange
            string inputF = "00103000003000000";
            string inputT = "0010300003000002";
            bool isInLengthF, isInLengthT, expectedF = false, expectedT = true;

            //act
            isInLengthF = Validity.IsValid(inputF);
            isInLengthT = Validity.IsValid(inputT);
            //assert
            Assert.AreEqual(expectedF, isInLengthF);
            Assert.AreEqual(expectedT, isInLengthT);
        }

        [TestMethod]
        public void TooLongInput9()
        {
            //arrange
            string inputF = "5168497323076050008097000651350609074725910069683700502531860746842075007910506022";
            string inputT = "000013000000680002006000000200470005400008000005060030000305026003000801000000400";
            bool isInLengthF, isInLengthT, expectedF = false, expectedT = true;

            //act
            isInLengthF = Validity.IsValid(inputF);
            isInLengthT = Validity.IsValid(inputT);
            //assert
            Assert.AreEqual(expectedF, isInLengthF);
            Assert.AreEqual(expectedT, isInLengthT);
        }

        [TestMethod]
        public void TooLongInput16()
        {
            //arrange
            string inputF = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<1";
            string inputT = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
            bool isInLengthF, isInLengthT, expectedF = false, expectedT = true;

            //act
            isInLengthF = Validity.IsValid(inputF);
            isInLengthT = Validity.IsValid(inputT);
            //assert
            Assert.AreEqual(expectedF, isInLengthF);
            Assert.AreEqual(expectedT, isInLengthT);
        }


        [TestMethod]
        public void TooShortInput4()
        {
            //arrange
            string inputF = "001030000300000";
            string inputT = "0010300003000002";
            bool isInLengthF,isInLengthT, expectedF = false , expectedT = true;

            //act
            isInLengthF = Validity.IsValid(inputF);
            isInLengthT = Validity.IsValid(inputT);
            //assert
            Assert.AreEqual(expectedF, isInLengthF);
            Assert.AreEqual(expectedT, isInLengthT);
        
        }

        [TestMethod]
        public void TooShortInput9()
        {
            //arrange
            string inputF = "5168497323076050008097000651350609074725910069683700502531860746842075007910506";
            string inputT = "000013000000680002006000000200470005400008000005060030000305026003000801000000400";
            bool isInLengthF, isInLengthT, expectedF = false, expectedT = true;

            //act
            isInLengthF = Validity.IsValid(inputF);
            isInLengthT = Validity.IsValid(inputT);
            //assert
            Assert.AreEqual(expectedF, isInLengthF);
            Assert.AreEqual(expectedT, isInLengthT);

        }

        [TestMethod]
        public void TooShortInput16()
        {
            //arrange
            string inputF = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500";
            string inputT = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
            bool isInLengthF, isInLengthT, expectedF = false, expectedT = true;

            //act
            isInLengthF = Validity.IsValid(inputF);
            isInLengthT = Validity.IsValid(inputT);
            //assert
            Assert.AreEqual(expectedF, isInLengthF);
            Assert.AreEqual(expectedT, isInLengthT);

        }
        [TestMethod]
        public void IsValidChars4()
        {
            //arrange
            string inputF = "12341234h1231234";
            string inputT = "0010300003000002";
            bool isCorrectCharsF,isCorrectCharsT, expectedF = false , expectedT = true;

            //act
            isCorrectCharsF = Validity.IsValidInput(inputF);
            isCorrectCharsT = Validity.IsValidInput(inputT);

            //assert
            Assert.AreEqual(isCorrectCharsF, expectedF);
            Assert.AreEqual(isCorrectCharsT, expectedT); 

        }

        [TestMethod]
        public void IsValidChars9()
        {
            //arrange
            string inputF = "09010700001009004500320000h300000060062000300005000009000602000000000000049000057";
            string inputT = "090107000010090045003200000300000060062000300005000009000602000000000000049000057";
            bool isCorrectCharsF,isCorrectCharsT, expectedF = false , expectedT = true;

            //act
            isCorrectCharsF = Validity.IsValidInput(inputF);
            isCorrectCharsT = Validity.IsValidInput(inputT);

            //assert
            Assert.AreEqual(isCorrectCharsF, expectedF);
            Assert.AreEqual(isCorrectCharsT, expectedT); 

        }

        [TestMethod]
        public void IsValidChars16()
        {
            //arrange
            string inputF = "10023400<06000700080007003k09:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
            string inputT = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
            bool isCorrectCharsF, isCorrectCharsT, expectedF = false, expectedT = true;

            //act
            isCorrectCharsF = Validity.IsValidInput(inputF);
            isCorrectCharsT = Validity.IsValidInput(inputT);

            //assert
            Assert.AreEqual(isCorrectCharsF, expectedF);
            Assert.AreEqual(isCorrectCharsT, expectedT);

        }


       
    }
}
