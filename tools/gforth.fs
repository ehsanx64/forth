\ Check if file path exist
: file-exist ( addr u -- true|false )
    file-status nip 0= ;
    
