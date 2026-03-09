# Cryptography Console Application (C#)

## Overview

This project is a simple C# console application that performs several
cryptographic tasks:

1.  Identify the correct 128-bit symmetric key using SHA-256 hashing.
2.  Decrypt an AES-128 encrypted message using CBC mode.
3.  Generate an asymmetric Elliptic Curve key pair.
4.  Create a digital signature of the decrypted plaintext message.

The application uses the built-in cryptographic libraries available in
.NET.

------------------------------------------------------------------------

# Steps Performed

## 1. Identifying the Correct Symmetric Key

Three candidate 128-bit symmetric keys were provided in hexadecimal
format. To determine which key is correct, the program:

1.  Converts each hexadecimal key into bytes.
2.  Computes the SHA-256 hash of each key.
3.  Converts the resulting hash back into hexadecimal format.
4.  Compares the calculated hash with the provided SHA-256 hash.

The key whose hash matches the provided hash is selected as the
**correct symmetric key**.

------------------------------------------------------------------------

## 2. Decrypting the AES-128 Encrypted Message

After finding the correct symmetric key, the encrypted message is
decrypted using AES-128.

Configuration used:

-   Algorithm: AES
-   Key size: 128 bits
-   Mode: CBC (Cipher Block Chaining)
-   Padding: PKCS7
-   Initialization Vector (IV): provided in hexadecimal format

Steps: 1. Convert the ciphertext and IV from hexadecimal to byte arrays.
2. Configure the AES algorithm with the correct key and IV. 3. Use an
AES decryptor to decrypt the ciphertext. 4. Convert the resulting byte
array into a readable plaintext string.

This produces the **original decrypted message**.

------------------------------------------------------------------------

## 3. Generating an Elliptic Curve Key Pair

The program generates an asymmetric key pair using Elliptic Curve
Cryptography (ECC).

The .NET `ECDsa` class is used with the **NIST P-256 curve**. This
generates:

-   A **private key** used for signing
-   A **public key** that can be shared for verification

The public key is exported and printed in Base64 format.

------------------------------------------------------------------------

## 4. Creating a Digital Signature

To verify the integrity and authenticity of the message, a digital
signature is generated.

Steps: 1. Convert the decrypted plaintext message into bytes. 2. Use the
private ECC key to sign the message. 3. Apply the SHA-256 hashing
algorithm during signing.

The resulting signature is displayed in Base64 format.

------------------------------------------------------------------------

# Output

When the program runs, it prints the following results:

-   Correct symmetric key
-   Decrypted plaintext message
-   Generated elliptic curve public key
-   Digital signature of the decrypted message

------------------------------------------------------------------------

# Technologies Used

-   C#
-   .NET Cryptography Libraries
-   SHA-256 hashing
-   AES-128 encryption (CBC mode)
-   Elliptic Curve Digital Signature Algorithm (ECDSA)

------------------------------------------------------------------------

# How to Run

1.  Open the project in Visual Studio or any .NET compatible IDE.
2.  Build the project.
3.  Run the console application.

The results will be displayed in the console window.
