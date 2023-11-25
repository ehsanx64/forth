\ General-purpose Tools (words)

variable map:i
0 map:i !

\ Feed numbers on the stack to an exection token.
\ ary specifies the number of items on the stack that the execution token is
\ going to consume. For example for the world '.' it is 1, for the word '+' 2
\ and so on
: map-ary ( xt ary -- a )
    { xt ary } depth map:i @ - ary 1- do xt execute loop ;

\ Feed numbers on the stack to a execution token that consumes one item on the
\ stack
: map1 ( xt -- a )
    1 map-ary ;

depth map:i !
1 2 3 4 5 6 7 8 9 ' . map1 .s cr
1 2 3 4 5 6 7 8 9 ' + 2 map-ary .s cr 
bye
