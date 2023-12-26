\ LED (Needs GPIO)

\ This is the onboard LED
2 constant: LED

\ Set the pin as output
LED GPIO_OUT gpio-mode

\ Turn off the onboard LED
: -led ( -- ) LED GPIO_HIGH gpio-write ;

\ Turn on the onboard LED
: +led LED GPIO_LOW gpio-write ;

\ Toggle the onboard LED
: toggle-led ( -- )
    LED gpio-read if +led else -led then ;

\ Turn off a LED
: off ( pin -- ) GPIO_HIGH gpio-write ;

\ Turn on a LED
: on ( pin -- ) GPIO_LOW gpio-write ;

/end
