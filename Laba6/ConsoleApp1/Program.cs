

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
            Cat cat = new Cat("Барсик");
            Console.WriteLine(cat);
            cat.Voice();
            cat.Voice(0);

            var cat1 = new Cat("Барсик");
            var cat2 = new Cat("Соня");
            var cat3 = new LazyCat();

            var meowers = new List<Meowable>
            {
                cat1,
                cat2,
                cat3
            };

            MeowAll.MakeAllMeow(meowers);

            cat3.Meow();
            
            MeowCounter m = new MeowCounter(cat); // создаём кота
            Funs.MeowsCare(m);                    // передаём ссылку

            Console.WriteLine($"Кот мяукал {m.GetMeowCount()} раз");

        }

    }    
    
}
