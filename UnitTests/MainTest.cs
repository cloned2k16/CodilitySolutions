using System;
using CodilitySolutions;
using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace CodilitySolutions {
    [TestClass]
    public class MainTest {
        [TestMethod]
        public void TestMain ( ) {
            Main main = new Main ();
                                    

            Assert . AreNotEqual    ( null      , main );

            Assert . AreEqual       ( 0         , main . main );

        }
    }
}
