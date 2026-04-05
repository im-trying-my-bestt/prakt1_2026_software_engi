using System;
using System.Runtime.CompilerServices;
namespace Практична_робота_1_Двійкові
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть перше двійкове число: ");
            string stra = Console.ReadLine();

            Console.Write("Введіть друге двійкове число: ");
            string strb = Console.ReadLine();
            
            int n = 7;
            if (stra.Length != n || strb.Length != n)
            {
                Console.WriteLine("Помилка: числа повинні мати 7 символів");
                return;
            }
            if (!IsBinary(stra) || !IsBinary(strb))
            {
                Console.WriteLine("Помилка: введені числа повинні містити тільки 0 і 1");
                return;
            }
            
            bool[] a = new bool[7];
            bool[] b = new bool[7];

            Console.WriteLine();
            Console.WriteLine($"Додаємо два числа у бінарному вигляді: \n {stra}\n+{strb}\n _______");
            string res = "";
            for (int i = 0; i < stra.Length; i++)
            {
                if (stra[i] == '1')
                    a[i] = true;
                if (strb[i] == '1')
                    b[i] = true;
            }
            bool beforoneone = false;
            for (int i = 6; i >= 0; i--)
            {
                if (!beforoneone)
                {
                    if (!a[i] && !b[i])
                        res += '0';
                    else if (a[i] && !b[i] || b[i] && !a[i])
                        res += "1";
                    else //if (a[i] && b[i])
                    {
                        res += "0";
                        beforoneone = true;
                    }
                }
                else //beforeonene true
                {

                    beforoneone = false;
                    if (a[i] && b[i] && i == 0)
                        res += "11";
                    else if (!a[i] && b[i] && i == 0 || a[i] && !b[i] && i == 0)
                        res += "01";
                    else if (!a[i] && !b[i])
                        res += '1';
                    else if (a[i] && !b[i] || b[i] && !a[i])
                    {
                        res += "0";
                        beforoneone = true;
                    }
                    else
                    {
                        res += "1";
                        beforoneone = true;
                    }
                }



            }
            //Console.WriteLine("Res before reverse:" + res);
            if (res.Length==7)
            res += " ";
            string trueres = "";
            for (int i = res.Length - 1; i >= 0; i--)
            {
                trueres += res[i];
                Console.Write(res[i]);
            }
            byte intstra = WriteNumTenNonReverseTest(stra);
            byte intstrb = WriteNumTenNonReverseTest(strb);
            
            Console.WriteLine($"\nУ десятковому вигляді:\n {intstra}\n+{intstrb}\n____\n {WriteNumTenNonReverseTest(trueres)}");
            
        }
        // Перевірка двійкового числа
        static bool IsBinary(string str)
        {
            foreach (char x in str)
                if (x != '0' && x != '1')
                    return false;
            return true;
        }
        static byte WriteNumTenNonReverseTest(string res)
        {
            byte intres = 0;
            for (int i = 0; i < res.Length; i++)
                if (res[i] != '0')
                    intres += Convert.ToByte(Math.Pow(2, res.Length-1-i));
            return intres;
        }
    }
}
