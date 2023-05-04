using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_9_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();

            numberReader.NumberEnteredEvent += ShowNumber;

            try
            {
                numberReader.Read();
            }

            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение");
            }
            Console.ReadKey();
        }
        static void ShowNumber(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введено значение: 1");

                    Console.WriteLine("Введите 5 имен");

                    string[] names_up = new string[5];

                    for (int i = 0; i < names_up.Length; i++)
                    {
                        names_up[i] = Console.ReadLine();

                    }
                    Array.Sort(names_up);

                    foreach (var item in names_up)
                    {
                        Console.WriteLine(item);
                    }                    

                    break;

                case 2:
                    Console.WriteLine("Введено значение: 2");
                    
                    Console.WriteLine("Введите 5 имен");
                    string[] names_down = new string[5];
                    for (int i = 0; i < names_down.Length; i++)
                    {
                        names_down[i] = Console.ReadLine();

                    }
                    Array.Sort(names_down);

                    Array.Reverse(names_down);

                    foreach (var item in names_down)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            }
        }
    }
    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);

        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();

            Console.WriteLine("Введите значение: 1 или 2");

            int number = int.Parse(Console.ReadLine());

            if (number != 1 && number != 2)
            {
                throw new FormatException();
            }
            NumberEntered(number);
        }
        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
}
