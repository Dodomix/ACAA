CC = gcc
SRC = ./src
DLL = ./dll
CFLAGS = -Wall -fPIC
INCLUDES = -I$(SRC)
OBJ = $(SRC)/displayIntermediateValues.o $(SRC)/encrypt.o $(SRC)/KeccakP-200-reference.o $(SRC)/KeccakP-400-reference.o $(SRC)/KeccakP-800-reference.o $(SRC)/KeccakP-800-times2-on1.o $(SRC)/KeccakP-800-times4-on1.o $(SRC)/KeccakP-800-times8-on1.o $(SRC)/KeccakP-1600-reference.o $(SRC)/KeccakP-1600-times2-on1.o $(SRC)/KeccakP-1600-times4-on1.o $(SRC)/KeccakP-1600-times8-on1.o $(SRC)/Ket.o $(SRC)/Keyakv2.o $(SRC)/Motorist.o

dll: $(OBJ)
	gcc -shared -o $(DLL)/liblake_keyak.so $(OBJ)

.PHONY: clean
clean:
	rm -f $(SRC)/*.o *.exe $(DLL)/*.so
