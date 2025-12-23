

namespace CatExample
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <summary>
    /// Главный метод программы.
    /// Создаёт кота и демонстрирует его возможности.
    /// </summary>
    /// <param name="args">Аргументы командной строки</param>
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Барсик");
            Console.WriteLine(cat);
            cat.Voice();
            cat.Voice(3);

            Cat cat2 = new Cat("Соня");
            Console.WriteLine(cat2);
            cat2.Voice();
            cat2.Voice(10);
        }

    }    
}
