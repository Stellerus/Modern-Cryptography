using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

string[] keys =
{
    "68544020247570407220244063724074",
    "54684020247570407220244063724074",
    "54684020247570407220244063727440"
};

string targetHash = "f28fe539655fd6f7275a09b7c3508a3f81573fc42827ce34ddf1ec8d5c2421c3";

// Find correct key
var keyHex = keys.First(k =>
{
    var hash = SHA256.HashData(Convert.FromHexString(k));
    return Convert.ToHexString(hash).ToLower() == targetHash;
});

Console.WriteLine($"Correct Key: {keyHex}");

byte[] key = Convert.FromHexString(keyHex);
byte[] cipher = Convert.FromHexString("876b4e970c3516f333bcf5f16d546a87aaeea5588ead29d213557efc1903997e");
byte[] iv = Convert.FromHexString("656e6372797074696f6e496e74566563");

// AES Decryption
using var aes = Aes.Create();
aes.Key = key;
aes.IV = iv;
aes.Mode = CipherMode.CBC;

using var decryptor = aes.CreateDecryptor();
var decryptedBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);
string message = Encoding.UTF8.GetString(decryptedBytes);

Console.WriteLine($"Decrypted Message: {message}");

// Generate EC key pair
using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
string publicKey = Convert.ToBase64String(ecdsa.ExportSubjectPublicKeyInfo());

Console.WriteLine($"Public Key: {publicKey}");

// Create digital signature
var signature = ecdsa.SignData(Encoding.UTF8.GetBytes(message), HashAlgorithmName.SHA256);

Console.WriteLine($"Digital Signature: {Convert.ToBase64String(signature)}");