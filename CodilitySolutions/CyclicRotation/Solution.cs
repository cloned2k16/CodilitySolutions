
namespace CodilitySolutions . CyclicRotation {
    public class Solution {

        public int [ ] solution ( int [ ] A , int K ) {             // name violation is actually required by the codility framework!
            if ( A==null ) return new int[0];                       // better safe than sorry

            int len     =   A.Length;
            if ( len == 0 ) return A;
            K       =   K % len;                                    // make sure K falls into array
            int ror     =   (len-K) % len;                          // mirror value to rotate right

            if ( ror<=0 ) return A;                                 // nothing to do!

            int
                i
        ,   ii
        ,   tmp
        ,   ofs     = 0
        ,   cnt     = len
            ;

            while ( 0 < cnt ) {
                i   = ofs;
                tmp = A [ i ];                                      // save first
                do {
                    ii = ( i + ror ) % len;                         // point to new value
                    if ( ii==ofs ) break;                           // until not entering loop (on even length input array)
                    A [ i ] = A [ ii ];                             // move to new place
                    i = ii;                                         // swap index
                    --cnt;
                }
                while ( true );                                     // would be better use ( 0 < cnt ) to keep it safe
                A [ i ]=tmp;                                        // store first value
                --cnt;
                ofs++;                                              // jump to next start
            }
            return A;
        }

    }
}
