\ General-purpose Tools (Needs nothing except core punyforth words)

: k* ( n -- ) 1000 * ;
: m* ( n -- ) 1000 1000 * * ;
: K* ( n -- ) 1024 * ;
: M* ( n -- ) 1024 1024 * * ;

\ Display memory stats
: memstat ( -- )
    print: "Used: " usedmem . cr print: "Free: " freemem . cr ;

\ Convert minutes to milliseconds
: mins ( n -- ) 60 * 1000 * ; 

\ convert milliseconds (n) to hour min sec
: utime ( n -- s m h)
    1000 / 60 /mod 60 /mod ;

\ Print the uptime
: uptime ( -- )
    print: "Uptime: " ms@ utime . $: emit . $: emit . cr ;

\ Erase n bytes from addr
: erase ( addr n -- )
    bounds do 0 i c! loop ;

: count ( addr -- addr u )
    dup strlen ;

\ Write dest over src
: $= ( src dest -- )
    over strlen cmove ;

\ Append src to dest
: $+ ( src dest -- )
    dup strlen + over strlen cmove ;

\ Dump n bytes from addr
: dump ( addr n -- )
    bounds cr do i c@ . 32 emit loop cr ;

\ Display the flag status
: flag? ( f -- )
    if println: "True" else println: "False" then ;
 
: find-mark ( addr -- n )
    count 0 ?do
        dup i + c@ $% = if drop i unloop exit then
    loop
    drop -1 ;

1000 constant: buff%
create: mix:buff buff% allot

\ Replace % in template with pattern, return the result buffer
: interpolate ( template pattern -- addr )
    \ Clear the buffer and set its length to zero
    mix:buff buff% erase 0 mix:buff c!

    \ Bring template to the top
    swap

    \ If sentinel does not exist abort
    dup find-mark dup -1 = if drop FALSE exit then

    \ Move sentinel index to rstack
    >r

    \ Copy from the beginning of template to sentinel (char) index to buffer
    dup mix:buff 1+ r@ cmove

    \ Update buffer string count
    r@ mix:buff c!
    
    \ Bring the pattern to top
    swap
    
    \ Copy the pattern to the end of the buffer
    count >r mix:buff dup c@ + 1+ r@ cmove

    \ Update the buffer string count
    mix:buff c@ r> + mix:buff c!

    \ Copy the rest of the template to the buffer
    r> over + 1+ dup

    \ Get the end of string in buffer 
    mix:buff dup c@ + 1+ 

    \ Copy the rest of template
    over strlen cmove

    drop mix:buff 1+
    ;

/end
