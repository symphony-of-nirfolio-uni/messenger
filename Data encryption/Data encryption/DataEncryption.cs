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
		public static Tuple<string, string> generatePrivateKey()
		{
			var RSA = new RSACryptoServiceProvider();
			string pr_key = RSA.ToXmlString(true);
			string pb_key = RSA.ToXmlString(false);
			return new Tuple<string, string> (pr_key, pb_key);
		}

		public static string Decrypt(string data, string key)
		{
			var RSA = new RSACryptoServiceProvider();
			var dataArray = data.Split(new char[] { ',' });
			byte[] dataByte = new byte[dataArray.Length];

			for (int i = 0; i < dataArray.Length; i++)
			{
				dataByte[i] = Convert.ToByte(dataArray[i]);
			}

			RSA.FromXmlString(key);
			var decryptedByte = RSA.Decrypt(dataByte, false);
			UnicodeEncoding encoding = new UnicodeEncoding();
			return encoding.GetString(decryptedByte);
		}

		public static string Encrypt(string data, string key)
		{
			var RSA = new RSACryptoServiceProvider();
			RSA.FromXmlString(key);
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
