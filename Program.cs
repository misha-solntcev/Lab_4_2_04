using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Задан одномерный массив А[1..20]. Просуммировать 
  все неотрицательные элементы, стоящие на четных местах. */

namespace Lab_4_2_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[20];
            Random rand = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rand.Next(-20, 20);
                Console.Write(A[i] + " ");
            }
            Console.WriteLine("\n");

            // Классический способ.
            int sum = 0;
            for (int i = 0; i < A.Length; i++)
                if (A[i] > 0 && i % 2 == 0)
                    sum += A[i];
            Console.WriteLine($"Сумма = {sum}");

            // С помощью языка запросов Linq.
            var res = A.Where((x, i) => i % 2 == 0); // оставляем числа с четными индексами
            var result = (from x in res         // из новой выборки
                          where x > 0           // оставляем только числа > 0
                          select x).Sum();      // и находим их сумму.
            Console.WriteLine($"Сумма = {result}");

            // С помощью расширений Linq.
            Console.WriteLine($"Сумма = " +
                $"{A.Where((x, i) => x > 0 && i % 2 == 0).Sum()}");

            Console.ReadKey();
        }
    }
}
