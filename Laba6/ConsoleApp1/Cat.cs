using System;


namespace CatExample
{

    
    /// <summary>
    /// Класс, описывающий кота.
    /// </summary>
    public class Cat : Meowable
    {
        /// <summary>
        /// Имя кота.
        /// </summary>
        private string Name { get; }

        /// <summary>
        /// Создаёт экземпляр кота с заданным именем.
        /// </summary>
        /// <param name="name">Имя кота</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если имя пустое или состоит только из пробелов.
        /// </exception>
        public Cat(string name)
        {
            ValidateName(name);
            Name = name;
        }

        /// <summary>
        /// Реализация интерфейса
        /// </summary>
        public void Meow()
        {
            Voice();
        }

        /// <summary>
        /// Кот мяукает один раз.
        /// </summary>
        public void Voice()
        {
            Console.WriteLine($"{Name}: мяу!");
        }

        /// <summary>
        /// Кот мяукает заданное количество раз.
        /// </summary>
        /// 
        /// <param name="count">Количество мяуканий</param>
        /// 
        public void Voice(int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("*Но никто не пришёл");
                return;
            }

            Console.WriteLine(BuildMeowString(count));
        }

        /// <summary>
        /// Возвращает строковое представление кота.
        /// </summary>
        /// 
        /// <returns>Строка вида "кот: Имя"</returns>
        public override string ToString()
        {
            return $"кот: {Name}";
        }

        /// <summary>
        /// Проверяет корректность имени кота.
        /// </summary>
        /// <param name="name">Имя для проверки</param>
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя кота вот вообще не может быть пустым.");
            }
        }

        /// <summary>
        /// Формирует строку с мяуканьем заданной длины.
        /// </summary>
        /// <param name="count">Количество мяуканий</param>
        /// <returns>Строка с мяуканьем</returns>
        private string BuildMeowString(int count)
        {
            string result = $"{Name}: мяу";

            for (int i = 1; i < count; i++)
            {
                result += "-мяу";
            }

            return result + "!";
        }
    }
}
