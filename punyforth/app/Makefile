
tmp=./tmp

run:
	pfsf test.forth

all:
	#rm ./tmp/*.txt

	# 148 (PUNIT 3 +) screen hold the dependencies
	gforth ../tools/pfshell.fs -e 's" deps.forth" 148 send bye' > ${tmp}/deps.txt

	# 149 : tools
	gforth ../tools/pfshell.fs -e 's" ../lib/tools.forth" 149 send bye' > ${tmp}/tools.txt

	# 153 : flash
	gforth ../tools/pfshell.fs -e 's" ../lib/flash.forth" 153 send bye' > ${tmp}/flash.txt

	# 154 : led
	gforth ../tools/pfshell.fs -e 's" ../lib/led.forth" 154 send bye' > ${tmp}/led.txt

	# 155 : main
	gforth ../tools/pfshell.fs -e 's" main.forth" 155 send bye' > ${tmp}/main.txt

	# Upload the dependencies screen
	bash ../tools/pfsf ${tmp}/deps.txt
	bash ../tools/pfsf ${tmp}/tools.txt
	bash ../tools/pfsf ${tmp}/flash.txt
	bash ../tools/pfsf ${tmp}/led.txt
	bash ../tools/pfsf ${tmp}/main.txt

test:
	pfsf test.forth


