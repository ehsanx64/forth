#! /usr/bin/env gforth

\ Emulate a remote controller (to be used in RC projects)

\ TODO
\ - UDP client code

\ This key (command) is used to exit the loop (program)
27 constant ESC

\ Main four directions
'w constant FORWARD
's constant BACKWARD
'a constant LEFT
'd constant RIGHT

: cmd-forward ( -- )
    ." Forward" cr ;

: cmd-backward ( -- ) 
    ." Backward" cr ;

: cmd-left ( -- ) 
    ." Left" cr ;

: cmd-right ( -- ) 
    ." Right" cr ;

: cmd-exit ( -- )
    ." ESC! Exiting ..." cr ;

: cmd-default ( char -- )
    emit ." >" cr .s cr ;

: main ( -- )
    \ Inform user how to quit :-))
    cr ." Press ESC to exit" cr

    \ Indefinitely loop, the exit command/condition is somewhere in between
    begin
        \ Check if there is a key to read
        key? if 
            \ Check and handle the key
            key case 
            FORWARD of cmd-forward endof
            BACKWARD of cmd-backward endof
            LEFT of cmd-left endof
            RIGHT of cmd-right endof
            ESC of cmd-exit exit endof
            dup cmd-default
            endcase
        then
    again 
    ;

main bye
