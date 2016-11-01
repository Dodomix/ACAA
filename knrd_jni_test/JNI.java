public class JNI {
   static {
      System.loadLibrary("dll_handler"); // Load native library at runtime
                                   // dll_handler.dll (Windows) or libdll_handler.so (Unixes)
   }
 
   // Native methods for encryption and decryption (called from library)
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
    * arg3 - algorithm number to choose (0,1,2 supported for now)
    */
   public static void main(String[] args) {

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


      // enter input file path
      String path_in = args[0];

      // enter encrypted output file path
      String path_out = args[1];

      // enter decrypted output file path
      String path_out2 = args[2];

      // Algorithm number
      int alg = Integer.parseInt(args[3]);

      // enter key (in this case 16B)
      byte[] key = hexStringToByteArray("00112233445566778899aabbccddeeff");

      // enter nonce (int his case 16B)
      byte[] nonce = hexStringToByteArray("00112233445566778899aabbccddeeff");

      // call encryption function which will do the rest and output the file
      new JNI().dll_encrypt(path_in, path_out, nonce, key, alg);  // invoke the native method

      new JNI().dll_decrypt(path_out, path_out2, nonce, key, alg);

   }
}