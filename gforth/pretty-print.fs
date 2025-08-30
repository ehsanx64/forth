\ Display strings in a pretty manner
\ How to run: gforth pretty-print.fs

\ If the marker is defined call it, otherwise create a new one
[defined] -pretty-print.fs [if] -pretty-print.fs [then]
marker -pretty-print.fs

\ Our routines
: delay ( -- )
    30 ms ;

: pretty-print ( addr u -- )
    bounds do i c@ emit delay loop ;

\ Print using an anonymous word
s" Printing using an anonymous word ..." bounds
:noname do i c@ emit delay loop ; execute cr

\ Call our pretty-print word
s" Printing using the pretty-print word ..." pretty-print cr

\ Exit
bye
