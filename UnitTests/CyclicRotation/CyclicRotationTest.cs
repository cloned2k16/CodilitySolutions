using System;
using Microsoft . VisualStudio . TestTools . UnitTesting;


namespace CodilitySolutions 
        . CyclicRotation                                            {
//  ----------------------- --------------------------------------- ----------------------------------------------------
    class                   TestValues {
        public int []  A,R;
        public int     ror;

        public TestValues(int [] A,int ror, int [] R ) {
            this . A=A;
            this . ror=ror;
            this . R=R;
        }

        public bool TestRes(int [] res) {
            CollectionAssert . AreEqual (res , R );
            return true;    
        }

    }
//  ----------------------- --------------------------------------- ----------------------------------------------------
    [TestClass]
    public class            CyclicRotationTest 
        :                   TestBase                                {

        [TestMethod]
        public void TestCyclicRotation ( ) {
            Solution sol= new Solution();

            Assert . AreNotEqual ( null , sol );

            TestValues []   testValues=   {
                                new TestValues (new int[]{ 3 , 8 , 9 , 7 , 6 } , 3 ,new int[]{ 9, 7, 6, 3, 8})
                            ,   new TestValues (new int[]{ 3 , 8 , 9 , 7 , 6 } , 2 ,new int[]{ 7, 6, 3, 8, 9})
                            };


             doTests(sol,testValues);

        }
    }
}