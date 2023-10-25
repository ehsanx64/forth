\ Arithmetics in gforth

2 2 + . cr 

2 1 - . cr

7 3 mod . cr

\ The modulo operator, returns the remainder of division of 7 by 3
7 3 mod . cr

\ Change sign of a number
2 negate . cr

\ Perform both division and modulo stack would be: 1 2 and dots will print 2 1
7 3 /mod . . 
