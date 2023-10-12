\ Tasks example 
\ Needs TASKS and tools/rgb.forth

-tasks.forth
marker: -tasks.forth

\ Color task
0 task: color-task
mild dup 
init-variable: color
init-variable: old-color
TRUE init-variable: color-task?

\ Timer task
0 task: timer-task
variable: timer#
FALSE constant: log?

\ Color routine
: color-handler ( task -- )
    activate
    begin
        \ Compare color and old-color if they are not equal update the led and old-color
        color @ dup old-color swap over @ <> if over >rgb ! else 2drop then

        \ Following flag controls if color-task should continue or not
        color-task? @ FALSE = if deactivate exit then
        pause
    again
    deactivate
    ;

\ Timer routine
: timer-handler ( task -- )
    activate
    begin
        \ Run every 1000 ms
        ms@ dup timer# @ 1000 + > if
            \ If log? is on print some info
            log? if dup print: "Timer: " . cr then
            \ Save uptime to timer#
            dup timer# !
        then
        drop
        pause
    again
    deactivate
    ;

multi
color-task color-handler
timer-task timer-handler

