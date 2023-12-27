1000 constant buff%
create buff buff% chars allot
create buff2 buff% chars allot

: template ( -- addr u )
    s" Hi %! Bye%!" ;

: find-mark ( addr u -- n )
    0 ?do 
        i over + c@ [char] % = if drop i unloop exit then
    loop
    drop -1
    ;

\ Replace % in addr-u1 (template) with addr-u2 (string)  return the result buffer
: interpolate ( addr-u1 addr-u2 -- addr-u )
    \ Clear the buffer and set its length to zero
    buff buff% erase 0 buff c!

    \ Bring addr-u1 (template) to the top
    2swap

    \ If sentinel does not exist abort
    2dup find-mark dup -1 = if drop false leave then

    \ Move sentinel index to rstack
    >r

    \ Copy from the beginning of source string to sentinel (char) index to buffer
    over buff 1+ r@ cmove

    \ Update buffer string count
    r@ buff c!

    \ Bring the string pair to top
    2swap
    
    \ Copy the string to the end of the buffer
    >r buff dup c@ + 1+ r@ cmove

    \ Update the buffer string count
    buff c@ r> + buff c!

    \ Copy the rest of the template to the buffer
    r@ rot + 1+ swap

    \ Get the end of string in buffer 
    buff dup c@ + 1+ 

    \ Copy the rest of template
    swap >r r@ cmove

    \ Update the buffer string count
    buff c@ r> + buff c!

    \ Discard the sentinel index from return and data stacks
    r> drop

    \ Push the output
    buff count
    ;

: main ( -- )
    \ 1st substitution
    template s" dear User! How are you doing today?" interpolate 
    2dup type cr

    \ Clear the buff2 and copy the result there
    buff2 buff% erase buff2 place

    \ 2nd substitution
    buff2 count s"  %" interpolate
    2dup type cr
    buff2 buff% erase buff2 place

    \ 3rd substitution
    buff2 count s" dear!" interpolate
    2dup type cr
    ;

main
bye

