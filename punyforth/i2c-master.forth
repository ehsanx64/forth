\ I2C Master Example

-i2c-master.forth
marker: -i2c-master.forth

5 ( D1 SCL ) constant: SCL
4 ( D2 SDA ) constant: SDA
0 ( D3 RST ) constant: RST 
16r12        constant: SLAVE
0            constant: BUS
2 ( 400K )   constant: FREQ

exception: EI2C

\ Initialize pine for I2C communication
: wire ( -- )
    SCL GPIO_OUT gpio-mode
    SDA GPIO_OUT gpio-mode    
    RST GPIO_LOW gpio-write ;

: reset ( -- )
    RST GPIO_HIGH gpio-write 1 ms
    RST GPIO_LOW  gpio-write 10 ms
    RST GPIO_HIGH gpio-write ;

\ Throw exception for i2c operations
: check ( code -- | throws:EI2C ) 
    0<> if EI2C throw then ;

: bus-init ( -- )
    400 SDA SCL BUS i2c-init check ;

\ Create the main buffer and initialize it
create: buf 16r0 c, 16r1 c, 16r0 c,
3 constant: buf%

\ Buffer to read from slaves
create: buf2 14 allot

\ Dump a memory area
: dump ( addr len -- )
    bounds
    2dup do i c@ . print: " " loop cr
    do i c@ emit print: " " loop cr ;

\ Write the buf to the slave
: >i2c ( -- )
    buf 0 SLAVE BUS i2c-write-slave ;

\ Request a byte from the slave
: req ( -- | throws:EI2C )
    1 buf2 0 SLAVE BUS i2c-read-slave ;

: cmd ( byte -- | throws:EI2C )
    buf 1+ c! buf% >i2c ;

: cmd2 ( byte -- | throws:EI2C )
    buf c! 1 >i2c ;

: init ( -- | throws:ESSD1306 )
    wire bus-init reset ;

cr init
0
