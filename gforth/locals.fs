\ Locals (local variables)

: swap { a b -- b a }
    b a ;

: swap ( x1 x2 -- x2 x1 )
    { a b } b a ;
