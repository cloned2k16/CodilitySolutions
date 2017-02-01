
namespace CodilitySolutions . Ladder {


    public class Solution {
        private static int    []  fib     = new int   [32768];
        private static int    []  empty   = new int   [] {};

        static Solution ( ) {                                                                            // static constructor builds a Fibonacci cache
            fib [ 0 ]=0;
            fib [ 1 ]=1;
            for ( int i = 2 ; i<fib . Length ; i++ ) {
                fib [ i ] = (int) ( ( (long) fib [ i-2 ]+fib [ i-1 ] ) % ( (long) 1<<31 ) );            //  we just need to calculate this once!
            }
        }

        public int [ ] solution ( int [ ] A , int [ ] B ) {
            if ( null == A || null == B ) return empty;                                                 //  better safe than sorry

            int len = A.Length;

            if ( len != B . Length ) return empty;                                                      //  it make no sense!

            int [] res = new int [len];                                                                 //  we store results here

            for ( int i = 0 ; i < len ; i++ ) res [ i ] = fib [ A [ i ]+1 ] % ( 1 << B [ i ] );         //  build sequence using fibonacci cache

            return res;

        }
    }
}
    

