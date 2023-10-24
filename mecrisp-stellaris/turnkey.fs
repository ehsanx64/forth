\ Set code location to flash
compiletoflash

\ Print a string forever
: forever-loop ( -- )
    begin
        ." This MCU is running a TURNKEY application" cr
    again
;

\ Init is executed on boot-up, so it will execute our forever-loop
: INIT ( -- )
    forever-loop
;

\ Set RAM as default code location again
compiletoram

