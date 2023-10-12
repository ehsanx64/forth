#! /usr/bin/env gforth

\ Example of structure usage in gforth

list%
    cell% field int-val
end-struct mylist%

mylist% %alloc constant ml

\ Shortcut for the mylist size
mylist% %size constant ss 

ss . cr

\ Allocate memory on the heap for 5 structs
ss 5 * allocate throw constant items
items ss 5 * erase

: ..dump items ss 5 * dump ;
: q bye ;

\ Access (write a value in) the structure
: ..access1 ( -- )
    items int-val 255 swap ! ;

\ Access the structure - This is a better method
: ..access2 ( -- )
    items ss 1 * + int-val 128 swap ! ;

\ Fill int-val of all 5 structs with the given value n, using do-loop and bounds
: ..fill1 ( n -- )
    items ss 5 * bounds do dup i int-val ! ss +loop ;

\ Fill int-val for all items, using indexing over each structure
: ..fill ( n -- )
    5 0 do
        dup items ss i * + int-val !
    loop
    ;

..access1 ..dump
..access2 ..dump
128 ..fill1 ..dump
255 ..fill ..dump
q

