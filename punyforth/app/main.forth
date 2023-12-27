-app.forth
marker: -app.forth

1000 constant: buff%
create: buff2 buff% allot

: template ( -- addr )
    "Hello % Welcome %" ;

: .log ( value title -- )
    type type cr ;

: >buff2 ( string -- )
    buff2 buff% erase
    count buff2 swap cmove ;

: main ( -- )
    println: "Running main ..."
    cr template "Template: " .log 

( 
    template "User!" mix >buff2 
    buff2 "1st substitution: " .log

    buff2 "..." mix
    dup "2nd substitution: " .log

    cr "POST /index.php/%/% HTTP/1.1" >buff2 
    buff2 "New Template: " .log

    buff2 "sns" mix >buff2
    dup "sns substitution: " .log

    buff2 "names" mix
    "names substitution: " .log
    )
    ;

stack-clear
main

/end
