\ General-purpose Tools (words)

variable map:i
0 map:i !

\ Save current stack depth for later
: map-mark ( -- ) 
    depth map:i ! ;

\ Feed numbers on the stack to an exection token.
\ ary specifies the number of items on the stack that the execution token is
\ going to consume. For example for the world '.' it is 1, for the word '+' 2
\ and so on
: map-ary ( xt ary -- a )
    { xt ary } depth map:i @ - ary 1- do xt execute loop ;

\ Feed numbers on the stack to a execution token that consumes one item on the
\ stack
: map-ary1 ( xt -- a )
    1 map-ary ;


\ Test map-* words
: map-tests ( -- )
    map-mark
    ." # Print items on the stack:" cr
    1 2 3 4 5 6 7 8 9 ['] .
    ." Before: " .s cr
    ." After:  " map-ary1 .s cr 

    \ Make sure stack is empty
    clearstack

    map-mark
    cr ." # Sum of items on stack:" cr
    1 2 3 4 5 6 7 8 9 ['] + 2 
    ." Before: " .s cr
    ." After:  " map-ary .s cr 
    bye
;

: main ( -- )
    map-tests 
    ;

main

( TODOs


)
