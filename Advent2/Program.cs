using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Creds;
namespace Advent2
{

    class Program
    {

        static bool positionPattern(int[] pos, String line,string search) {
            bool val = false;
            char variable = search.ToCharArray()[0];
            char[] lineUpdate = line.ToCharArray();
            
            if (((lineUpdate.Length > pos[0]-1) && (lineUpdate[pos[0]-1] == variable)))
            {
                val = true;
            }
           
             if(((lineUpdate.Length  > pos[1]-1) && (lineUpdate[pos[1]-1] == variable)))
            {
                if (!val)
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }

            return val;
        }

        static bool overallPattern(int[] range, MatchCollection mat)
        {
            bool val = false;
            if ((mat.Count >= range[0]) && (mat.Count <= range[1]))
            {
                val = true;
                //Console.WriteLine(line);
            }
            return val;
        }


        static void Main(string[] args)
        {
            string[] currentFile = System.IO.File.ReadAllLines(@Creds.Creds.path + "input.txt");
            
            int firstTotalCount = 0;
            int secondTotalCount = 0;
            foreach (string line in currentFile)
            {
                string[] arr = line.Split(' ');
                arr[1] = arr[1].Replace(":", "");
                Regex pattern = new Regex(@arr[1], RegexOptions.Compiled | RegexOptions.IgnoreCase);
                string[] rangePreFiltered = arr[0].Split('-');
                int[] range = Array.ConvertAll(rangePreFiltered, int.Parse);
                MatchCollection mat = pattern.Matches(arr[2]);
                if (overallPattern(range,mat))
                {
                    firstTotalCount++;
                }
                if (positionPattern(range, arr[2],arr[1]))
                {
                    secondTotalCount++;
                }
            }
            Console.WriteLine(firstTotalCount);
            Console.WriteLine(secondTotalCount);
        }
    }
}
