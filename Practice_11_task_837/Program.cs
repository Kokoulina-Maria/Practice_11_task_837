using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11_task_837
{
    class Program
    {
        public const int N = 11;//размерность массива, можно поменять, если захотеть. Просто по условию символов в строке 121

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

        static string MakeString(char[,] mas)
        {//функция, переписывающая массив в строку построчно
            string text="";
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    text = text + mas[i, j].ToString();
            return text;
        }

        static string Encoding(string text)
        {//функция, шифрующая текст. Элементы перебираются внутри массива не изнутри, а снаружи, просто записываются не в конец, а в начало строки
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
                    cipher = mas[i, max].ToString() + cipher;
                for (int i=max-1; i>=min; i--)//Перебираем элементы нижней строки данного слоя (справа налево, начиная с предпоследнего и заканчивая первым)
                    cipher = mas[max, i].ToString() + cipher;
                for (int i=max-1; i>=min+1; i--)//Перебираем элементы левого столбца данного слоя (снизу вверх, начиная с предпоследнего и заканчивая вторым)
                    cipher = mas[i, min].ToString() + cipher;
                //заканчиваем слой
                min++;//увеличиваем минимальный индекс для нового слоя
                max--;//уменьшаем максимальный индекс для нового слоя
            } while (cipher.Length != N * N);
            return cipher;
        }

        static string Decoding(string cipher)
        {//функция, расшифровывающая текст. Элементы записываются в массив не изнутри, а снаружи, просто читаются не с начала, а с конца строки
            char[,] mas = new char[N, N];
            int min = 0;//минимальный индекс для данного слоя
            int max = N - 1;//максимальный индекс для данного слоя
            int s = N * N - 1;//номер элемента зашифрованной строки
            do
            {
                //начинаем заполнять новый слой массива
                for (int i = min; i <= max; i++)//Перебираем элементы верхней строки данного слоя(слева направо, начиная с первого и заканчивая последним)
                {
                    mas[min, i] = cipher[s];
                    s--;
                }
                for (int i = min + 1; i <= max; i++)//Перебираем элементы правого столбца данного слоя(сверху вниз, начиная со второго и заканчивя последним)
                {
                    mas[i, max] = cipher[s];
                    s--;
                }
                for (int i = max - 1; i >= min; i--)//Перебираем элементы нижней строки данного слоя (справа налево, начиная с предпоследнего и заканчивая первым)
                {
                    mas[max, i] = cipher[s];
                    s--;
                }
                for (int i = max - 1; i >= min + 1; i--)//Перебираем элементы левого столбца данного слоя (снизу вверх, начиная с предпоследнего и заканчивая вторым)
                {
                    mas[i, min] = cipher[s];
                    s--;
                }
                //заканчиваем заполнять слой
                min++;//увеличиваем минимальный индекс для нового слоя
                max--;//уменьшаем максимальный индекс для нового слоя
            } while (s != 0);
            string text = MakeString(mas);
            return text;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Шифруем и расшифровываем строку");
            do
            {
                string s="";//введеная пользователем строка
                Console.WriteLine("Введите строку, состоящую из "+N*N+" элементов: ");
                do
                {
                    s = Console.ReadLine();
                } while (s.Length < N * N);

                string line = "";//строка, с которой будет проводиться дальнейшая работа
                for (int i=0; i<N*N; i++)//берем только первые 121 элемент из введеной строки
                {
                    line = line + s[i];
                }
                Console.WriteLine("1 - Расшифровать данный текст");
                Console.WriteLine("2 - Расшифровать данный текст");
                
            } while (true);
        }
    }
}
