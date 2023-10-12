#! /usr/bin/env gforth

\ Print the command arguments (from official gforth docs)
: echo ( -- )
    begin next-arg 2dup 0 0 d<> 
    while type space
    repeat
    2drop ;

\ Iterate over command arguments looking for a specific string (edit)
: check-args ( -- )
    begin next-arg 2dup 0 0 d<>
    while 
        2dup s" edit" compare 0= if 
            2drop ." edit command" cr 
        else
            type space
        then
    repeat
    2drop cr
    ;

\ Check argc
: check-argc ( -- )
    argc @ case
        1 of ." No argument" cr endof
        2 of ." 1 argument" cr endof
        ." More than 1 arguments" cr
    endcase
    ;

check-args

." Done! " .s cr bye


