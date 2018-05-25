using System;
using System.Reflection;
using System . Diagnostics;
using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace CodilitySolutions {
    [TestClass]
    public abstract class               TestBase {
        protected int                   numTests;

        #region Properties

        public TestContext              TestContext                 {   get; set; }

        public string                   Class                       {   get { return this . TestContext . FullyQualifiedTestClassName;  }   }

        public string                   Method                      {   get { return this . TestContext . TestName; }                       }

        #endregion

        #region Methods
        protected virtual void          Trace                       ( string fmt, params object[] args)                 {
            Debug . WriteLine ( fmt,args ); 
        }
        #endregion

        protected bool                  doTests                     (object solution, object [] testValues)             {
            object       R =    null;
            bool         ok=    false;

            numTests = testValues.Length;

            if (numTests <=0 ) return true;

            Type            solutionClass   =   solution.GetType();
            MethodInfo      mthd            =   solutionClass.GetMethod("solution");
            Type            testClass       =   testValues[0].GetType();
            FieldInfo    [] testFields      =   testClass.GetFields(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo [] propertyInfos   =   testClass.GetProperties();
            int             numFields       =   testFields.Length;

            Trace("class is:    {0}",solutionClass);
            Trace("method is:   {0}",mthd);
            Trace("test class:  {0}",testClass);
            Trace("test fields: {0}",string.Join(",",(object[])testFields));
             
            //try {

              for ( int n = 0 ; n< numTests ; n++ ) {
                object tVal=testValues[n];
                object [] args = new object[testFields.Length-1]; // skip result
                int p=0;
                for (int i=0; i<numFields ;i++) {
                  string name=testFields[i].Name;
                    object field=null;

                    field=testClass.InvokeMember(   name
                                                    ,   BindingFlags.DeclaredOnly 
                                                    |   BindingFlags.Public 
                                                    |   BindingFlags.NonPublic 
                                                    |   BindingFlags.Instance 
                                                    |   BindingFlags.GetField
                                                    , null
                                                    , tVal
                                                    , null);

                      if (name=="R")    R=field;
                      else              args[p++]=field;
                                                    
                }
                
                object res= solutionClass.InvokeMember(     "solution"
                                                        ,   BindingFlags.DeclaredOnly
                                                        |   BindingFlags.Public
                                                        |   BindingFlags.Instance
                                                        |   BindingFlags.InvokeMethod
                                                        ,   null
                                                        ,   solution
                                                        ,   args);
                    
                ok = (bool)testClass.InvokeMember("TestRes"
                                                    ,   BindingFlags.DeclaredOnly
                                                    |   BindingFlags.Public
                                                    |   BindingFlags.NonPublic 
                                                    |   BindingFlags.Instance
                                                    |   BindingFlags.InvokeMethod
                                                    ,   null
                                                    ,   tVal
                                                    ,   new object[] { R });
              }
            //}
            //catch (Exception e) { Trace("exception {0}",e); }

            return ok;
        }
    }
}
