#!/usr/bin/env bash

# Anoter method for gforth scripting
gforth << EOC
255 5 * 10 +
.s bye
EOC
