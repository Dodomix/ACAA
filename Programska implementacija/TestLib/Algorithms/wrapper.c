#include <string.h>
#include <stdio.h>
#include "crypto_aead.h"
#include <stdlib.h>

// Imena metoda su <ime_algoritma>_encrypt i <ime_algoritma>_decrypt 
void* load_algorithm(int alg, int decrypt) {

	void *encrypt_fn_handle = NULL;

	switch (alg) {

	// ASCON
	case 0:
		if (decrypt) encrypt_fn_handle = &ascon_decrypt;
		else encrypt_fn_handle = &ascon_encrypt;
		break;

	// AESOTRS
	case 1:
		if (decrypt) encrypt_fn_handle = &aesotrs_decrypt;
		else encrypt_fn_handle = &aesotrs_encrypt;
		break;

	// AESOTRP
	case 2:
		if (decrypt) encrypt_fn_handle = &aesotrp_decrypt;
		else encrypt_fn_handle = &aesotrp_encrypt;
		break;

	// Acorn
	case 3:
		if (decrypt) encrypt_fn_handle = &acorn_decrypt;
		else encrypt_fn_handle = &acorn_encrypt;
		break;

	// Keyak
	case 4:
		if (decrypt) encrypt_fn_handle = &keyak_decrypt;
		else encrypt_fn_handle = &keyak_encrypt;
		break;

	// OCB
	case 5:
		if (decrypt) encrypt_fn_handle = &ocb_decryptf;
		else encrypt_fn_handle = &ocb_encryptf;
		break;

	// Norx
	case 6:
		if (decrypt) encrypt_fn_handle = &norx_decrypt;
		else encrypt_fn_handle = &norx_encrypt;
		break;

	// Deoxys
	case 7:
		if (decrypt) encrypt_fn_handle = &deoxys_decrypt;
		else encrypt_fn_handle = &deoxys_encrypt;
		break;

	// Ketje
	case 8:
		if (decrypt) encrypt_fn_handle = &ketje_decrypt;
		else encrypt_fn_handle = &ketje_encrypt;
		break;

	// AEZ
	case 9:
		if (decrypt) encrypt_fn_handle = &aez_decrypt;
		else encrypt_fn_handle = &aez_encrypt;
		break;

	// MORUS
	case 10:
		if (decrypt) encrypt_fn_handle = &morus_decrypt;
		else encrypt_fn_handle = &morus_encrypt;
		break;

	default:
		printf("[ERROR] Algorithm not specified!\n");
		exit(1);
	}

	return encrypt_fn_handle;
}

/* Encryption function
*
* filepath - path to file to encrypt
* outpath - path where encrypted file will be stored
* nonce - public message number
* k - secret key
* alg - algorithm to choose (0,1,2 for now)
*/
__declspec(dllexport) void encrypt(const unsigned char *filepath, const unsigned char *outpath, const unsigned char *nonce, const unsigned char *k, int alg) {

	//----------VARIABLE DECLARATIONS---------------------------
	FILE *fp_r, *fp_w; // reading and writing file pointers
	size_t file_size; // file size
	unsigned char *buffer; // buffer
	const char *path_r = filepath;
	const char *path_w = outpath;
	unsigned long long int ciphertext_tag_size;
	int status;

	int(*crypto_aead_encrypt)(unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k);
	//----------------------------------------------------------

	//----------CRYPTOGRAPHIC PARAMETERS-------------------------------------------------
	unsigned char * ciphertext;
	unsigned long long * ciphertext_len;
	unsigned char * plaintext;
	unsigned long long  plaintext_len;
	unsigned char * nsec = (unsigned char *)malloc(16);
	int tag_length = 16;

	const unsigned char * npub = (const unsigned char *)nonce;

	/*const unsigned char * k = (const unsigned char *)
	"\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";*/

	const unsigned char *AD = (const unsigned char *)
		"\x32\xf3\xb4\x75\x35\xf6";
	//-----------------------------------------------------------------------------------

	// Load algorithm
	if ((crypto_aead_encrypt = load_algorithm(alg, 0)) == NULL) {
		printf("[ERROR] Loading algorithm library\n");
	}

	// Opening file for reading
	fp_r = fopen(path_r, "rb");
	fseek(fp_r, 0, SEEK_END);
	file_size = ftell(fp_r);
	printf("Size of file: %lu\n", file_size);
	fseek(fp_r, 0, SEEK_SET);


	// Allocating memory for file to be read
	if ((buffer = (unsigned char *)malloc(file_size)) == NULL) {
		printf("[ERROR] buffer memory allocation failed!\n");
		exit(1);
	}
	else {
		buffer = memset(buffer, '\0', file_size);
	}


	// Allocating memory for (C,T) concatenated pair
	ciphertext_tag_size = file_size * sizeof(unsigned char) + 2*tag_length + 1000;  //inace je buffer premalen za NORX??
	printf("Buffer size: %llu\n", ciphertext_tag_size);

	if ((ciphertext = (unsigned char *)malloc(ciphertext_tag_size)) == NULL) {
		printf("[ERROR] ciphertext memory allocation failed!\n");
		exit(1);
	}
	else {
		ciphertext = memset(ciphertext, '\0', ciphertext_tag_size);
		ciphertext_len = &ciphertext_tag_size;
	}


	// Reading file into buffer
	fread(buffer, file_size, 1, fp_r);


	// Encryption
	status = (*crypto_aead_encrypt)(ciphertext, ciphertext_len, buffer, file_size, AD, 0, 0, npub, k);

	if (status != 0) {
		printf("[ERROR] Encryption failed!\n");
	}
	else {
		printf("[OK] Encryption was successful!\n");
	}


	// Writing to file
	fp_w = fopen(path_w, "wb");
	fwrite(ciphertext, *ciphertext_len, 1, fp_w);


	// Cleaning
	fclose(fp_r);
	fclose(fp_w);
	free(buffer);
	//free(plaintext);
	free(ciphertext);

}




