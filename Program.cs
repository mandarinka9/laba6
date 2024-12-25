using System;
using labaaa6;

namespace labaaa6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Meoweble barsik = new("Барсик");
            barsik.meow();
            barsik.meow(3);
            Console.WriteLine("Введите имя пумы: ");
            Puma pum = new(Console.ReadLine());
            MeowCount mt = new(pum);

            Console.WriteLine($"Сколько раз должна рычать пума?");
            mt.meow(int.Parse(Console.ReadLine()));

            Console.WriteLine($"Количество: {mt.Count}");




            Fraction fract1 = new(2, 3);
            Fraction fract2 = new(5);
            Fraction fract3 = new(2, 5);
            Fraction fract4 = new(3, 5);

            Console.WriteLine($"{fract1} * {fract2} = {fract1 * fract2}");
            Console.WriteLine($"{fract1} / {fract3} = {fract1 / fract3}");
            Console.WriteLine($"({fract1} + {fract2}) / {fract3} - {3} = {(fract1 + fract2) / fract3 - 3}");
            Console.WriteLine($"{fract1} - {fract3} = {fract1 - fract3}");
            Console.WriteLine($"{fract3} =? {fract1 * fract4}: {fract3 == fract1 * fract4}");
            Console.WriteLine($"{fract1 * fract3} =? {fract3 / fract2}: {fract1 * fract3 == fract3 / fract2}");


            Console.WriteLine("Введите числитель: ");
            int Num = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите знаменатель: ");
            int Denum = int.Parse(Console.ReadLine());

            Fraction fract = new(Num, Denum);
            FractionD fractd = new(fract);

            Console.WriteLine($"Значение дроби: {fractd.Value()}");

        }
    }
}