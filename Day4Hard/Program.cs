using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day4Hard
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "bgvyzdsv";

            MD5 md5Hasher = MD5.Create();

            for (int g = 0; true; ++g)
            {
                string tt = input + g;
                // Преобразуем входную строку в массив байт и вычисляем хэш
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(tt));

                // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
                StringBuilder sBuilder = new StringBuilder();

                // Преобразуем каждый байт хэша в шестнадцатеричную строку
                for (int i = 0; i < data.Length; i++)
                {
                    //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
                    sBuilder.Append(data[i].ToString("x2"));
                }

                if (sBuilder.ToString().StartsWith("000000"))
                {
                    Console.WriteLine(tt);
                    Console.WriteLine(sBuilder.ToString());
                    break;
                }
            }

            Console.WriteLine("finish");
            Console.Read();
        }
    }
}
