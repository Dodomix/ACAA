
JAVA_INCLUDE_PATH = "/usr/lib/jvm/java-8-openjdk-amd64/include"
JAVA_INCLUDE_PLATFORM = "/usr/lib/jvm/java-8-openjdk-amd64/include/linux"

JNI.class: JNI.java JNI.h libdll_handler.so
	javac JNI.java

JNI.h: 
	javah -jni JNI

libdll_handler.so:
	gcc -I$(JAVA_INCLUDE_PATH) -I$(JAVA_INCLUDE_PLATFORM) -o libdll_handler.so dll_handler.c -shared -fpic -ldl


.PHONY: clean
clean:
	rm -f ./JNI.class ./JNI.h ./libdll_handler.so
