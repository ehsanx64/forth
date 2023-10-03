\ Define an anonymous word
:noname ( n -- xt )
    0 ?do cr rtc-show 1000 ms loop cr ;

5 over execute      \ Call it with 5 as argument
10 over execute     \ Pass 10 instead
