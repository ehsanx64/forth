\ Vocabulary Example
\ Vocabulary mechanism in Forth can be used to implement a module system with
\ basic information-hiding.
\ Tested and works on gforth and SwiftForth

vocabulary mine
also mine definitions

variable myvar

\ Initialization
: init ( -- )
    255 myvar ! ;

: print ( -- )
    ." myvar: " myvar ? cr ;

previous definitions

\ Usage
\ After loading and/or including this file the variable and words defined are
\ hidden, in order to find them we'd need something like below codes 
also mine       \ enable mine vocabulary for look-ups
init print      \ call the words
previous        \ remove the vocabulary from search order

