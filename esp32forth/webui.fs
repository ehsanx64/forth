\ Running esp32forth web UI

: start-webui
	z" ssid" z" psk" webui ;

\ Uncomment following to start the web UI on start-up
startup: start-webui

