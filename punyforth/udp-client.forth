\ UDP Client Example
\ Needs NETCON

-udp-client.forth
marker: -udp-client.forth

\ The target server details
"192.168.1.101" constant: SERVER_IP
8000 constant: SERVER_PORT

\ Variable to control delay between requests
1000 init-variable: delay

\ Print a timestamp
: timestamp ( -- )
    ms@ . print: ": " ;

\ Open an UDP connection to the server and save the socket handle
SERVER_PORT SERVER_IP UDP netcon-connect constant: CLIENT

\ Must be called in the end to clean-up the socket
: close ( -- ) CLIENT netcon-dispose ;

\ Main routine
: main ( -- )
    cr 
    5 0 do
        timestamp println: "Requesting toggle"
        CLIENT "L" 1 netcon-send-buf
        delay @ ms
    loop ;

\ Call main twice with 2 seconds of delay (blocking) in between
main 2000 ms main

\ Uncomment following to clean up the socket
\ close



