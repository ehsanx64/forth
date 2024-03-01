\ General punyforth code
\ Needs: Nothing

-general.forth
marker: -general.forth

stack-hide stack-clear cr
print: "Uploading general.forth ..."

\ Useful stuff
32 constant: BL

\ Dump bytes
: dump ( addr count -- )
    cr println: "Bytes:"
    bounds do i c@ . BL emit loop cr ;

\ Dump cells
: dump-cells ( addr count -- )
    cr println: "Cells:"
    bounds do i @ . BL emit 1 cells +loop cr ;

\ Create a buffer with size of 32 chars
40 buffer: buffer
: bb ( -- addr u ) buffer 40 ;

println: " Done! Running ..."
bb dump
bb dump-cells

stack-show /end
