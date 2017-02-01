
using System;
using Microsoft . VisualStudio . TestTools . UnitTesting;
using System . Diagnostics;

using CodilitySolutions;


namespace CodilitySolutions.BinaryGap {

    [TestClass]
    public class                        BinaryGapTest 
        :                               TestBase                    {

        [TestMethod]
        public void TestBinaryGap ( ) {
            Solution sol= new Solution();

            Assert . AreNotEqual ( null , sol );

            int [,] testPairs = {   { 0x1041        , 5 }
                                ,   { 0x5555A5      , 2 }
                                ,   { 0b101000000   , 1 }
                                ,   { 0b1001000000  , 2 }
                                ,   { 0b1000100000  , 3 }
                                ,   { 0b1000100001  , 4 }
                                ,   { 0b1001000001  , 5 }
                                ,   { 0b1010000001  , 6 }
                                };

            int numTests = testPairs.Length / 2;

            Assert . AreEqual ( 8 , numTests );

            for ( uint n = 0 ; n< numTests ; n++ ) {
                int  N=testPairs[n,0]
                ,    R=testPairs[n,1]
                ;
                try {

                    Assert . AreEqual ( R , sol . solution ( N ) );
                }
                catch ( Exception e ) {
                    throw new AssertFailedException ( "failed test: "+( n+1 )+" :: "+e . Message );
                }
            }

            Stopwatch sw= new Stopwatch();

            sw . Start ( );
            for ( int n = 0 ; n< 0x10000 ; n++ ) {
                sol . solution ( n );
            }
            sw . Stop ( );

            Debug . WriteLine ( "time:    {0}" , sw . Elapsed );
            Debug . WriteLine ( "name:    {0}" , new object [ ] { TestContext . ToString ( ) } );           // we need to pass it as object array ,otherwise it would mess it up !!
            TestContext . WriteLine ( "elapsed: {0}"        , sw . Elapsed );                               // this looks like goes nowhere!
            

        }
    }
}
