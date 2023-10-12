\ RC Car
\ This file is based on the following example:
\ https://github.com/zeroflag/punyforth/blob/master/arch/esp8266/forth/examples/example-geekcreit-rctank.forth)

\ The original example use Geekcreit DIY T300 and joystick controller. My chassis 
\ is very primitive and I don't have a joystick at the moment. I plan to use a forth
\ program and use keyboard instead of joystick. The program would use netcat to send
\ specified commands to the UDP server running on the module (see command-loop)

\ To upload I use following commands (using pfshell.fs and pfsf script):
\ 
\ gforth pfshell.fs -e 's" rccar.forth" 160 send bye' > /tmp/script.txt
\ ./pfsf /tmp/script.txt

-rccar.forth
marker: -rccar.forth

GPIO    load
EVENT   load
TCPREPL load
PING    load

\ My microcontroller board is a Wemos D1 Mini (ESP8266) and a L298 H-bridge driver
\ Motor pins
5  constant: PIN_SPEED_1 \ D1
4  constant: PIN_SPEED_2 \ D2
0  constant: PIN_MOTOR_1 \ D3
2  constant: PIN_MOTOR_2 \ D4

\ Sonar module (SR-04)
13 constant: PIN_TRIGGER \ D7
12 constant: PIN_ECHO    \ D6
100 constant: MAX_CM
20  constant: MIN_CM

create: PWM_PINS PIN_SPEED_1 c, PIN_SPEED_2 c,

: engine-start ( -- )
    PIN_MOTOR_1 GPIO_OUT gpio-mode
    PIN_MOTOR_2 GPIO_OUT gpio-mode
    PWM_PINS 2 pwm-init
    1000 pwm-freq
    1023 pwm-duty
    pwm-start ;

: engine-stop ( -- ) pwm-stop ;
: forward ( -- v1 v2 ) GPIO_LOW  GPIO_LOW  ;
: back    ( -- v1 v2 ) GPIO_HIGH GPIO_HIGH ;
: left    ( -- v1 v2 ) GPIO_LOW  GPIO_HIGH ;
: right   ( -- v1 v2 ) GPIO_HIGH GPIO_LOW  ;

: direction ( v1 v2 -- )
    PIN_MOTOR_2 swap gpio-write
    PIN_MOTOR_1 swap gpio-write ;
    
30000 constant: very-slow
40000 constant: slow
50000 constant: medium
60000 constant: fast
65535 constant: full

medium init-variable: current-speed

: speed ( n -- )
    case
        0 of
            pwm-stop
            PIN_SPEED_1 GPIO_LOW gpio-write
            PIN_SPEED_2 GPIO_LOW gpio-write
        endof
        full of
            pwm-stop
            PIN_SPEED_1 GPIO_HIGH gpio-write
            PIN_SPEED_2 GPIO_HIGH gpio-write        
        endof
        pwm-duty
        pwm-start   
    endcase ;

: brake ( -- ) 0 speed ;

: distance ( -- cm | MAX_CM )
    { PIN_ECHO MAX_CM cm>timeout PIN_TRIGGER ping pulse>cm }
    catch dup ENOPULSE = if
        drop MAX_CM
    else
        throw
    then ;

: obstacle? ( -- bool ) distance MIN_CM < ;

: turn ( -- ) 
    right direction current-speed @ speed
    50 ms ;
    
: go ( -- ) 
    forward direction current-speed @ speed
    50 ms ;
    
: auto-pilot ( -- )
    begin
        begin
            obstacle?
        while
            turn
        repeat
        go
    again ;
    
8000 constant: PORT
PORT wifi-ip netcon-udp-server constant: server-socket
1 buffer: command

: command-loop ( task -- )
    activate    
    begin
        server-socket 1 command netcon-read
        -1 <>
    while
        command c@
        case
            $F of forward direction current-speed @ speed endof
            $B of back direction current-speed @ speed endof
            $L of left direction current-speed @ speed endof
            $R of right direction current-speed @ speed endof
            $I of 
               current-speed @ 10 + full min
               current-speed !
               current-speed @ speed
            endof
            $D of 
                current-speed @ 10 - 0 max
                current-speed !
                current-speed @ speed
            endof
            $S of brake endof
            $E of engine-start endof
            $H of engine-stop endof
            $A of auto-pilot endof
        endcase
    repeat 
    deactivate ;
    
0 task: tank-task

: tank-server-start ( -- )
    multi
    auto-pilot
    tank-task command-loop ;

repl-start
tank-server-start

\ end with /end :->
/end
