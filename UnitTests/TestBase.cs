using System . Diagnostics;
using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace CodilitySolutions {
    [TestClass]
    public abstract class TestBase {
        #region Properties
        public TestContext TestContext { get; set; }

        public string Class {
            get { return this . TestContext . FullyQualifiedTestClassName; }
        }
        public string Method {
            get { return this . TestContext . TestName; }
        }
        #endregion

        #region Methods
        protected virtual void Trace ( string message ) {
            Debug . WriteLine ( message );
        }
        #endregion
    }
}
