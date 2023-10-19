also telnetd

: start-telnet
	\ Connect to wifi network
	z" ssid" z" psk" login

	\ Set mDNS entry
	z" esp32forth" mdns.begin cr
	
	\ Start telnet server at port 552
	552 server ;

\ Uncomment following line to run the start-telnet routine on start-up
\ startup: start-telnet

