# TODO: need to come back and add documentation for this path
MOD_OUTPUT_PATH ?= '~/.config/VintagestoryData/Mods/'

clean:
	dotnet clean modSrc/
	rm -r modSrc/runData

build-prod:
	./build.sh -c release

build-debug:
	./build.sh -c debug

docs:
	./docGen.shiv

run-server:
	./build.sh -c release
	./runServer.sh
