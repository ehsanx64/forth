#! /usr/bin/env gforth

\ Define a variable and save some value
variable my-var
255 my-var !

\ Define a new word for testing purposes
: app
    ." Hello!!!" cr 
    ." my-var value is: " my-var ? cr ;

\ Clear the screen, run the app routine and quit the system
page app bye
