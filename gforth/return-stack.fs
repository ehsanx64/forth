\ Return Stack

: foo ( n1 n2 -- )
    .s cr
    >r .s cr
    r@ .
    >r .s cr
    r@ .
    r> .
    r@ .
    r> . ;

1 2 foo
cr


: my-2swap ( x1 x2 x3 x4 -- x3 x4 x1 x2 )
    rot >r rot r> ;

1 2 3 4 my-2swap .s cr

\ Following word causes imbalance in return stack
: crash ( n -- )
    >r ;

5 crash
