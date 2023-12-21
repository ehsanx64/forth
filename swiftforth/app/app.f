\ We assume important parameters and options have been defined in
\ a forth source file, so at initialization we would check if the
\ source file (config file) does exist and include (load) it, and
\ we continue the bootstrap process by executing words defined in
\ the config file.

\ Our config file
s" config.f" 2constant config-file

\ Controls debugging/logging output
false constant -v

\ If verbose mode is active dump the stack
: -v? ( -- )
    -v if .s then ;

\ Display <error> if verbose flag is active
: log" ( <error> -- )
    [char] " parse postpone sliteral 
    -v if postpone type postpone cr else postpone 2drop then
    ; immediate

\ Try to check for and include the config file
: load-config ( -- )
    config-file 2dup file-exists 
    if included
    else -v? abort" Config file not found! Exiting ..."
    then
    ;

\ If the word given as counted string exists execute it
: run? ( addr u -- )
    \ On active verbosity flag display some info
    -v if 2dup ." Look-up for (" type ." ) ..." then

    \ Construct the code to check for word existence (defined <word>)
    pad 100 erase s" defined " pad place pad append

    \ If word have been found execute it
    pad count evaluate if 
        log" Found! Executing ..." execute
    else 
        log" Not found!" drop \ discard xt
    then 
    ; 


\ Pass <name> to run? for check/execution
: run?" ( <name> -- )
    [char] " parse postpone sliteral postpone run? 
    ; immediate

\ Application
: main ( -- )
    load-config
    run?" on-start"
    run?" in-the-middle"
    run?" on-end"
    ." Done!"
    bye
    ;

main
