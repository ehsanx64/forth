\ HTTP Client to submit temperature/humidity using GET request
\ Needs lib/tools.forth

-net.forth
marker: -net.forth

stack-clear

\ Socket handle
variable: socket

\ Buffer to read from the socket into
512 buffer: line 

\ Headers buffer
256 constant: hbuf%
hbuf% buffer: hbuf

\ Parameter (temp) buffer
128 buffer: tbuf

\ Response content
32 buffer: result
TRUE constant: execute-result?

\ Flag used to parse (extract) response body
FALSE init-variable: grab

: local-ip$ ( -- addr ) 
    wifi-ip ;

: remote-ip$ ( -- addr ) 
    "192.168.1.108" ;

: th-api ( -- server url )
    remote-ip$ "/iot/index.php" ;

: netfetch ( netcon -- )
    \ Clear the result buffer
    result 32 bounds do 0 i c! loop cr

    begin 
        dup 512 line netcon-readln -1 <> 
    while 
        line dup type strlen 
        dup 3 > if print: " (len => " . $) emit else drop then
        cr

        \ If grab is set we should be inside the body of the response so save it
        grab @ if
            line result line strlen cmove
            FALSE grab !

            \ Check if there is a word named as the result
            result dup strlen find dup if 
                \ If yes and the result execution flag is set execute it
                execute-result? if link>xt execute >rgb else drop then
            else
                drop
            then
        then

        \ This is a good indicator that next line is first line of body part so
        \ enable the grab flag
        line "\r\n" =str if TRUE grab ! then
    repeat 
    drop ;

: append-headers ( addr -- )
    "User-Agent: punyforth\\r\\n" over $+
    "Accept: text/html,text/text,*/*\\r\\n" over $+
    "Connection: keep-alive\\r\\n" swap $+ ;

\ Given a query string (url) generate a request string at addr
: prepare-get ( url -- addr )
    hbuf dup >r hbuf% erase 
    \ GET url HTTP/1 ...
    "GET " r@ $= r@ $+ " HTTP/1.1\\r\\n" r@ $+
    "Host: " r@ $+ remote-ip$ r@ $+ "\\r\\n" r@ $+ 
    r@ append-headers r> ;

: http-get ( server url -- )
    \ Open a socket to the remote server and save the handle
    swap 80 swap TCP netcon-connect dup socket !

    \ Prepare a get request from the url and write it to the socket and read the
    \ result back
    swap prepare-get over swap netcon-writeln dup netfetch netcon-dispose ;

\ Temperature-Humidity (TH)
: send-th ( str-temp str-humidity -- server url )
    tbuf dup >r 128 erase th-api r@ $= "?temp=" r@ $+ rot r@ $+
    "&humidity=" r@ $+ swap r@ $+ r> ;

\ Send static values (for testing)
: send ( -- )
    "38" "99" send-th http-get memstat ;

\ Send static values in loop
: th-loop ( count delay -- )
    swap 1 do 
        "25.2" "32" send-th 16r001000 >rgb http-get mild >rgb memstat dup ms 
    loop 
    drop ;

memstat

\ Uncomment to run 
\ 5 1000 th-loop
\ send

