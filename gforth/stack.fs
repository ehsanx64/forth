\ Stack display and manipulation words

\ Push two values then dump the stack, clearstack clears the stack
1 2 .s cr clearstack

\ Stack is a LIFO so the numbers will be printed in reverse order
1 2 3 . . . cr

\ Duplicate the TOS
\ dup ( a -- a a )
1 dup .s cr clearstack

\ Drop the TOS
\ drop ( a -- )
1 1 drop .s cr clearstack

\ over ( a b -- a b a )
1 2 over .s cr clearstack

\ swap ( a b -- b a )
1 2 swap .s cr clearstack

\ Rotate top three items to left
\ rot ( a b c -- b c a )
1 2 3 rot .s cr clearstack

\ Rotate top three items to right (inverse of rot, it is the same as rot rot )
\ -rot ( a b c -- c a b )
1 2 3 -rot .s cr clearstack

\ 2swap ( a b c d -- c d a b )
1 2 3 4 2swap .s cr clearstack

\ Performs swap drop
\ nip ( a b -- b )
1 2 nip .s cr clearstack

\ tuck ( a b -- b a b )
1 2 tuck .s cr clearstack


