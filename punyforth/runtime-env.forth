\ A simple program to figure out if a specific word is defined at runtime and
\ execute it

( TODO:

- [ ] Add example that feed forth code as a string to the punyforth REPL

)

-runtime-env.forth
marker: -runtime-env.forth

"hello" constant: the-word

\ Clear the data stack
: clear-stack ( -- )
    depth 0 ?do drop loop ;

\ Check if the word is defined if 
: word-defined? ( -- )
    cr print: "Checking for the word '" the-word type print: "' ..." cr

    \ If the word is not defined show a message and exit
    the-word dup strlen find dup 0= if println: "Not found" drop exit then

    \ If the word is found let the user know, get its execution token (xt) and
    \ execute it
    println: "Found! Executing ..." 
    link>xt execute
    ;

\ Main application
clear-stack freemem . cr word-defined?


