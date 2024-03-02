\ Example of the SR-04 sonar module usage in punyforth
\ Needs PING

-sr4.fs
marker: -sr4.fs

13 constant: PIN_TRIGGER \ D7
12 constant: PIN_ECHO    \ D6
15 constant: PIN_INDIC   \ D8 - RED LED connected via a 220ohm resistor
100 constant: MAX_CM
40 constant: MIN_CM

PIN_INDIC GPIO_OUT gpio-mode
: +indic PIN_INDIC GPIO_HIGH gpio-write ;
: -indic PIN_INDIC GPIO_LOW gpio-write ;
-indic

: distance ( -- cm | MAX_CM )
    { PIN_ECHO MAX_CM cm>timeout PIN_TRIGGER ping pulse>cm }
    catch dup ENOPULSE = if
        drop MAX_CM
    else
        throw
    then 
    ;

: obstacle? ( -- bool ) distance MIN_CM < ;

: main ( -- )
    begin do
        obstacle? if 
            +indic 
        else 
            -indic
        then
        25 ms
    repeat
    -indic 
    ;

main

/end
