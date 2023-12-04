\ Array in forth

\ Define a word to define an array of cells
: array ( n "name" -- )
    create cells allot does> ( n -- n ) swap cells + ;

6 constant a%

\ Define an array named 'a' with size of 10 cells
a% array a

\ Dump the array
: .dump ( -- )
    0 a a% 2 + cells dump  ;

\ Fill the array cells with some values
: .fill ( -- )
    a% 0 do i dup 1+ 1000 1000 * * swap a ! loop ;

\ List the array values
: .list ( -- )
    a% 0 do i dup . ." : " a @ dup . ." ( " hex . decimal ." )" cr loop ;

\ Erase the array
: .erase ( -- )
    0 a a% cells erase ;
    
\ Application
.dump .fill .dump cr .list
." Stack: " .s cr


