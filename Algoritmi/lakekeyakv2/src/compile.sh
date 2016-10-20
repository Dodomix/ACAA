#!/bin/bash

javac AeadDLLWrapper.java
javah -jni AeadDLLWrapper
g++ -I"/opt/java/jdk1.8.0_111/include" -I/opt/java/jdk1.8.0_111/include/linux -o libencrypt_wrapper.so -shared encrypt_wrapper.cpp -fPIC
