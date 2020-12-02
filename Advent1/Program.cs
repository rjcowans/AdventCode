using System;
using Creds;
namespace Advent1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] currentFile = System.IO.File.ReadAllLines(@Creds.Creds.path + "input.txt");
            int[] s = Array.ConvertAll(currentFile, int.Parse);
            
            Console.WriteLine(s.Length);
            int totalFirst = 0;
            int totalSecond = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int check = 2020 - s[i];
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[j] == check)
                    {
                        totalFirst = s[i] * s[j];
                        Console.WriteLine(s[i] + ", " + s[j] + " , " + totalFirst);

                    }
                    else
                    {
                        int check2 = check - s[j];
                        if (check2 != 0){
                            for (int z = j + 1; z < s.Length; z++)
                            {
                                if (check2 == s[z]){
                                    totalSecond = s[i] * s[j] * s[z];
                                    Console.WriteLine(s[i] + ", " + s[j] + ", " + s[z] + " , " + totalSecond);

                                }
                            }
                        }
                        
                    }
                }
            }
        }

        

    }
        
}
