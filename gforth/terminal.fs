#! /bin/env gforth

: fg-red ( -- )
    .\" \033[1;31m" ;
: fg-green ( -- )
    .\" \033[1;32m" ;
: fg-blue ( -- )
    .\" \033[1;34m" ;
: fg-reset ( -- )
    .\" \033[0m" ;

: main ( -- ) 
    cr 0
    fg-red
    begin 
        1 + 
        dup 2 mod 0 = if fg-green else fg-red then
        dup s>d <# # # # #> type ."  " 
        dup 20 mod 0 = if cr then 
        50 ms
        dup 100 = 
    until 
    drop
    ; 

main

\ Print the stack in blue, then reset the colors
fg-blue ." Stack: " .s cr fg-reset cr 
bye

