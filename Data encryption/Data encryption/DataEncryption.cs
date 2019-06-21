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
		///RSA ALGO

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
		
		//convert array of bytes to string
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

		//cipher keys with RSA
		private static string CipherPart(string value, string publicKey, string code)
		{
			string cipherText = "";
			int i = value.Length;
			while (i - 40 >= 0)
			{
				if (i != value.Length)
					cipherText += code;
				cipherText += Encrypt(value.Substring(i - 40, 40), publicKey);
				i -= 40;
			}
			if (i > 0)
			{
				if (i != value.Length)
					cipherText += code;
				cipherText += Encrypt(value.Substring(0, i), publicKey);
			}
			cipherText += code;
			return cipherText;
		}

		//turn keys to string
		private static string EncryptKeys(string key, string IV, string publicKey)
		{
			string cipherText = CipherPart(key, publicKey, "<Fluffy_Cats>");
			cipherText += CipherPart(IV, publicKey, "<Sleepy_Cats>");
			return cipherText;
		}

		//encrypt message (public key required)
		public static string EncryptMessage(string data, string publicKey)
		{
			string cipherText = null;
			using (AesManaged aesManager = new AesManaged())
			{
				string encryptedMessage = EncryptAES(data, aesManager.Key, aesManager.IV);
				string tempKey = ConvertToString(aesManager.Key);
				string tempIV = ConvertToString(aesManager.IV);
				string cipherKeys = EncryptKeys(tempKey, tempIV, publicKey);
				cipherText = encryptedMessage + "<Symphony-Of-Nirfolio>" + cipherKeys; 
			}
			return cipherText;
		}

		//encrypt AES algo
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

		//parse a part of data to split keys and message
		private static string ParseBackValues(string data, ref string keys)
		{
			int separator = data.IndexOf("<Symphony-Of-Nirfolio>");
			keys = data.Substring(separator + ("<Symphony-Of-Nirfolio>").Length);
			return data.Substring(0, separator);
		}

		//convert string to array of byte
		private static byte[] ConvertToByte(string value)
		{
			var dataArray = value.Split(new char[] { ',' });
			byte[] dataByte = new byte[dataArray.Length];

			for (int i = 0; i < dataArray.Length; i++)
				dataByte[i] = Convert.ToByte(dataArray[i]);
			return dataByte;
		}

		//decipher keys with RSA
		private static string DeCipher(ref string value, string privateKey, string code)
		{
			string cipherText = "";
			int separator = value.IndexOf(code);
			while (separator != -1 && value.Length > 0)
			{
				cipherText = Decrypt(value.Substring(0, separator), privateKey) + cipherText;
				value = value.Remove(0, separator + code.Length);
				separator = value.IndexOf(code);
			}
			return cipherText;
		}

		//parse part of data that have keys
		private static void ParseKeys(string value, ref string key,ref string IV, string privateKey)
		{
			key = DeCipher(ref value, privateKey, "<Fluffy_Cats>");
			IV = DeCipher(ref value, privateKey, "<Sleepy_Cats>");			
		}


		// decrypt message privateKey required
		public static string DecryptMessage(string data, string privateKey)
		{
			string decryptedMessage = null;
			using (AesManaged aesManager = new AesManaged())
			{
				string cipherKeys = null;
				string cipherText = ParseBackValues(data, ref cipherKeys);
				string tempKey = null, tempIV = null;
				ParseKeys(cipherKeys,ref tempKey,ref tempIV, privateKey);
				aesManager.Key = ConvertToByte(tempKey);
				aesManager.IV = ConvertToByte(tempIV);
				decryptedMessage = DecryptAES(cipherText, aesManager.Key, aesManager.IV);
			}
			return decryptedMessage;
		}
		
		//decrypte AES algo
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
	}
}
