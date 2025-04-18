\ Using the system word to call OS applications
.( output   -> ) s" uname -a | tr -d '\n'" system cr 

\ A quick (dirty) method to run an OS application and capture its output
s" uname -a | tr -d '\n' > /tmp/systmp" system 
s" /tmp/systmp" slurp-file
.( tempfile -> ) type cr bye
