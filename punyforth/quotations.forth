-quotations.fs
marker: -quotations.fs

0 init-variable: q

\ Display the stack
: .s ( -- )
    print: "Stack:" stack-print cr ;

\ Save the quotation for square
: q-square ( -- )
    { dup * } q ! ;

\ Save the quotation for cube
: q-cube ( -- )
    { dup dup * * } q ! ;

: main
    cr println: "Running quotations.forth ..." stack-clear

    \ Define a quotation for a function such that: f(x) => x * 2
    { 2 * print: "Result: " . cr } 

    \ Execute the quotation for two arguments (5 and 10)
    5 over execute 10 swap execute

    \ Using dip to temporarily hide TOS, execute the quotation and restore the TOS
    \ Stack would be=> 12 4
    10 2 4 { + } dip .s 2drop

    \ Modify the xt variable (q) but pass the same argument to it
    q-square 5 q @ execute print: "Double: " . cr
    q-cube 5 q @ execute print: "Cube: " . cr
    ;

main

