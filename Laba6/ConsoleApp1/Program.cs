

using FractionExample;

namespace CatExample
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// 
    /// <summary>
    /// Главный метод программы.
    /// Создаёт кота и демонстрирует его возможности.
    /// </summary>
    /// 
    /// <param name="args">Аргументы командной строки</param>
    class Program
    {
        static void Main(string[] args)
        {
            // Cat cat = new Cat("Барсик");
            // Console.WriteLine(cat);
            // cat.Voice();
            // cat.Voice(5);

            // var cat1 = new Cat("Барсик");
            // var cat2 = new Cat("Соня");
            // var cat3 = new LazyCat();

            // var meowers = new List<Meowable>
            // {
            //     cat1,
            //     cat2,
            //     cat3
            // };

            // MeowAll.MakeAllMeow(meowers);

            // cat3.Meow();
            
            // MeowCounter m = new MeowCounter(cat); // создаём кота
            // Funs.MeowsCare(m);                    // передаём ссылку

            // Console.WriteLine($"Кот мяукал {m.GetMeowCount()} раз");


            // 1. Создание нескольких дробей
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = new Fraction(3, 4);

            // 2–3. Примеры использования всех операций
            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
            Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
            Console.WriteLine($"{f1} / {f2} = {f1 / f2}");

            Console.WriteLine($"{f1} + 2 = {f1 + 2}");
            Console.WriteLine($"{f2} * 3 = {f2 * 3}");

            // 4. Цепочка вызовов
            Fraction result = f1.Sum(f2).Div(f3).Minus(5);

            Console.WriteLine();
            Console.WriteLine($"f1.sum(f2).div(f3).minus(5) = {result}");
            

            Console.WriteLine();
            Console.WriteLine(f1 != f2);
            Fraction f4 = new Fraction(3, 4);
            Console.WriteLine(f3 != f4);

            
            Console.WriteLine();
            Console.WriteLine(f1.Clone());


            Console.WriteLine();
            Console.WriteLine(f1.GetDoubleValue());
            f1.SetEnumerator(20);
            Console.WriteLine(f1.GetDoubleValue()); // пересчитывается
        }

    }    
    
}
