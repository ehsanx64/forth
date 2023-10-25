\ Including (loading) forth source files

\ Both following lines include the 'bombs.fs' from current directory
s" bombs.fs" included
include stack.fs

\ During gforth invocation source files could be loaded this way
\ gforth file1.fs file2.fs

\ To load the files and exit the gforth following command would be used:
\ gforth file1.fs file2.fs -e bye
