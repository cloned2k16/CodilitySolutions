using System;
using Microsoft . VisualStudio . TestTools . UnitTesting;


namespace CodilitySolutions . CyclicRotation {
    class TestValues {
        public int []  A,R;
        public int     ror;

        public TestValues(int [] A,int ror, int [] R ) {
            this . A=A;
            this . ror=ror;
            this . R=R;
        }
    }

    [TestClass]
    public class CyclicRotationTest {
        [TestMethod]
        public void TestCyclicRotation ( ) {
            Solution sol= new Solution();

            Assert . AreNotEqual ( null , sol );

            TestValues []   testValues=   {
                                new TestValues (new int[]{ 3 , 8 , 9 , 7 , 6 } , 3 ,new int[]{ 9, 7, 6, 3, 8})
                            ,   new TestValues (new int[]{ 3 , 8 , 9 , 7 , 6 } , 2 ,new int[]{ 7, 6, 3, 8, 9})
                            };

            int numTests = testValues.Length;

            Assert . AreEqual ( 2 , numTests );

            for (int n=0 ; n< numTests ; n++ ) {
                TestValues v=testValues[n];
                int [] R= sol.solution(v.A,v.ror);
                try {
                    CollectionAssert . AreEqual ( v . R , R );
                }
                catch (Exception e ) {
                    throw new AssertFailedException ( "failed test: "+(n+1)+" :: "+e .Message );
                }
            }
        }
    }
}