using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_encryption
{
	class Program
	{
		static void Main(string[] args)
		{
			string erere = "Hello";

			Console.WriteLine(erere);
			Tuple<byte[], byte[], string> x = DataEncryption.EncryptMessage(erere, erere);
			Console.WriteLine(x.Item2);

			string y = DataEncryption.DecryptMessage(x.Item3, x.Item1, x.Item2, erere);
			Console.WriteLine(y);

			y = Console.ReadLine();


			/*
			int i = 0;
			while (i < 30)
			{
				erere += i.ToString();
				++i;
			}
			Console.WriteLine(erere.Length);
			Console.WriteLine('\n');
			string privateKey = DataEncryption.generatePrivateKey();
			string publicKey = DataEncryption.generatePublicKey(privateKey);
			
			Console.WriteLine(privateKey);
			Console.WriteLine(publicKey);
			Console.WriteLine(erere);
			string x = DataEncryption.Encrypt(erere, publicKey);
			Console.WriteLine(x);
			string y = DataEncryption.Decrypt(x, privateKey);
			Console.WriteLine(y);

			x = Console.ReadLine();*/
		}
	}
}
