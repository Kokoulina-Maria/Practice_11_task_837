using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11_task_837
{
    class Program
    {
        public const int N = 11;
        static char[,] MakeMas(string s)
        {//функция, переписывающая строку в массив построчно
            char[,] mas = new char[N, N];
            int k = 0;//элемент строки
            for (int i=0; i<N; i++)
                for (int j=0; j<N; j++)
                {
                    mas[i, j] = s[k];
                    k++;
                }
            return mas;
        }

        static string Encoding(string text)
        {//функция, кодирующая текст
            char[,] mas = new char[N, N];
            mas = MakeMas(text);
            string cipher="";//закодированная строка
            int min = 0;//минимальный индекс для данного слоя
            int max = N - 1;//максимальный индекс для данного слоя
            do
            {
                //начинаем новый слой
                for (int i = min; i <= max; i++)//Перебираем элементы верхней строки данного слоя(слева направо, начиная с первого и заканчивая последним)
                    cipher = mas[min, i].ToString()+cipher;
                for (int i=min+1; i<=max; i++)//Перебираем элементы правого столбца данного слоя(сверху вниз, начиная со второго и заканчивя последним)
                    cipher = mas[min, i].ToString() + cipher;
                for (int i=max-1; i>=min; i--)//Перебираем элементы нижней строки данного слоя (справа налево, начиная с предпоследнего и заканчивая первым)
                    cipher = mas[min, i].ToString() + cipher;
                for (int i=max-1; i>=min+1; i--)//Перебираем элементы левого столбца данного слоя (снизу вверх, начиная с предпоследнего и заканчивая вторым)
                    cipher = mas[min, i].ToString() + cipher;
                //заканчиваем слой
                min++;//увеличиваем минимальный индекс для нового слоя
                max--;//уменьшаем максимальный индекс для нового слоя
            } while (cipher.Length != N * N);
            return cipher;
        }

        static void Main(string[] args)
        {
        }
    }
}
