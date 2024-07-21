include unix/socket.fs

create buff 20000 allot
: bb buff 20000 ;
bb erase
s" localhost" 80 open-socket
dup s\" GET /api/myip HTTP/1.0\r\n\r\n" rot write-socket
dup bb read-socket  type
close-socket
bye
