#! /usr/bin/env gforth

\ A simple program that demonstrate how to use pipes in order to read stdout
\ of another program in gforth. In this example we are trying to read a value
\ from Redis using the redis-cli tool.

\ A variable to hold the handler
variable the-pipe

\ Buffer to read from pipe into
32 constant BUFF_SIZE
create buff BUFF_SIZE chars allot

\ Shortcut word
: bb ( -- addr n )
    buff BUFF_SIZE ;

\ TODO: Implement this ...
: >redis ( addr u -- addr u )
    ;

: main 
    \ Open a pipe (read-only) and save the handle for later
    s" redis-cli get name" r/o open-pipe throw the-pipe !

    \ Clear the bufer
    bb erase

    \ Read up to 127 characters from the pipe
    buff 1+ BUFF_SIZE 1- the-pipe @ read-line throw

    \ If read was successful we should save the bytes read at first buffer byte
    if buff c! then  

    \ Gracefully close the pipe
    the-pipe @ close-pipe

    \ Print what we got
    ." The name: " buff count type cr

    \ Dump the buffer
    bb dump
    ;

." ######################################################################" cr
main
bye
