
	int crypto_aead_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int crypto_aead_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);
///////////////////////////////////////////////////////////////
	int acorn_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int acorn_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int ascon_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int ascon_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int ocb_encryptf(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int ocb_decryptf(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int aez_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int aez_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int aesotrs_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int aesotrs_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int aesotrp_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int aesotrp_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int keyak_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int keyak_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int norx_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int norx_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int deoxys128_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int deoxys128_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int deoxys256_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int deoxys256_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int ketje_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int ketje_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);

	int morus_encrypt(
		unsigned char *c, unsigned long long *clen,
		const unsigned char *m, unsigned long long mlen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *nsec,
		const unsigned char *npub,
		const unsigned char *k
	);


	int morus_decrypt(
		unsigned char *m, unsigned long long *outputmlen,
		unsigned char *nsec,
		const unsigned char *c, unsigned long long clen,
		const unsigned char *ad, unsigned long long adlen,
		const unsigned char *npub,
		const unsigned char *k
	);