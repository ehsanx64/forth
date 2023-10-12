\ Basic HTTP Client Example
\ Needs NETCON
-http-basic.forth
marker: -http-basic.forth

stack-clear

\ Variable to hold the socket handle
variable: socket

\ Buffer to read data from socket into
512 buffer: line

\ This will hold the parsed (extracted) response 
32 buffer: result
FALSE init-variable: grab

\ Read from the netcon handle
: fetch ( netcon -- )
    \ Clear the result
    result 32 bounds do 0 i c! loop

    cr
    println: "Response (header):"
    begin
        dup 512 line netcon-readln -1 <>
    while
        grab @ if 
            line result over strlen cmove FALSE grab ! 
        then

        line "\r\n" =str if 
            TRUE grab ! 
        else 
            \ Display the line buffer if it's not the same as the result
            line dup result =str invert if type cr else drop then 
        then
    repeat
    drop ;

\ Return a string of minimum headers
: ss ( -- addr )
    "GET /iot/index.php HTTP/1.1\\r\\nUser-Agent: punyforth\\r\\nHost: 192.168.1.108\\r\\nAccept: text/html,text/text,*/*\\r\\n" 
    ;

: main
    cr cr println: "Request:" 
    ss type 

    80 "192.168.1.108" TCP netcon-connect socket !

    socket @
    dup ss netcon-writeln
    dup fetch
    netcon-dispose

    \ Print the result
    cr println: "Response (body): " result type cr
;

main


