using System.IO;
using System;

namespace TearDownDecrypt.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string a = "599Cc51887A8cb0C20F9CdE34cf9e0A535E5cAd1C26c7b562596ACC207Ae9A0bfB3E3161f31af5bEf1c2f064b3628174D83BF6E0739D9D6918fD9C2Eba02D5aD";
                string b = "0C3b676fe8d7188Cde022F71632830F36b98b181aD48Fed160006eA59";

                using (FileStream fin = new FileStream(args[0], FileMode.Open), fout = new FileStream(args[1], FileMode.Create))
                {
                    int dat = 0;
                    int i = 0;
                    while ((dat = fin.ReadByte()) != -1)
                    {
                        var d = (byte)dat ^ (byte)a[i % 128] ^ (byte)b[i % 57];
                        fout.WriteByte((byte)d);
                        i++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
