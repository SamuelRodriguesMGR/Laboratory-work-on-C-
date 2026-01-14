

namespace CatExample
{
    

    public static class MeowAll
    {

        /// <summary>
        /// Метод, заставляющий насильно всех котов мяукать
        /// </summary>
        /// <param name="count">Список котов</param>
        public static void MakeAllMeow(IEnumerable<Meowable> meowers)
        {
            foreach (var meower in meowers)
            {
                meower.Meow();
            }
        }
    }



    /// <summary>
    /// метод, в которого передали кота
    /// </summary>
    public class MeowCounter : Meowable
    {
        
        /// <summary>
        /// Имя Кота
        /// </summary>
        private Cat _cat;

        private int MeowCount;

        /// <summary>
        /// Создаёт экземпляр кота с заданным именем.
        /// </summary>
        /// <param name="name">Имя кота</param>
        public MeowCounter(Cat cat)
        {
            _cat = cat;
        }

        /// <summary>
        /// Изменяем метод Meow, чтобы был подсчёт голосов
        /// </summary>
        public void Meow()
        {
            MeowCount++;
            _cat.Voice(); // кот реально мяукает)
        }
        public int GetMeowCount()
        {
            return MeowCount;
        }
    }
    
    /// <summary>
    /// Класс,
    /// </summary>
    public static class Funs
    {
        public static void MeowsCare(Meowable meowable)
        {
            // допустим, кот должен мяукнуть 5 раз
            for (int i = 0; i < 5; i++)
            {
                meowable.Meow();
            }
        }
    }


}