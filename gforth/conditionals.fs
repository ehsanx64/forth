\ Conditionals and branching

: abs ( n1 -- +n2 )
    dup 0 < if      \ If n1 is smaller than 0 negate it otherwise do not touch it
        negate
    then ;

\ Test the 'abs' word
5 abs . cr
-5 abs . cr

1 2 < . cr    \ Check if 1 < 2 and put the flag (true/false) on the stack
2 1 < . cr    \ Check if 2 < 1
1 1 < . cr    \ Check if 1 < 1

\ Instead of then we can define a word to end the if clause
: endif postpone then ; immediate


\ Check the top two items on the stack and return the smaller one
: min ( n1 n2 -- n )
    \ Comparison words consum values on the stack, so we should duplicate values
    2dup < if       
        drop
    else
        nip
    endif ;

2 3 min . cr 
3 2 min . cr






