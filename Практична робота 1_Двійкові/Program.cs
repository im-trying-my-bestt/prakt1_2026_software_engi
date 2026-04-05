using System;
namespace Практична_робота_1_Двійкові
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stra = Console.ReadLine();
            string strb = Console.ReadLine();
            string res = "";
            if (stra.Length != 7 || strb.Length != 7)
            {
                Console.WriteLine("Щонайменше одне з заданих чисел не має 7 символів");
                return;
            }
            for (int i = 0; i < 7; i++)
            {
                if (stra[i] != '0' && strb[i]!='0')
                    if (stra[i] != '1' && strb[i] != '1')
                    {
                        Console.WriteLine("Щонайменше одне з заданих чисел не 1 або 0");
                        return;
                    }
            }
            bool[] a = new bool[7];
            bool[] b = new bool[7];

            Console.WriteLine();
            Console.WriteLine("Додаємо два числа");
            Console.WriteLine(stra);
            Console.WriteLine(strb);
            Console.WriteLine("_______");
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

            string trueres = "";
            for (int i = res.Length - 1; i >= 0; i--)
            {
                trueres += res[i];
                Console.Write(res[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Або у десятковому вигляді це:");
            Console.WriteLine(" "+WriteNumTenNonReverseTest(stra));
            Console.WriteLine("+"+WriteNumTenNonReverseTest(strb));
            Console.WriteLine("____");
            Console.WriteLine(" "+WriteNumTenNonReverseTest(trueres));
            
        }
        static double WriteNumTenNonReverseTest(string res)
        {
            double intres = 0;
            for (int i = 0; i < res.Length; i++)
                if (res[i] != '0')
                    intres += Math.Pow(2, res.Length-1-i);
            return intres;
        }
    }
}
