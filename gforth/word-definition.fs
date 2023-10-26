\ Word definitions

\ Define a word to square the TOS
: squared ( n -- n ^ 2 )
    dup * ;

\ Pass 5 as argument
5 squared . cr

\ Pass 7 as argument
7 squared . cr

\ Define a word to cube the TOS, which uses the square word
: cubed ( n -- n ^ 3 )
    dup squared * ;

-5 cubed . cr

\ Define a word to calculate the fourth power of the TOS
: 4th-power ( n -- n ^ 4 )
    squared squared ;

3 4th-power . cr

\ If the TOS is 3 exit the definition
: exit-if-3 ( n -- )
    dup 3 = if
        ." TOS is 3, exiting ..." cr
        drop exit
    then
    ." This will not be executed if TOS is 3" cr
    ;

4 exit-if-3
3 exit-if-3
