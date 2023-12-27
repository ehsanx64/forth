-test.forth
marker: -test.forth

1000 constant: buff%
create: buff buff% allot
create: buff2 buff% allot

: erase ( addr n -- )
    bounds do 0 i c! loop ;

: count ( addr -- addr u )
    dup strlen ;

: template ( -- addr )
    "Hello % Welcome %" ;

: find-mark ( addr -- n )
    count 0 ?do
        dup i + c@ $% = if drop i unloop exit then
    loop
    drop -1
    ;


\ Replace % in template with pattern, return the result buffer
: interpolate ( template pattern -- addr )
    \ Clear the buffer and set its length to zero
    buff buff% erase 0 buff c!

    \ Bring template to the top
    swap

    \ If sentinel does not exist abort
    dup find-mark dup -1 = if drop FALSE exit then

    \ Move sentinel index to rstack
    >r

    \ Copy from the beginning of template to sentinel (char) index to buffer
    dup buff 1+ r@ cmove

    \ Update buffer string count
    r@ buff c!
    
    \ Bring the pattern to top
    swap
    
    \ Copy the pattern to the end of the buffer
    count >r buff dup c@ + 1+ r@ cmove

    \ Update the buffer string count
    buff c@ r> + buff c!

    \ Copy the rest of the template to the buffer
    r> over + 1+ dup

    \ Get the end of string in buffer 
    buff dup c@ + 1+ 

    \ Copy the rest of template
    over strlen cmove

    drop buff 1+
    ;

: .log ( value title -- )
    type type cr ;

: >buff2 ( string -- )
    buff2 buff% erase
    count buff2 swap cmove ;

: main ( -- )
    cr template "Template: " .log 

    template "User!" interpolate >buff2 
    buff2 "1st substitution: " .log

    buff2 "..." interpolate
    dup "2nd substitution: " .log

    cr "POST /index.php/%/% HTTP/1.1" >buff2 
    buff2 "New Template: " .log

    buff2 "sns" interpolate >buff2
    dup "sns substitution: " .log

    buff2 "names" interpolate
    "names substitution: " .log
    ;

stack-clear
main
