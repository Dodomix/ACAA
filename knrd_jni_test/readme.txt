Kako compileati i testirati:

1. Compileati .so fileove (tako se .dll zove na linuxu) preko makefilea pozivanjem naredbe "make".

2. Compileati JNI.java naredbom: "javac JNI.java"

3. Stvoriti java JNI header file: "javah -jni JNI"

4. Compileati dll_handler.c u .so(.dll): "gcc -I/usr/lib/jvm/java-8-openjdk-amd64/include -I/usr/lib/jvm/java-8-openjdk-amd64/include/linux -o libdll_handler.so dll_handler.c -shared -fpic -ldl"

- mozda se razlikuje na windowsima, recimo ovaj include/linux bi mozda trebao biti izmjenjen

5. Pokrenuti program: "java -Djava.library.path=./knrd_jni_test JNI testfrog.jpg kriptirana_zaba dekriptirana_zaba.jpg"

- kod linuxa je mozda prije ovoga potrebno exportati path do librarija: "export LD_LIBRARY_PATH="./knrd_jni_test""



Java program prima 3 parametra: JNI <datoteka za kriptiranje> <path_za_kriptirani_file> <path_za_dekriptirani_file>
