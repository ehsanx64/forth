\ RGB LED Stuff (Needs GPIO)

\ Prepare the pin (Wemos D1 Mini WS2812 RGB Shield)
4 constant: RGB
RGB GPIO_OUT gpio-mode

\ Define some color constants
16r020001 constant: mild
16r0f0000 constant: green
16r00000f constant: blue
\ TODO: Define more preset colors

\ Tools
: >rgb ( color -- ) RGB 2dup ws2812rgb 20 ms ws2812rgb ;

\ Application
: rgb-demo ( count -- )
    3 0 do
        mild >rgb 200 ms green >rgb 200 ms blue >rgb 200 ms
    loop ;

rgb-demo


