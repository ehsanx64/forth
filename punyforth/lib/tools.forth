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
