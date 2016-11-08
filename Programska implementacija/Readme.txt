
1. Napraviti novi Visual C++ project/Win32 Console Application i za tip izlazne datoteke označiti .dll
2. Dodati sav source kod koji se nalazi u TestLib/Algorithms
3. Pokrenuti build projekta i stvorit će se Algorithms.dll u Debug folderu projekta
(ako se neće buildati kako treba možete koristiti Algorithms.dll iz TestLib/Debug)
4. Napraviti novi Visual C# project/Console application
5. Dodati sav source kod koji se nalazi u TestApplication
6. Pokrenuti build projekta
7. Kopirati Algorithms.dll u obj/Debug folder C# projekta u kojem se nalazi i buildani .exe iz prošlog koraka, dodajte i testfrog.jpg u ovaj folder iz knrd_jni_test foldera radi lakšeg pokretanja
8. Pokrenuti iz cmd-a sa "ImeAplikacije.exe testfrog.jpg enkriptiraniFile.jpg dekriptiraniFile.jpg [br_algoritma]", gdje je [br_algoritma] broj algoritma od 0 do 10, s obzirom da 0 još ne radi.