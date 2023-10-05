\ Calling libc function example

library: libc.so.6

extern: size_t write(
    int fd,
    const void buff,
    size_t count
);

\ The write function paramaters: STDOUT string len
0 z" Hello there..." dup zstrlen write cr
." Wrote " . ." bytes to STDOUT using 'write' syscall." cr



