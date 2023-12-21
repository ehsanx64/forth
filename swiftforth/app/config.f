.( Loading config file ...) cr

: load-env
    \ The env.f file should not be comitted to VCS
    s" env.f" 2dup file-exists if included then
;

load-env

: on-start ( -- )
      ." on-start ..." cr
      ;

: on-end ( -- )
      ." on-end ..." cr ;

