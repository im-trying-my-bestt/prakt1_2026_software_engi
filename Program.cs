using System;
using System.Text;
namespace Практична_робота_1_Двійкові
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть перше двійкове число: ");
            string a = Console.ReadLine();

            Console.Write("Введіть друге двійкове число: ");
            string b = Console.ReadLine();
            
            int n = 7;
            if (a.Length != n || b.Length != n)
            {
                Console.WriteLine("Помилка: числа повинні мати 7 символів");
                return;
            }
            if (!IsBinary(a) || !IsBinary(b))
            {
                Console.WriteLine("Помилка: введені числа повинні містити тільки 0 і 1");
                return;
            }

            string res = AddBinary(a,b);


            byte inta = WriteNumDecim(a);
            byte intb= WriteNumDecim(b);

            Console.WriteLine($"\nДодаємо два числа у бінарному вигляді: \n {a}\n+{b}\n _______");
            if (res.Length==7)
                Console.Write(" ");
            Console.WriteLine($"{res}\nУ десятковому вигляді:\n {inta}\n+{intb}\n____\n {WriteNumDecim(res)}");
            
            
        }
        // Перевірка двійкового числа
        static bool IsBinary(string str)
        {
            foreach (char x in str)
                if (x != '0' && x != '1')
                    return false;
            return true;
        }
        static string AddBinary(string a, string b)
        {
            int beforeonon = 0;
            StringBuilder result = new StringBuilder();

            for (int i = a.Length - 1; i >= 0; i--)
            {
                int sum = (a[i] - '0') + (b[i] - '0') + beforeonon;

                result.Insert (0,sum % 2);
                beforeonon = sum / 2;
            }

            if (beforeonon > 0)
                result.Insert(0, beforeonon);

            return result.ToString();
        }
        static byte WriteNumDecim(string res)
        {
            byte intres = 0;
            for (int i = 0; i < res.Length; i++)
                if (res[i] != '0')
                    intres += Convert.ToByte(Math.Pow(2, res.Length-1-i));
            return intres;
        }
    }
}
