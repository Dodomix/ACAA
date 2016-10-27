/*
 * main.c
 *
 *  Created on: 20. 10. 2016.
 *      Author: Petar
 */


/* This is a main function that is used for AEZ algorithm testing
 *
 * Encryption input:
 * - Plaintext P
 * - Associated data AD
 * - Secret key K (len(K) = 128b, 192b or 256b)
 * - Nonce N (public message number) (8b <= len(N) <= 128b)
 * - Secret message number is not used (0)
 *
 * Encryption output:
 * - Ciphertext C (len(C) == len(P))
 * - Authentication tag T (32 <= len(T) <= 128b) concatenated with C
 * ------------------------------------------------------------------
 * Decryption input:
 * - Ciphertext C
 * - Authentication tag T
 * - Secret key K
 * - Nonce N (public message number)
 * - Associated data AD
 *
 * Decryption output:
 * - Plaintext P
 *-------------------------------------------------------------------
 * • Primary recommended parameter set aes128otrpv1 : 16-byte key for AES-128, 12-byte nonce,
 *   16-byte tag.
 * • Secondary recommended parameter set aes256otrpv1 : 32-byte key for AES-256, 12-byte nonce, 16-
 *   byte tag.
 */

#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include "crypto_aead.h"

#define TAG_LEN 16

int main(int argc, char * argv[]){

//----------VARIABLE DECLARATIONS---------------------------
    FILE *fp_r, *fp_w; // reading and writing file pointers
    size_t file_size; // file size
    unsigned char *buffer; // buffer
    const char *path_r = argv[1];
    const char *path_w = argv[2];
    unsigned long long int ciphertext_tag_size;
    int status;
//----------------------------------------------------------

//----------CRYPTOGRAPHIC PARAMETERS-------------------------------------------------
    unsigned char * ciphertext;
    unsigned long long * ciphertext_len;
    unsigned char * plaintext;
    unsigned long long  plaintext_len;
    unsigned char * nsec = (unsigned char *)malloc(16);
    const unsigned char * npub = (const unsigned char *)
            "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8";

    const unsigned char * k = (const unsigned char *)
            "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";

    const unsigned char *AD = (const unsigned char *)
            "\x32\xf3\xb4\x75\x35\xf6";
 //----------------------------------------------------------------------------------

    // Opening file for reading
    fp_r = fopen(path_r,"rb");
    fseek(fp_r, 0, SEEK_END);
    file_size = ftell(fp_r);
    printf("Size of file: %lu\n", file_size);
    fseek(fp_r, 0, SEEK_SET);

    // Allocating memory for file to be read
    if( (buffer = (unsigned char *)malloc(file_size)) == NULL ){
        printf("[ERROR] buffer memory allocation failed!\n");
        exit(1);
    } else {
        buffer = memset(buffer,'\0', file_size);
    }


    // Allocating memory for (C,T) concatenated pair
    ciphertext_tag_size = file_size * sizeof(unsigned char) + TAG_LEN;
    printf("Buffer size: %llu\n", ciphertext_tag_size);

    if( (ciphertext = (unsigned char *)malloc(ciphertext_tag_size)) == NULL){
        printf("[ERROR] ciphertext memory allocation failed!\n");
        exit(1);
    } else {
        ciphertext = memset(ciphertext, '\0', ciphertext_tag_size);
        ciphertext_len = &ciphertext_tag_size;
    }


    // Reading file into buffer
    fread(buffer, file_size, 1, fp_r);

    // Encryption
    status = crypto_aead_encrypt(ciphertext, ciphertext_len, buffer, file_size, AD, 0, 0, npub, k);

    if(status != 0){
        printf("[ERROR] Encryption failed!\n");
    } else {
        printf("[OK] Encryption was successful!\n");
    }

    printf("Ciphertext length is: %llu\n", *ciphertext_len);


    // Decryption
    plaintext = (unsigned char *)malloc(file_size);
    plaintext_len = (unsigned long long)file_size;

    status = crypto_aead_decrypt(plaintext, &plaintext_len, nsec, ciphertext, *ciphertext_len, AD, 0, npub, k);

    if(status < 0){
        printf("[ERROR] Encryption failed!\n");
    } else {
        printf("[OK] Decryption was successful!\n");
    }


    // Writing to file
    fp_w = fopen(path_w, "wb");
    fwrite(plaintext, plaintext_len, 1, fp_w);


    // Cleaning
    fclose(fp_r);
    fclose(fp_w);
    free(buffer);
    free(plaintext);
    free(ciphertext);

    return 0;
}
