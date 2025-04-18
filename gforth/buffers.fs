\ Buffer definition and related operations
[defined] -buffers.fs [if] -buffers.fs [then]
marker -buffers.fs

\ create our buffer
create buff 32 chars allot

\ a shortcut for it
: b buff 32 ;

\ what's there?
b dump 

\ erase and verify
b erase b dump

\ put some text there and verify
s" Buffer contents!!!" buff place b dump

\ funny and dummy
:noname do i c@ emit 50 ms loop ; dup
cr s" Contents -> " bounds rot execute buff count bounds rot execute cr

." That's it!" cr bye
