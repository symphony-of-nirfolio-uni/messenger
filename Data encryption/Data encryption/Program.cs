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
			string erere = "";
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

			x = Console.ReadLine();
		}
	}
}
