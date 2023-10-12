\ UDP Server Example
\ Needs NETCON and lib/led

-udp-server.forth
marker: -udp-server.forth

wifi-ip constant: HOST
8000 constant: PORT
1 buffer: command
0 task: server-task

PORT HOST netcon-udp-server constant: server

\ Print a timestamp
: timestamp ( -- )
    ms@ . print: ": " ;

\ Toggle the onboard LED
: toggle-led ( -- ) 
    LED gpio-read if +led else -led then ;

\ The command loop
: command-loop ( task -- )
    activate
    begin
        server 1 command netcon-read -1 <>
    while
        command c@ case
            $F of timestamp println: "LED OFF" -led endof
            $O of timestamp println: "LED ON" +led endof
            $L of timestamp toggle-led println: "LED Toggle" endof
        endcase
    repeat
    deactivate ;

\ Start the command server
: server-start ( -- )
    multi server-task command-loop ;

server-start


