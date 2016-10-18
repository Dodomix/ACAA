CC = gcc
SRC = ./src
BIN = ./bin
DLL = ./dll
BUILD = ./build
CFLAGS = -Wall
INCLUDES = -I$(SRC)
OBJ = $(SRC)/ascon.o $(SRC)/main.o
OBJ_PI = $(BUILD)/ascon.o

main: $(OBJ) dll
	gcc -o $(BIN)/asconv12_test.exe $(OBJ)

dll: $(OBJ_PI)
	gcc -shared -o $(DLL)/asconv12_lib.dll $(OBJ_PI)

$(BUILD)/ascon.o: 
	gcc -fPIC -c -o $(BUILD)/ascon.o $(SRC)/ascon.c

.PHONY: clean
clean:
	rm -f $(SRC)/*.o $(BIN)/*.exe $(DLL)/*.dll $(BUILD)/*.o