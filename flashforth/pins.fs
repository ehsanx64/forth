\ AVR PORT-B
37 constant PORTB	\ Port B Data Register
\ $25 constant PORTB	\ Is a valid definition using hexadecimal system

36 constant DDRB	\ Port B Data Direction Register
35 constant PINB	\ Port B Input Pins

\ To isolate a bit in a register a mask is used:
%00000001 ( or $01 )	\ Bit 0
%00000010 ( or $02 )	\ Bit 1
%00000100 ( or $04 )	\ Bit 2
%00001000 ( or $08 )	\ Bit 3
%00010000 ( or $10 )	\ Bit 4
%00100000 ( or $20 )	\ Bit 5
%01000000 ( or $40 )	\ Bit 6
%10000000 ( or $80 )	\ Bit 7

\ Pin 13 on Arduino can be defined in FlashForth by:
: pin13 ( -- mask addr )
  32 ( or or %00100000 ) PORTB ;

\ Set Pin 13 as OUTPUT since it is INPUT by default
: pin13->output ( -- )
  \ Original version which is bad in my opinion was following
  \ pin13 1- mset

  \ My version which I think is more clear
  pin13 DDRB mset ;


  

