#include "crypto_aead.h"
#include "AeadDLLWrapper.h"
#include <stdio.h>

    JNIEXPORT jstring JNICALL Java_AeadDLLWrapper_crypto_1aead_1encrypt(
            JNIEnv *env,jobject jobj,
            jstring m,jlong mlen,
            jstring ad,jlong adlen,
            jstring nsec,
            jstring npub,
            jstring k
    )
    {
        unsigned char* ciphertext;
        unsigned long long* clen;
        crypto_aead_encrypt(ciphertext, clen, (const unsigned char*)m, (unsigned long long)mlen,
         (const unsigned char*)ad, (unsigned long long)adlen, (const unsigned char*)nsec, (const unsigned char*)npub, (const unsigned char*)k);
         return (jstring) ciphertext;
    }
