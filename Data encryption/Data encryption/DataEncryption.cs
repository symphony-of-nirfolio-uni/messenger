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
		public static string Decrypt(string data, string privateKey)
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
		public static string Encrypt(string data, string publicKey)
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
	}
}
