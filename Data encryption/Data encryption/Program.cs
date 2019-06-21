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
			string erere = "Hello my dear friend. 2323 ";
			Console.WriteLine(erere);
			string privateKey = DataEncryption.generatePrivateKey();
			string publicKey = DataEncryption.generatePublicKey(privateKey);
			string x1 = DataEncryption.EncryptMessage(erere, publicKey);
			Console.WriteLine(x1);

			string y1 = DataEncryption.DecryptMessage(x1, privateKey);
			Console.WriteLine(y1);

			y1 = Console.ReadLine();

		}
	}
}
