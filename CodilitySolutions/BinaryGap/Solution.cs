
namespace CodilitySolutions . BinaryGap {

    public class Solution {
                                                                            //  the name violation and int type are actually required by Codility!
        public int solution ( int N ) {                                     //  this was aprox. 25% faster than looping the other way around
            uint    mask    =  0x80000000                                   //  with the latest optimization it reach %38 increase in performances
            ;
            int     gap     =   0
            ,       currGap =  -1
            ;

            if ( 0== ( N & 0xFFFF0000 ) ) N<<=16;                           // drastically reduce loops by just adding this two lines
            if ( 0== ( N & 0xFF000000 ) ) N<<= 8;                           

            for ( uint i = 0 ; i < 32 ; i++ ) {                             // loop through all bits because it is safer
                                                                            // than a while loop ..
                if ( 0 == ( N & mask ) ) {
                    currGap= ( currGap>=0 ) ? currGap+1 : currGap;          // 0 and already hit 1
                }
                else {
                    gap= ( currGap > gap ) ? currGap : gap;                 // if current gap > gap use it
                    currGap = 0;                                            // reset currGap
                }
                if ( 0 == ( N & mask-1 ) ) break;                           // we are done! (drastically reduce loops by checking LSB)
                mask>>=1;
            }
            return gap;
        }
    };
};


