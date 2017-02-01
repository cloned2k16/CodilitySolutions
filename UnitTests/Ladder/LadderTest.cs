
using System;
using System . Diagnostics;
using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace CodilitySolutions . Ladder {
    class TestValues {
        public int []  A,B,R;

        public TestValues ( int [ ] A , int [] B , int [ ] R ) {
            this . A=A;
            this . B=B;
            this . R=R;
        }
    }

    [TestClass]
    public class LadderTest
        : TestBase {

        [TestMethod]
        public void TestLadder ( ) {

            Solution sol= new Solution();

            Assert . AreNotEqual ( null , sol );

            TestValues []   testValues=   {
                                new TestValues (new int[]{ 4 , 4 , 5 , 5 , 1 } , new int[] { 3 , 2 , 4 , 3 , 1 } , new int [] { 5 , 1 ,8 , 0 , 1 } )
                            };

            int numTests = testValues.Length;

            Assert . AreEqual ( 1 , numTests );

            for ( int n = 0 ; n< numTests ; n++ ) {
                TestValues v=testValues[n];
                int [] R= sol.solution(v.A,v.B);
                //Debug . WriteLine ( "# {0}" , new object [ ] { string . Join ( "," , R ) } );

                try {
                    CollectionAssert . AreEqual ( v . R , R );
                }
                catch ( Exception e ) {
                    throw new AssertFailedException ( "failed test: "+( n+1 )+" :: "+e . Message );
                }

            }

        }
    }
}
