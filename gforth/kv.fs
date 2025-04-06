\ The kv (keyval) structure
struct
    cell% field kv->id
    1 12 field kv->name
    1 12 field kv->type
end-struct kv%

\ Create a single instance
kv% %allot constant single-kv
: kv-demo
    ." : kv-demo" cr 
    255 single-kv kv->id !
    s" product" single-kv kv->type place
    s" kv-one" single-kv kv->name place
    ." Name: " single-kv kv->name count type cr
    ." Type: " single-kv kv->type count type cr
    ."   ID: " single-kv kv->id ? cr  cr ;

\ TODO: Add a factory function to build a kv struct instance
: kv-new ( id name type -- kv )
    ;

\ TODO: Add initialization code for each struct (erasing etc.)
: kv-init ( addr -- )
    ;

\ Get a kv struct in an array of kv structures using index (i)
: kv-nth ( i -- addr )
    kv% nip * + ;

\ An array of kv structs
3 constant kvs#
kv% kvs# * %allot constant kvs
: kvs-demo-set ( -- )
    \ Erase the entire structure array
    kvs kv% nip kvs# * erase

    kvs# 1+ 1 do 
        \ Get current entry on the array
        kvs i 1- kv-nth 

        \ Set the ID
        i over kv->id !

        \ Construct name for the entry
        s" kvx" pad place i s>d <# #s #> pad +place
        dup pad count rot kv->name place

        \ Set the type
        s" test" rot kv->type place
    loop
    ;

: kvs-demo-get ( -- )
    ." : kvs-demo-get" cr 

    kvs# 1+ 1 do 
        kvs i 1- kv-nth 
        ."   ID: " dup kv->id ? cr
        ." Name: " dup kv->name count type cr
        ." Type: " kv->type count type cr
    loop
    ;

: kvs-dump ( -- )
    kvs kv% nip kvs# * dump ;

: main
    kv-demo
    kvs-demo-set
    kvs-demo-get
    kvs-dump
    .s bye
    ;

main
