\ Win32-specific SwiftForth tools
[defined] -sf-tools.f [if] -sf-tools.f [then]
marker -sf-tools.f

create cmd-buff 256 chars allot

\ Feed given counted-string to >shell for execution
: >cmd ( addr u -- )
    s" cmd.exe /c " cmd-buff place 
    cmd-buff append cmd-buff count >shell ;

\ Execute the notepad
s" notepad" >cmd
