using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day1Hash
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                var myInput = Console.ReadLine();
                string output = Encryptor.MakeSha256(myInput);
                Console.WriteLine(output);
            }

            // Step 1 Take user input
            // Step 2 Encrypt User input
            // Step 3 ???
            // Step 4 Profit
        }
    }
}
