\ General punyforth tips and tricks
-tips.forth
marker: -tips.forth

\ Compile number as string at here, lives the string address on the stack
: itoa, ( -- str )
    \ This will not alter dp so subsequent altercations can destroy the string at 'here'
    here dup 123456 >str type cr

    \ To allocate space on the dictionary for it
    here dup 123456 >str dup strlen allot dup type cr ;

\ Compile a hardcoded integer as a string
itoa, print: "The string: " type cr

