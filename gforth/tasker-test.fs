include tasker.fs

\ This task is a simple increasing counter
variable task:counter-var
: task:counter ( -- )
    begin 
        1 task:counter-var +! 
        pause 
    again ;

\ This task takes the system ticker (uptime) and save it in a variable
variable task:utime-var
: task:utime ( -- )
    begin
        utime throw task:utime-var !
        pause
    again ;

: secs* ( n -- n ) 
    1000 dup * * ;

\ This task:
\   - runs every 1 second
\   - gets the system date command's output and put it in a buffer
\   - counts its own activations
variable task:reader-ticker
variable task:reader-activations
create task:reader-buff 1000 chars allot
: task:reader ( -- )
    utime throw task:reader-ticker !
    begin
        task:reader-ticker @ 1 secs* + utime throw < if
            \ Increase the activations counter
            1 task:reader-activations +!
            
            \ Get system date and put it in the buffer
            task:reader-buff 1000 erase
            s" date" r/o open-pipe throw
            dup task:reader-buff 1+ 999 rot read-line throw
            if task:reader-buff c! then close-pipe

            \ Update the task's ticker
            utime throw task:reader-ticker !
        then
        pause
    again ;

\ Line-buffer stuff
create line-buff 100 chars allot
\ Append the chr to line-buffer and update the buffer count
: +line-buff ( chr -- )
    line-buff dup c@        \ Get buffer count
    over 1+ + rot swap c!   \ Save the chr
    dup c@ 1+ swap c!       \ Update the buffer count
    ;
\ Remove the last character from line-buffer
: line-buff- ( -- )
    line-buff 
    dup c@ 0 = if drop exit then    \ If buffer is already empty skip
    dup c@ over + 0 swap c!         \ Clear the character
    dup c@ 1- swap c! ;             \ Update the buffer count

\ Display variables
: show ( -- )
    ." task:counter-var: " task:counter-var ? cr
    ." task:utime-var: " task:utime-var ? cr 
    ." task:reader-ticker: " task:reader-ticker ? cr
    ." task:reader-activations: " task:reader-activations ? cr
    ." task:reader-buff: " task:reader-buff count type cr
    ." line-buff: " line-buff count type cr
    ." stack: " .s cr
    line-buff 100 dump cr ;

\ Define our tasks
1000 NewTask constant :task:counter
1000 NewTask constant :task:utime
1000 NewTask constant :task:reader

\ Main loop
: main-loop ( -- )
    begin
        page
        0 1 at-xy show 
        0 20 at-xy 80 spaces
        0 20 at-xy ." >>> " line-buff count type 
        key? if
            key dup [char] q = if 
                drop cr ." Exiting ..." cr exit 
            else 
                dup 127 = if 
                    drop line-buff- 
                else
                    +line-buff
                then
            then
        then
        60 ms pause
    again 
    ;

: start-task:counter
    :task:counter activate task:counter ;

: start-task:utime
    :task:utime activate task:utime ;

: start-task:reader ( -- )
    :task:reader activate task:reader
    ;

: main ( -- )
    \ Start the tasks
    start-task:counter
    start-task:utime
    start-task:reader

    \ Run the main loop
    main-loop 

    \ Exit
    bye ;

main
