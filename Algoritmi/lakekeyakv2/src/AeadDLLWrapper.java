public class AeadDLLWrapper {

	public native String crypto_aead_encrypt(String m, long mlen, String ad,
			long adlen, String nsec, String npub, String k);

	static {
		System.loadLibrary("encrypt_wrapper");
	}

	public static void main(String args[]) {
		System.out.println(new AeadDLLWrapper().crypto_aead_encrypt("dominik",
				7,
				"",
				0,
				"0",
				"npub",
				"key"));
	}
}