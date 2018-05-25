
using System;
using Microsoft . VisualStudio . TestTools . UnitTesting;
using System . Diagnostics;

using CodilitySolutions;


namespace CodilitySolutions
        . BinaryGap                                                 {
//  ----------------------- --------------------------------------- ----------------------------------------------------
    class                   TestValues                              
        :                   TestValuesBase                          {
        public int A,R;

        public              TestValues                              ( int a ,int r ) {
            A=a;
            R=r;
        }

        protected override 
        bool                TestRes                                 (params object [] args) {
            try {
                int res= (int) args[0];
                Assert . AreEqual (res , R );
                return true;    
            }
            catch (Exception e){ Console.Error.WriteLine("Exception: {0}",e); }
            return false;
        }

    }
//  ----------------------- --------------------------------------- ----------------------------------------------------
    [TestClass]
    public class            BinaryGapTest 
        :                   TestBase                                {

        [TestMethod]
        public void TestBinaryGap ( ) {
            Solution sol= new Solution();

            Assert . AreNotEqual ( null , sol );

            TestValuesBase [] testValues ={ new TestValues( 0x1041        , 5 )
                                        ,   new TestValues( 0x5555A5      , 2 )
                                        ,   new TestValues( 0b101000000   , 1 )
                                        ,   new TestValues( 0b1001000000  , 2 )
                                        ,   new TestValues( 0b1000100000  , 3 )
                                        ,   new TestValues( 0b1000100001  , 4 )
                                        ,   new TestValues( 0b1001000001  , 5 )
                                        ,   new TestValues( 0b1010000001  , 6 )
                                        };

            doTests(sol,testValues);

            // -----------------------------------------------------------------
            //  benchmark ...
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
