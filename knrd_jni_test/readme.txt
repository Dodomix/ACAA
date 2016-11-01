
##### kako compileati #####

- pokrenuti makefile naredbom: "make"
- output bi trebali biti fileovi: JNI.h, JNI.class i libdll_handler.so





##### kako testirati svoj library #####

1. Compileati svoj algoritam u library .so (Linux) ili .dll (Windows)
	- na Linuxu datoteka mora imati naziv oblika: "lib<ime>.so"
	- na Windowsima datoteka mora imati naziv oblika: "<ime>.dll"
	- ovo je zato jer tako radi loadLibrary poziv u JNI.java kodu

2. Library compileanog algoritma staviti u mapu "libs"

3. Unutar dll_handler.c dodati kod za svoj algoritam na ovaj nacin:
	- dodati path macro: "#define <ime_algoritma>_PATH "./libs/lib<ime>.so""
	- u funkciji load_algorithm dodati kod za svoj algoritam po uzoru na vec napravljene algoritme, paziti da se algoritam stavi pod vec predodredeni broj. Broj koji je pridjeljen pojedinom algoritmu mozete vidjeti u komentaru iznad funkcije

4. Compileati (pokrenuti makefile naredbom "make")

5. Pokrenuti program:
	- kod linuxa je mozda prije ovoga potrebno exportati path do dll_handler libraryja naredbom: "export LD_LIBRARY_PATH="./knrd_jni_test""
	- program se pokrece naredbom: "java -Djava.library.path=. JNI <datoteka_za_kriptiranje> <path_za_kriptiranu_datoteku> <path_za_dekriptiranu_datoteku> <broj_algoritma_od_0_do_10>"


