\ Decompilation

\ The 'see' word decompiles words (to high-level) or disassembles if they are
\ code words

\ Since words is a high-level word; see decompiles and dumps its source
see words

\ The 'dup' word is a code-word (low-level assembly) so the 'see' disassembles it
\ libtool should be available in order to disassemble code-words
see dup

