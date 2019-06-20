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
			Tuple<string, string> keys = DataEncryption.generatePrivateKey();

			Console.WriteLine(keys.Item1);
			Console.WriteLine(keys.Item2);
			Console.WriteLine(erere);
			string x = DataEncryption.Encrypt(erere, keys.Item2);
			Console.WriteLine(x);
			string y = DataEncryption.Decrypt(x, keys.Item1);
			Console.WriteLine(y);


			Console.ReadKey();
		}
	}
}
