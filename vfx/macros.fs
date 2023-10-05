\ Define a buffer
create buff 100 chars allot

\ Shorthand
: bb buff 100 ;

\ Clear the buffer and expand the template in it
bb erase c" vfxpath: %vfxpath%" buff $expand bb dump

\ Display it
buff count type cr

