clean:
	dotnet clean modSrc/
	rm -r modSrc/runData

build-prod:
	./build.sh -c release

build-debug:
	./build.sh -c debug

docs:
	./docGen.sh
