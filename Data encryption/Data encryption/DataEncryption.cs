using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace Data_encryption
{
	class DataEncryption
	{
		//generate private key
		public static string generatePrivateKey()
		{
			var RSA = new RSACryptoServiceProvider();
			return RSA.ToXmlString(true);
		}

		//generate public key over private key
		public static string generatePublicKey(string privateKey)
		{
			var RSA = new RSACryptoServiceProvider();
			RSA.FromXmlString(privateKey);
			return RSA.ToXmlString(false);
		}

		//decrypt data by asymmetric algo (private key required)
		private static string Decrypt(string data, string privateKey)
		{
			var RSA = new RSACryptoServiceProvider();
			var dataArray = data.Split(new char[] { ',' });
			byte[] dataByte = new byte[dataArray.Length];

			for (int i = 0; i < dataArray.Length; i++)
				dataByte[i] = Convert.ToByte(dataArray[i]);

			RSA.FromXmlString(privateKey);
			var decryptedByte = RSA.Decrypt(dataByte, false);
			UnicodeEncoding encoding = new UnicodeEncoding();
			return encoding.GetString(decryptedByte);
		}

		//encrypt data by asymmetric algo (public key required)
		private static string Encrypt(string data, string publicKey)
		{
			var RSA = new RSACryptoServiceProvider();
			RSA.FromXmlString(publicKey);
			UnicodeEncoding encoding = new UnicodeEncoding();
			var dataToEncrypt = encoding.GetBytes(data);
			var encryptedByteArray = RSA.Encrypt(dataToEncrypt, false).ToArray();
			var length = encryptedByteArray.Count();
			var item = 0;
			var sb = new StringBuilder();

			foreach (var x in encryptedByteArray)
			{
				item++;
				sb.Append(x);

				if (item < length)
					sb.Append(",");
			}

			return sb.ToString();
		}


		/// AES ALGO
		private static string ConvertToString(byte[] value)
		{
			var length = value.Count();
			var item = 0;
			var ans = new StringBuilder();
			foreach (var x in value)
			{
				item++;
				ans.Append(x);
				if (item < length)
					ans.Append(",");
			}

			return ans.ToString();
		}

		public static string EncryptMessage(string data, string publicKey)
		{
			string cipherText = null;
			using (AesManaged aesManager = new AesManaged())
			{
				string encryptedMessage = EncryptAES(data, aesManager.Key, aesManager.IV);
				string tempKey = ConvertToString(aesManager.Key);
				string tempIV = ConvertToString(aesManager.IV);
				string cipherKeys = Encrypt(tempKey + "<Fluffy_Cat>" + tempIV, publicKey);
				cipherText = encryptedMessage + "<Symphony-Of-Nirfolio>" + cipherKeys; 
			}
			return cipherText;
		}

		/*
		public static Tuple<byte[], byte[], string> EncryptMessage(string data, string publicKey)
		{
			string tempKey = "";

			AesManaged AESmanager = new AesManaged();
			string encryptedMessage = EncryptAES(data, AESmanager.Key, AESmanager.IV);

			Console.WriteLine(encryptedMessage);
			return new Tuple<byte[], byte[], string>(AESmanager.Key, AESmanager.IV, encryptedMessage);
		}	
		*/

		private static string EncryptAES(string data, byte[] Key, byte[] IV)
		{
			byte[] encrypted;

			using (AesManaged aesAlg = new AesManaged())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							swEncrypt.Write(data);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}
			return ConvertToString(encrypted);
		}

		private static string ParseBackValues(string data, ref string keys)
		{
			int separator = data.IndexOf("<Symphony-Of-Nirfolio>");
			keys = data.Substring(separator + ("<Symphony-Of-Nirfolio>").Length);
			return data.Substring(0, separator);
		}

		private static byte[] ConvertToByte(string value)
		{
			var dataArray = value.Split(new char[] { ',' });
			byte[] dataByte = new byte[dataArray.Length];

			for (int i = 0; i < dataArray.Length; i++)
				dataByte[i] = Convert.ToByte(dataArray[i]);
			return dataByte;
		}

		private static void ParseKeys(string value, string key, string IV)
		{
			int separator = value.IndexOf("<Fluffy_Cat>");
			key = value.Substring(0, separator);
			IV = value.Substring(separator + ("<Fluffy_Cat>").Length);
		}

		public static string DecryptMessage(string data, string privateKey)
		{
			string decryptedMessage = null;
			using (AesManaged aesManager = new AesManaged())
			{
				string cipherKeys = null;
				string cipherText = ParseBackValues(data, ref cipherKeys);
				string keys = Decrypt(cipherKeys, privateKey);
				string tempKey = null, tempIV = null;
				ParseKeys(keys, tempKey, tempIV);
				aesManager.Key = ConvertToByte(tempKey);
				aesManager.IV = ConvertToByte(tempIV);
				decryptedMessage = DecryptAES(cipherText, aesManager.Key, aesManager.IV);
			}
			return decryptedMessage;
		}

		/*
		public static string DecryptMessage(string data, byte[] tempKey, byte[] IV, string privateKey)
		{
			string decryptedMessage = DecryptAES(data, tempKey, IV);

			return decryptedMessage;
		}
		*/

		private static string DecryptAES(string data, byte[] key, byte[] IV)
		{
			byte[] dataByte = ConvertToByte(data);

			string plaintext = null;

			using (AesManaged aesAlg = new AesManaged())
			{
				aesAlg.Key = key;
				aesAlg.IV = IV;
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msDecrypt = new MemoryStream(dataByte))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}
			}

			return plaintext;
		}
		/*
		public static void Main()
		{
			string original = "Here is some data to encrypt!";

			// Create a new instance of the AesManaged
			// class.  This generates a new key and initialization 
			// vector (IV).
			using (AesManaged myAes = new AesManaged())
			{
				// Encrypt the string to an array of bytes.
				byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

				// Decrypt the bytes to a string.
				string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

				//Display the original data and the decrypted data.
				Console.WriteLine("Original:   {0}", original);
				Console.WriteLine("Round Trip: {0}", roundtrip);
			}
		}
		static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");
			byte[] encrypted;

			// Create an AesManaged object
			// with the specified key and IV.
			using (AesManaged aesAlg = new AesManaged())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create an encryptor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}


			// Return the encrypted bytes from the memory stream.
			return encrypted;

		}

		static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");

			// Declare the string used to hold
			// the decrypted text.
			string plaintext = null;

			// Create an AesManaged object
			// with the specified key and IV.
			using (AesManaged aesAlg = new AesManaged())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create a decryptor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{

							// Read the decrypted bytes from the decrypting stream
							// and place them in a string.
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}

			}

			return plaintext;

		}
		*/
	}
}
