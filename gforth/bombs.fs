\ Words to crash the gforth

\ Soft bombs cause an error/exception but hard bombs could totally crash the gforth

\ Tries to write 0 at an invalid memory address (0)
: soft-bomb1 ( -- )
    0 0 ! ;

\ Tries to execute an invalid memory address (here)
: soft-bomb2 ( -- )
    here execute ;

\ Following words yields the error: Attempt to use zero-length string as a name
: hard-bomb1 ( -- )
    ' catch >body 20 erase abort ;

: hard-bomb2 ( -- )
    ' (quit) >body 20 erase ;

