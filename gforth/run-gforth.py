import subprocess

# A simple program to feed some code to gforth (through stdin) and capture its
# stdout
#
# Note: Using single-line comments in the source below causes hang-up, the only
# workaround I know so far is to use multi-line comments

# Our sample programs
source = """( Nice and simple )
:noname do ." The Value: " i s>d <# # # # #> type cr loop ; 

12 2 * 1+ 1 rot execute
bye
"""

# Takes the code as a string and return the output as a string
def run_gforth(code):
    p = subprocess.run(["gforth", "-e", code], capture_output=True, text=True)
    return p.stdout

print("# Source:")
print(source)

print("# Output:")
print(run_gforth(source))

