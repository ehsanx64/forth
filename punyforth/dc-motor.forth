\ Driving a DC motor using L298H-bridge on punyforth
\ Needs GPIO
-motor.forth
marker: -motor.forth

\ The motor pin
5 constant: pin

\ Create a byte array of pin(s) 
create: pwms pin c,

\ Initialize and start PWM on configured pins
pwms 1 pwm-init 1000 pwm-freq 1023 pwm-duty pwm-start

: t ( -- ) 
    65535 0 do i pwm-duty 100 ms 1000 +loop ;

: >duty ( n -- ) pwm-duty ;

: stop -1 >duty ;

: mild-run 45000 >duty ;

: max-run 0 >duty ;


stop





