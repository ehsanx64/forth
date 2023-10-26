\ Recursion

: fac1 ( n -- n! )
    recursive
    dup 0> if
        dup 1- fac1 *
    else
        drop 1
    endif ;

: fac2 ( n -- n! )
    dup 0> if
        dup 1- recurse *
    else
        drop 1
    endif ;

7 fac1 . cr
7 fac2 . cr
