CC = gcc
SRC = ./src
BIN = ./bin
DLL = ./dll
BUILD = ./build
CFLAGS = -Wall
INCLUDES = -I$(SRC)
OBJ = $(SRC)/OTR.o $(SRC)/encrypt.o $(SRC)/t-aes_enc_only.o $(SRC)/main.o
OBJ_PI = $(BUILD)/OTR.o $(BUILD)/encrypt.o $(BUILD)/t-aes_enc_only.o

main: $(OBJ) dll
	gcc -o $(BIN)/aesotrpv3_test.exe $(OBJ)

dll: $(BUILD)/OTR.o $(BUILD)/encrypt.o $(BUILD)/t-aes_enc_only.o
	gcc -shared -o $(DLL)/libaesotrp.so $(OBJ_PI)

$(BUILD)/OTR.o: 
	gcc -fPIC -c -o $(BUILD)/OTR.o $(SRC)/OTR.c

$(BUILD)/encrypt.o: 
	gcc -fPIC -c -o $(BUILD)/encrypt.o $(SRC)/encrypt.c

$(BUILD)/t-aes_enc_only.o: 
	gcc -fPIC -c -o $(BUILD)/t-aes_enc_only.o $(SRC)/t-aes_enc_only.c




.PHONY: clean
clean:
	rm -f $(SRC)/*.o $(BIN)/*.exe $(DLL)/*.dll $(BUILD)/*.o