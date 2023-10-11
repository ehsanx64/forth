\ Punyforth WIFI Features Demo
\ Needs WIFI

-wifi.forth
marker: -wifi.forth

\ PSK stands for pre-shared key (a.k.a the password)
\ ESSID stands for access-point name

\ Disable the WIFI
: wifi-disable ( -- )
    0 wifi-set-mode ;

\ Connect to an access-point
: wifi-station ( -- )
    "PSK" "ESSID" wifi-connect ;

\ Config the node as an access-point
: wifi-ap ( -- )
    192 168 5 1 >ipv4 wifi-set-ip
    4 3 0 AUTH_WPA2_PSK "PSK" "ESSID" wifi-softap
    8 192 168 5 2 >ipv4 dhcpd-start ;

\ Display the station and access-point IP addresses
: wifi-show-ip ( -- )
    print: "Station IP: " wifi-ip type cr 
    print: "AP IP:    : " softap-ip type cr ;

