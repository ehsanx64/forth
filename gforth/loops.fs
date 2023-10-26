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

\ Calculate the uth power of n1
: ^ ( n1 u -- n )
    1 swap 0 u+do
        over *
    loop
    nip ;

\ Calculate factorial
: fac ( u -- u! )
    1 swap 1+ 1 u+do
        i *
    loop ;

: up2 ( n1 n2 -- )
    +do
        i .
    2 +loop ;

: down2 ( n1 n2 -- )
    -do
        i .
    2 -loop ;

\ endless

7 log2 . cr
8 log2 . cr

7 log2b . cr
8 log2b . cr

3 2 ^ . cr
4 3 ^ . cr

5 fac . cr
7 fac . cr

10 2 up2 cr

0 10 down2 cr
