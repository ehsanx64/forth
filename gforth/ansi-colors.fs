\ Library for colored-output on terminal using ANSI color codes
\ Run with: gforth ansi-colors.fs
: esc ( -- ) 
    27 emit ;

: fg:black ( -- )
    esc .\" [30m" ;

: fg:br-black ( -- )
    esc .\" [90m" ;

: fg:red ( -- )
    esc .\" [31m" ;

: fg:br-red ( -- )
    esc .\" [91m" ;

: fg:green ( -- )
    esc .\" [32m" ;

: fg:br-green ( -- )
    esc .\" [92m" ;

: fg:yellow ( -- )
    esc .\" [33m" ;

: fg:br-yellow ( -- )
    esc .\" [93m" ;

: fg:blue ( -- )
    esc .\" [34m" ;

: fg:br-blue ( -- )
    esc .\" [94m" ;

: fg:magenta ( -- )
    esc .\" [35m" ;

: fg:br-magenta ( -- )
    esc .\" [95m" ;

: fg:cyan ( -- )
    esc .\" [36m" ;

: fg:br-cyan ( -- )
    esc .\" [96m" ;

: fg:white ( -- )
    esc .\" [37m" ;

: fg:br-white ( -- )
    esc .\" [97m" ;

: bg:black ( -- )
    esc .\" [40m" ;

: bg:br-black ( -- )
    esc .\" [100m" ;

: bg:red ( -- )
    esc .\" [41m" ;

: bg:br-red ( -- )
    esc .\" [101m" ;

: bg:green ( -- )
    esc .\" [42m" ;

: bg:br-green ( -- )
    esc .\" [102m" ;

: bg:yellow ( -- )
    esc .\" [43m" ;

: bg:br-yellow ( -- )
    esc .\" [103m" ;

: bg:blue ( -- )
    esc .\" [44m" ;

: bg:br-blue ( -- )
    esc .\" [104m" ;

: bg:magenta ( -- )
    esc .\" [45m" ;

: bg:br-magenta ( -- )
    esc .\" [105m" ;

: bg:cyan ( -- )
    esc .\" [46m" ;

: bg:br-cyan ( -- )
    esc .\" [106m" ;

: bg:white ( -- )
    esc .\" [47m" ;

: bg:br-white ( -- )
    esc .\" [107m" ;

: ansi:reset ( -- )
    esc .\" [0m" ;

: ansi:bold ( -- )
    esc .\" [1m" ;

: ansi:dim ( -- )
    esc .\" [2m" ;

: ansi:italic ( -- )
    esc .\" [3m" ;

: ansi:underline ( -- )
    esc .\" [4m" ;

: ansi:blink ( -- )
    esc .\" [5m" ;

: ansi:reverse ( -- )
    esc .\" [7m" ;

: ansi:hidden ( -- )
    esc .\" [8m" ;

: ansi:strike-through ( -- )
    esc .\" [9m" ;

: eol ( -- )
    ansi:reset cr ;

: say-hi ( -- )
    ." Hi!!!" eol ;


: test1 ( -- )
    ." Initial format: " say-hi 
    ." In red: " fg:red say-hi
    ." In green: " fg:green say-hi 
    ." In yellow: " fg:yellow say-hi 
    ." In blue: " fg:blue say-hi 
    ." In magenta: " fg:magenta say-hi 
    ." In cyan: " fg:cyan say-hi 
    bg:red fg:white say-hi 
    bg:red fg:blue say-hi 
    ansi:bold bg:green fg:white say-hi 
    ansi:blink ansi:bold bg:black fg:br-red say-hi
    ;

: app
    test1
    ;

app
bye
