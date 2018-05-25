
using System;
using System . Diagnostics;
using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace CodilitySolutions 
        . Ladder                                                    {
//  ----------------------- --------------------------------------- ----------------------------------------------------
    public class            TestValues                              {
        public int []  A,B,R;

        public TestValues ( int [ ] A , int [] B , int [ ] R ) {
            this . A=A;
            this . B=B;
            this . R=R;
        }

        public bool TestRes(int [] res) {
            CollectionAssert . AreEqual (res , R );
            return true;    
        }
    }
//  ----------------------- --------------------------------------- ----------------------------------------------------
    [TestClass]
    public class            LadderTest
        :                   TestBase                                {

        [TestMethod]
        public void TestLadder ( ) {

            Solution sol= new Solution();

            Assert . AreNotEqual ( null , sol );

            TestValues []   testValues=   {
                                new TestValues (new int [] { 4 , 4 , 5 , 5 , 1 } 
                                              , new int [] { 3 , 2 , 4 , 3 , 1 } 
                                              , new int [] { 5 , 1 , 8 , 0 , 1 } 
                                              )};

            doTests(sol,testValues);

        }
    }
}
