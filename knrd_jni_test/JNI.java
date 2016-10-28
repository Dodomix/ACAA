public class JNI {
   static {
      System.loadLibrary("dll_handler"); // Load native library at runtime
                                   // hello.dll (Windows) or libhello.so (Unixes)
   }
 
   // Declare a native method sayHello() that receives nothing and returns void
   private native void dll_encrypt(String path_in, String path_out, byte[] npub, byte[] key, int alg);
   private native void dll_decrypt(String path_in, String path_out, byte[] npub, byte[] key, int alg);


   // hex string => byte array
   public static byte[] hexStringToByteArray(String s) {
       int len = s.length();
       byte[] data = new byte[len / 2];
       for (int i = 0; i < len; i += 2) {
           data[i / 2] = (byte) ((Character.digit(s.charAt(i), 16) << 4)
                                + Character.digit(s.charAt(i+1), 16));
       }
       return data;
   }



   /* Main function
    * arg0 - file to encrypt
    * arg1 - path to encrypted file storage
    * arg2 - path to decrypted file storage
    */
   public static void main(String[] args) {

      /* 
      algorithms to choose:

      0 - ASCON
      1 - AESOTRS
      2 - AESOTRP
      3 - ???
      */

      int alg = 1;

      // enter input file path
      String path_in = args[0];

      // enter output file path
      String path_out = args[1];

      // enter output 2 file path
      String path_out2 = args[2];

      // enter key
      byte[] key = hexStringToByteArray("00112233445566778899aabbccddeeff");

      // enter nonce
      byte[] nonce = hexStringToByteArray("00112233445566778899aabbccddeeff");

      // call encryption function which will do the rest and output the file
      new JNI().dll_encrypt(path_in, path_out, nonce, key, alg);  // invoke the native method

      new JNI().dll_decrypt(path_out, path_out2, nonce, key, alg);

   }
}