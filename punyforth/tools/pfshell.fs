\ This script can be used to read a punyforth source file and generate a script to
\ upload and save on the flash using punyforth screen editor feature.

\ Usage is as simple as: 
\   # 150 is the target screen index and myfile.forth is the file to be uploaded
\   gforth pfshell.fs -e 's" myfile.forth" 150 send bye' > script.txt
 
\ The result script can be sent to an ESP8266 module using the `pfsf` script.

\ Warning: If the source file line count exceeds 31 the next screen(s) on the module will be overwritten.

create line-buff 256 chars allot
: lb line-buff 256 ;

false constant delayed-echo 

lb erase
0 value fd

\ Print the line buffer to screen
: echo-line ( addr u -- )
    bounds do 
        i c@ dup 0 <> if 
            emit delayed-echo if 10 ms then 
        else 
            drop 
        then 
    loop ;

\ Generate screen script command for the given line number 'n'
: get-script ( n -- ) 
    s>d <# bl hold # # #> type ." r: " lb echo-line cr ;

\ This the entry point
\ addr u 
\   Specifies the punyforth source file to read and generate script for its upload
\ n 
\   The screen number which upload will be started at
: send ( addr u n -- )
    lb erase dup . ." list c" cr cr

    delayed-echo if 
        lb drop 100 dump 1000 ms
    then

    -rot r/o open-file throw to fd

    \ This will be the line index counter
    0
    begin
        \ Erase the line buffer and read a line from fd into it
        lb erase
        lb fd read-line drop nip 

        \ If current line index is greater than the limit (31) increment the
        \ screen counter and reset the line counter
        swap dup 31 > if 
            cr rot 1+ dup . ." list c" cr cr -rot drop 0 
        then

        \ Generate script for current line
        dup get-script 1 + swap

        \ Loop continues as long as 'read-line' returns true
        if false else true then
    until

    ." flush" cr cr

    fd close-file throw
;


