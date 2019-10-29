using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Проект_ВойнаИмир
{
    class Program
    {
        private const string file_name = "voyna-i-mir-tom-1.txt";
        static void Main(string[] args)
        {
            var file = new FileInfo(file_name);
            if(!file.Exists)
            {
                Console.Write("Файла не существует");
                return;
            }
            Console.WriteLine("Размер файла {0}", file.Length);
            var words_dict = new Dictionary <string, int> ();
            using (var reader = new StreamReader(file_name,Encoding.UTF8))
        {
            while (!reader.EndOfStream)
            {
               var line = reader.ReadLine();
               if (line.Length == 0) continue;
               var words = line.Split(' '); //тип стринг - массив 
               foreach (var word in words)
               {
                   var w = word.Trim().Trim("/,-.?!][)(".ToCharArray()).ToLower();
                   if (w == null || w.Length == 0)
                   continue;
                   if (words_dict.ContainsKey(w))
                   words_dict [w]++;
                   else words_dict.Add(w,1);
               }
               foreach (var item in words_dict)
               {
                   Console.WriteLine("{0}-{1}",item.Key, item.Value);
               }
            }
        }
        }
        
    }
}
