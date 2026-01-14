namespace CatExample
{
    /// <summary>
    /// Произвольный класс, в которого передали написанный метод
    /// </summary>
    public class LazyCat : Meowable
    {
        public void Meow()
        {
            Console.WriteLine("Ленивый Кот: Мяяяу!");
        }
    }
}