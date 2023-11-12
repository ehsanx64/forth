\ Memory

\ Define a global variable named v
variable v

\ v pushes the address of the variable on the stack
." Address of v: " v . cr

\ Set a value
5 v !   

\ Fetch and display variable's value
." Value of v: " v @ . cr  

\ Raw dump of memory is possible using the word dump
." Dump of v: " cr
v 1 cells .s dump

\ A range of memory bytes can be allocted on the dictionary using the create word

\ Allocate 20 cells, each cell is 8 bytes on 64-bit architectures so 20*4 bytes
\ will be allocated
create v2 20 cells allot    
v2 20 cells erase

." Dump of v2:" 
v2 20 cells dump

." Setting 3 at third cell and -1 at fifth cell ..." 
3 v2 2 cells + !
-1 v2 4 cells + !

." Dump of v2:" 
v2 20 cells dump

