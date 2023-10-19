\ Best method to achieve auto-start is using the /spiffs/autoexec.fs
\ file which loads the boot screen (screen 2 e.g.) 

\ Use GPIO15 (Pin 15) as autostart flag
15 constant cpin
cpin input pinmode

\ If cpin is low (grounded) do not load the screen 3 (boot code)
: loader ( -- )
	\ Screen 2 contains the code to be autostarted
	cpin adc if 2 load then		\ load must be called inside a word
;

\ Screen 2 could be something like below
also telnetd
: start-telnet
	\ Connect to wifi network
	z" ssid" z" psk" login

	\ Set mDNS entry
	z" esp32forth" mdns.begin cr
	
	\ Start telnet server at port 552
	552 server ;

\ Autostart above
s" 2 load " s" /spiffs/autoexec.fs" dump-file bye


\ If a flag pin is not used in order to get out of boot with fatal errors
\ cycle following code should be added to esp32forth souce and recompile/
\ upload the binary again to remove the autoexec file and recompile/upload
\ once more remove the following code after one execution
rm /spiffs/autoexec.fs