/* Decryption function
*
* filepath - path to file to decrypt
* outpath - path where decrypted file will be stored
* nonce - public message number
* k - secret key
* alg - algorithm to choose (0,1,2 for now)
*/
__declspec(dllexport) void decrypt(const unsigned char *filepath, const unsigned char *outpath, const unsigned char *nonce, const unsigned char *k, int alg) {

	//----------VARIABLE DECLARATIONS---------------------------
	FILE *fp_r, *fp_w; // reading and writing file pointers
	size_t file_size; // file size
	unsigned char *buffer; // buffer
	const char *path_r = filepath;
	const char *path_w = outpath;
	int status;

	int(*crypto_aead_decrypt)(
		unsigned char *m, unsigned long long *mlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k);
	//----------------------------------------------------------

	//----------CRYPTOGRAPHIC PARAMETERS-------------------------------------------------
	unsigned char * plaintext;
	unsigned long long int plaintext_size;
	//unsigned char * nsec = (unsigned char *)malloc(16);
	int tag_length = 16;

	const unsigned char * npub = (const unsigned char *)nonce;

	/*const unsigned char * k = (const unsigned char *)
	"\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";*/

	const unsigned char *AD = NULL;
	//----------------------------------------------------------------------------------

	// Load algorithm
	if ((crypto_aead_decrypt = load_algorithm(alg, 1)) == NULL) {
		printf("[ERROR] Loading algorithm library\n");
	}

	// Opening file for reading
	fp_r = fopen(path_r, "rb");
	fseek(fp_r, 0, SEEK_END);
	file_size = ftell(fp_r);
	printf("Size of file: %lu\n", file_size);
	fseek(fp_r, 0, SEEK_SET);


	// Allocating memory for file to be read
	if ((buffer = (unsigned char *)malloc(file_size)) == NULL) {
		printf("[ERROR] buffer memory allocation failed!\n");
		exit(1);
	}
	else {
		buffer = memset(buffer, '\0', file_size);
	}


	// Allocating memory for plaintext
	plaintext_size = file_size * sizeof(unsigned char) + tag_length;
	printf("Buffer size: %llu\n", plaintext_size);

	if ((plaintext = (unsigned char *)malloc(plaintext_size)) == NULL) {
		printf("[ERROR] plaintext memory allocation failed!\n");
		exit(1);
	}
	else {
		plaintext = memset(plaintext, '\0', plaintext_size);
	}


	// Reading ciphertext file into buffer
	fread(buffer, file_size, 1, fp_r);


	// Decryption
	status = (*crypto_aead_decrypt)(plaintext, &plaintext_size, 0, buffer, file_size, AD, 0, npub, k);

	if (status < 0) {
		printf("[ERROR] Decryption failed!\n");
	}
	else {
		printf("[OK] Decryption was successful!\n");
	}


	// Writing to file
	fp_w = fopen(path_w, "wb");
	fwrite(plaintext, plaintext_size, 1, fp_w);


	// Cleaning
	fclose(fp_r);
	fclose(fp_w);
	free(buffer);
	free(plaintext);

}
