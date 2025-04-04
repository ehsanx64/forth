create buff 128 char allot

: input ( addr n -- )
    type buff 1+ 126 accept buff c! ;


: main
    s" Please enter your name: " input
    cr ." Hey there " buff count type ." !!!" cr ;

main bye
