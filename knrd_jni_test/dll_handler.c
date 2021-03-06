
#include <stdlib.h>
#include <stdio.h>
#include <dlfcn.h>
#include <jni.h>
#include <string.h>

//#include "crypto_aead.h"
#include "JNI.h"

#define ASCON_PATH "./libs/libascon.so"
#define AESOTRP_PATH "./libs/libaesotrp.so"
#define AESOTRS_PATH "./libs/libaesotrs.so"
#define KEYAK_PATH "./libs/liblake_keyak.so"


/*
algorithms to choose:

0 - ASCON
1 - AESOTRS
2 - AESOTRP

------ not yet supported ------
3 - Acorn
4 - Keyak
5 - OCB
6 - Norx
7 - Deoxys
8 - Ketje
9 - AEZ
10 - MORUS
*/
void* load_algorithm(int alg){

    void *encrypt_fn_handle = NULL;

        switch(alg){

            // ASCON
            case 0:
                encrypt_fn_handle = dlopen(ASCON_PATH, RTLD_LAZY);
                if (!encrypt_fn_handle) {
                    printf("[ERROR] Cannot load Ascon library\n");
                    return NULL;
                }
                break;

            // AESOTRS
            case 1:
                encrypt_fn_handle = dlopen(AESOTRS_PATH, RTLD_LAZY);
                if (!encrypt_fn_handle) {
                    printf("[ERROR] Cannot open AES-OTR-s library\n");
                    return NULL;
                }
                break;

            // AESOTRP
            case 2:
                encrypt_fn_handle = dlopen(AESOTRP_PATH, RTLD_LAZY);
                if (!encrypt_fn_handle) {
                    printf("[ERROR] Cannot open AES-OTR-p library\n");
                    return NULL;
                }
                break;

            // Acorn
            case 3:
                printf("[ERROR] Acorn not yet supported!\n");
                exit(1);
                break;

            // Keyak
            case 4:
                encrypt_fn_handle = dlopen(KEYAK_PATH, RTLD_LAZY);
                if (!encrypt_fn_handle) {
                    printf("[ERROR] Cannot open keyak library\n");
                    return NULL;
                }
                break;

            // OCB
            case 5:
                printf("[ERROR] OCB not yet supported!\n");
                exit(1);
                break;

            // Norx
            case 6:
                printf("[ERROR] Norx not yet supported!\n");
                exit(1);
                break;

            // Deoxys
            case 7:
                printf("[ERROR] Deoxys not yet supported!\n");
                exit(1);
                break;

            // Ketje
            case 8:
                printf("[ERROR] Ketje not yet supported!\n");
                exit(1);
                break;

            // AEZ
            case 9:
                printf("[ERROR] AEZ not yet supported!\n");
                exit(1);
                break;

            // MORUS
            case 10:
                printf("[ERROR] MORUS not yet supported!\n");
                exit(1);
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
void encrypt(const unsigned char *filepath, const unsigned char *outpath, const unsigned char *nonce, const unsigned char *k, int alg) {

//----------VARIABLE DECLARATIONS---------------------------
    FILE *fp_r, *fp_w; // reading and writing file pointers
    size_t file_size; // file size
    unsigned char *buffer; // buffer
    const char *path_r = filepath;
    const char *path_w = outpath;
    unsigned long long int ciphertext_tag_size;
    int status;

    void *encrypt_fn_handle;

    int (*crypto_aead_encrypt)(unsigned char *c, unsigned long long *clen,
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

    const unsigned char * npub = (const unsigned char *) nonce;

    /*const unsigned char * k = (const unsigned char *)
            "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";*/

    const unsigned char *AD = (const unsigned char *)
            "\x32\xf3\xb4\x75\x35\xf6";
 //-----------------------------------------------------------------------------------


    // Loading algorithm DLL
    if( (encrypt_fn_handle = load_algorithm(alg)) == NULL){
        printf("[ERROR] Loading algorithm library\n");
        return;
    }


    // loading algorithm from loaded DLL
    crypto_aead_encrypt = dlsym(encrypt_fn_handle, "crypto_aead_encrypt");


    // Opening file for reading
    fp_r = fopen(path_r, "rb");
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
    ciphertext_tag_size = file_size * sizeof(unsigned char) + tag_length;
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
    status = (*crypto_aead_encrypt)(ciphertext, ciphertext_len, buffer, file_size, AD, 0, 0, npub, k);

    if(status != 0){
        printf("[ERROR] Encryption failed!\n");
    } else {
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


    // close dll encrypt_fn_handle
    dlclose(encrypt_fn_handle);

}




/* Decryption function
 *
 * filepath - path to file to decrypt
 * outpath - path where decrypted file will be stored
 * nonce - public message number
 * k - secret key
 * alg - algorithm to choose (0,1,2 for now)
 */
void decrypt(const unsigned char *filepath, const unsigned char *outpath, const unsigned char *nonce, const unsigned char *k, int alg) {

//----------VARIABLE DECLARATIONS---------------------------
    FILE *fp_r, *fp_w; // reading and writing file pointers
    size_t file_size; // file size
    unsigned char *buffer; // buffer
    const char *path_r = filepath;
    const char *path_w = outpath;
    int status;

    void *decrypt_fn_handle;

    int (*crypto_aead_decrypt)(
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

    const unsigned char * npub = (const unsigned char *) nonce;

    /*const unsigned char * k = (const unsigned char *)
            "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";*/

    const unsigned char *AD = NULL;
 //----------------------------------------------------------------------------------


   // Loading algorithm DLL
    if( (decrypt_fn_handle = load_algorithm(alg)) == NULL){
        printf("[ERROR] Loading algorithm library\n");
        return;
    }


    // loading algorithm from loaded DLL
    crypto_aead_decrypt = dlsym(decrypt_fn_handle, "crypto_aead_decrypt");



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


    // Allocating memory for plaintext
    plaintext_size = file_size * sizeof(unsigned char) - tag_length;
    printf("Buffer size: %llu\n", plaintext_size);

    if( (plaintext = (unsigned char *)malloc(plaintext_size)) == NULL){
        printf("[ERROR] plaintext memory allocation failed!\n");
        exit(1);
    } else {
        plaintext = memset(plaintext, '\0', plaintext_size);
    }


    // Reading ciphertext file into buffer
    fread(buffer, file_size, 1, fp_r);


    // Decryption
    status = (*crypto_aead_decrypt)(plaintext, &plaintext_size, 0, buffer, file_size, AD, 0, npub, k);

    if(status < 0){
        printf("[ERROR] Decryption failed!\n");
    } else {
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


    // close dll decrypt_fn_handle
    dlclose(decrypt_fn_handle);

}

void prepare_algorithm(unsigned char **nonce, unsigned char **key, int algorithm) {
    if (algorithm == 4) {
        unsigned char *tmp = *nonce;
        int nonce_len = (int) strlen(*nonce);
        if (nonce_len > 150) {
            nonce_len = 150;
        }
        *nonce = (unsigned char*) malloc(150);
        *nonce = (unsigned char*) memset(*nonce, '\0', 150);
        *nonce = (unsigned char*) memcpy(*nonce, tmp, nonce_len);

        *tmp = *key;
        int key_len = (int) strlen(*nonce);
        if (key_len > 16) {
            key_len = 16;
        }
        *key = (unsigned char*) malloc(150);
        *key = (unsigned char*) memset(*key, '\0', 16);
        *key = (unsigned char*) memcpy(*key, tmp, key_len);
    }
}


/* Java JNI exported function which is a wrapper for the encryption function.
 * env - pointer to java environment
 * obj - dunno?
 * path_in - path to file to encrypt
 * path out - location in which encrypted file will be stored
 * pub - public message number
 * alg - algorithm to choose (0,1,2 for now)
 */
JNIEXPORT void JNICALL Java_JNI_dll_1encrypt (JNIEnv * env, jobject obj, jstring path_in, jstring path_out, jbyteArray pub, jbyteArray key, jint alg){

    // convert java types to C types
    const unsigned char *filepath = (*env)->GetStringUTFChars( env, path_in, 0 );
    const unsigned char *outpath = (*env)->GetStringUTFChars( env, path_out, 0 );

    jboolean isCopy1, isCopy2;
    const unsigned char *nonce = (const unsigned char*)((*env)->GetByteArrayElements(env, pub, &isCopy1));
    const unsigned char *k = (const unsigned char*)((*env)->GetByteArrayElements(env, key, &isCopy2));
    prepare_algorithm(&nonce, &k, (int)alg);
    // Call encryption handler
    encrypt(filepath, outpath, nonce, k, (int)alg);


    // clean
    (*env)->ReleaseStringUTFChars( env, path_in, filepath );
    (*env)->ReleaseStringUTFChars( env, path_out, outpath );

    if(isCopy1){
        (*env)->ReleaseByteArrayElements(env, pub, (jbyte*)nonce, JNI_ABORT);
    }

    if(isCopy2){
        (*env)->ReleaseByteArrayElements(env, key, (jbyte*)k, JNI_ABORT);
    }

    return;
}



/* Java JNI exported function which is a wrapper for the decryption function.
 * env - pointer to java environment
 * obj - dunno?
 * path_in - path to file to decrypt
 * path out - location in which decrypted file will be stored
 * pub - public message number
 * alg - algorithm to choose (0,1,2 for now)
 */
JNIEXPORT void JNICALL Java_JNI_dll_1decrypt(JNIEnv *env, jobject obj, jstring path_in, jstring path_out, jbyteArray pub, jbyteArray key, jint alg){

    // convert java types to C types
    const unsigned char *filepath = (*env)->GetStringUTFChars( env, path_in, 0 );
    const unsigned char *outpath = (*env)->GetStringUTFChars( env, path_out, 0 );

    jboolean isCopy1, isCopy2;
    const unsigned char *nonce = (const unsigned char*)((*env)->GetByteArrayElements(env, pub, &isCopy1));
    const unsigned char *k = (const unsigned char*)((*env)->GetByteArrayElements(env, key, &isCopy2));
    prepare_algorithm(&nonce, &k, (int)alg);


    // Call decryption handler
    decrypt(filepath, outpath, nonce, k, (int)alg);


    // clean
    (*env)->ReleaseStringUTFChars( env, path_in, filepath );
    (*env)->ReleaseStringUTFChars( env, path_out, outpath );

    if(isCopy1){
        (*env)->ReleaseByteArrayElements(env, pub, (jbyte*)nonce, JNI_ABORT);
    }

    if(isCopy2){
        (*env)->ReleaseByteArrayElements(env, key, (jbyte*)k, JNI_ABORT);
    }

    return;
}




