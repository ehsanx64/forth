\ Set a checkpoint to be able to reset the dictionary later
marker -clean

( HANDY WORDS - Useful in all projects/situations )
ram
: say-hello ( -- ) ." Hello!!!" cr ;
: ? ( u -- ) @ . ;
: -rot ( a b c -- c a b ) rot rot ;
: mdump ( a u -- ) base @ -rot hex dump cr base ! ;


( Use a counter value to light up LEDs PB0-PB5 )
marker -playground
eeprom              \ We want delay# variable to be saved on the EEPROM
variable delay# 
250 delay# ! 
ram                 \ Change memory to ram
$ff ddrb c!         \ Set all port B bits (PB0 - PB5) as output
: pb-off ( -- ) 0 portb c! ;    \ Set all port B bits to low
: pb-on ( -- ) $ff portb c! ;   \ Set all port B bits to high
\ Increment a counter value (n) by 1 and write it into byte location (addr)
: go ( addr n -- addr n+1 ) 1+ over over swap c! ;
: delay ( -- ) delay# @ ms ;    \ Generic delay which uses a variable for timeout
: go-loop portb 1 %11111 for go delay next 2drop ;



