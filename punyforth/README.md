# punyforth

This folder contains punyforth-related forth programs and shell scripts.

## Description

- **hello-world.forth** Traditional "Hello world" program in punyforth

---

## Uploading forth code

The general method for sending/uploading code to serial port to cat a string or file to a serial port. On Microsoft Windows this could be done this way:

```cmd
rem Assuming the ESP8266 is connected to COM35 serial port
cmd.exe /c type hello-world.forth > \\.\COM35
```

or on Linux:

```bash
# Assuming target is /dev/ttyUSB0
cat hello-world.forth > /dev/ttyUSB0
```

The port baud-rate and other settings can cause bytes to be dropped and as a result source code can get corrupted, to workaround that problem I'm wrote two simple shell scripts that make life a lot easier. The script assumes the OS is Linux and the ESP8266 is connected to `/dev/ttyUSB0`.

---

## pfs

`pfs` can easily be invoked:

```bash
# Send the command to the serial port
./pfs 'println: "Hey there"'
```

it is also possible to read the code from environment variables, which brings more flexibility and/or headaches.

```bash
thecode='cr print: "Current stack depth: " depth . cr'
./pfs $thecode
```

---

## pfsf

`pfsf` takes a filename as input and sends (uploads) it to default serial port.  Assuming a file named `hello.fs` exists in current directory, following command would upload it:

```bash
# Send the file
./pfsf hello.fs
```

---

## Issues/Todos

At the moment I don't see any obvious bugs, but ...

- [ ] Use an environment variable to config the default serial port


