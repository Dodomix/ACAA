#include "crypto_aead.h"
#include "AeadDLLWrapper.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

    JNIEXPORT jstring JNICALL Java_AeadDLLWrapper_crypto_1aead_1encrypt(
            JNIEnv *env,jobject jobj,
            jstring m,
            jstring ad,
            jstring npub,
            jstring k
    )
    {
        const char* message = env->GetStringUTFChars(m, 0);
        const char* additionalData = env->GetStringUTFChars(ad, 0);
        const char* npublic = env->GetStringUTFChars(npub, 0);
        const char* key = env->GetStringUTFChars(k, 0);
        unsigned char* ciphertext;
        int tag_length = 16;
        unsigned long long ciphertext_tag_size;
        unsigned long long *clen;
        ciphertext_tag_size = strlen(message) + tag_length;
        clen = &ciphertext_tag_size;
        ciphertext = (unsigned char *)malloc(ciphertext_tag_size);

        crypto_aead_encrypt(ciphertext, clen, (const unsigned char*)message, strlen(message),
         (const unsigned char*)additionalData, strlen(additionalData), 0, (const unsigned char*)npublic, (const unsigned char*)key);

        env->ReleaseStringUTFChars(m, message);
        env->ReleaseStringUTFChars(ad, additionalData);
        env->ReleaseStringUTFChars(npub, npublic);
        env->ReleaseStringUTFChars(k, key);
        return env->NewStringUTF((char*) ciphertext);
    }
