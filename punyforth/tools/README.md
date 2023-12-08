# Punyforth Tools

These files are simple tools to make interacting with Punyforth easier. 

## Overview

- **pfs:** (Send) can be used to send a string to punyforth REPL
- **pfsf:** (SendFile) can be used to send content of a file to punyforth REPL
- **pfshell.fs:** (Shell) can be used to generate punyforth editor commands from a normal forth source file. The output then can be redirected to a file to be sent using `pfs`, `pfsf` or `pfst`. This is useful when editing code on ESP8266 flash memory, without flashing the punyforth firmware and its uploading mechanism. 
- **pfst:** (SendTelnet) can be used to send its arguments to punyforth TCP REPL (telnet)

## TODOs

- [ ] Find better names for the scripts 
- [ ] Add a mechanism to set custom serial port for all scripts
- [ ] Add a mechanism to set custom IP address for the telnet upload script

