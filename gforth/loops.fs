\ Loops

\ The endless loop must be terminated using Ctrl-C
: endless ( -- )
    0 begin
        dup . 1+
    again ; 

\ logarithmus dualis of n1>0, rounded down to the next integer
: log2 ( +n1 -- n2 )
    assert( dup 0> )
    2/ 0 begin
        over 0> 
    while
        1+ swap 2/ swap 
    repeat
    nip ;

\ logarithmus dualis of n1>0, rounded down to the next integer
: log2b ( +n1 -- n2 )
    assert( dup 0> )
    -1 begin
        1+ swap 2/ swap
        over 0 <=
    until
    nip ;

\ endless

7 log2 . cr
8 log2 . cr

7 log2b . cr
8 log2b . cr

