using System;



namespace FractionExample
{
    
    /// <summary>
    /// Класс, описывающий дробь.
    /// </summary>
    public class Fraction : ICloneable
    {
        /// <summary>Числитель. </summary>
        private int Enumerator { get; set;}
        /// <summary>Знаменатель. </summary>
        private int Denominator { get; set;}

        /// <summary>Кэшированное значение. </summary>
        private double _cachedValue;
        /// <summary>Проверка на кэш. </summary>
        private bool _isCached = false;

        /// <summary>
        /// Создаёт экземпляр дроби с заданными числителем и знаменателем.
        /// </summary>
        /// <param name="enumerator">Числитель дроби</param>
        /// <param name="denominator">Знаменатель дроби</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если имя пустое или состоит только из пробелов.
        /// </exception>
        public Fraction(int enumerator, int denominator)
        {
            Validate(denominator);
            Normalize(enumerator, denominator);
        }

        /// <summary>
        /// Проверяет и нормализует дробь.
        /// </summary>
        private void Normalize(int e, int d)
        {
            // Знаменатель всегда положительный
            if (Denominator < 0)
            {
                e = -e;
                d = -d;
            }

            int gcd = GCD(Math.Abs(e), d);
            Enumerator = e / gcd;
            Denominator = d / gcd;
        }

        /// <summary>
        /// Наибольший общий делитель.
        /// </summary>
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        /// <summary>
        /// Проверяет корректность вводных значений.
        /// </summary>
        /// <param name="num">знаменатель для проверки</param>
        private void Validate(int denom)
        {
            if (denom == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю");
            }
        }

        /// <summary>
        /// Возвращает строковое представление дроби.
        /// </summary>
        /// 
        /// <returns>Строка вида “числитель/знаменатель”</returns>
        /// 
        public override string ToString()
        {
            return $"{Enumerator}/{Denominator}";
        }

        /// <summary>
        /// Возвращает сумму дробей.
        /// </summary>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Enumerator * b.Denominator + b.Enumerator * a.Denominator,
                a.Denominator * b.Denominator
            );
        }

         // ---------- Перегрузка операторов ---------- 

        /// <summary>
        /// Возвращает разность дробей.
        /// </summary>
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Enumerator * b.Denominator - b.Enumerator * a.Denominator,
                a.Denominator * b.Denominator
            );
        }

        /// <summary>
        /// Возвращает умножение дробей.
        /// </summary>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Enumerator * b.Enumerator,
                a.Denominator * b.Denominator
            );
        }

        /// <summary>
        /// Возвращает деление дробей.
        /// </summary>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Enumerator == 0)
                throw new DivideByZeroException("Деление на ноль.");

            return new Fraction(
                a.Enumerator * b.Denominator,
                a.Denominator * b.Enumerator
            );
        }

        // ---------- Операции с целым числом ----------

        /// <summary> Возвращает сложения дроби и целого числа. </summary>
        public static Fraction operator +(Fraction a, int b) => a + new Fraction(b, 1);
        /// <summary> Возвращает вычитания дроби и целого числа. </summary>
        public static Fraction operator -(Fraction a, int b) => a - new Fraction(b, 1);
        /// <summary> Возвращает умножение дроби и целого числа. </summary>
        public static Fraction operator *(Fraction a, int b) => a * new Fraction(b, 1);
        /// <summary> Возвращает деление дроби и целого числа. </summary>
        public static Fraction operator /(Fraction a, int b) => a / new Fraction(b, 1);

        // ---------- Методы для вызовов в задании ----------

        public Fraction Sum(Fraction other) => this + other;
        public Fraction Minus(Fraction other) => this - other;
        public Fraction Minus(int value) => this - value;
        public Fraction Mul(Fraction other) => this * other;
        public Fraction Div(Fraction other) => this / other;


        // ---------- 2 задание ----------

        
        /// <summary> Возвращает равны ли дроби. </summary>
        public static bool operator ==(Fraction? a, Fraction? b)
        {
            return  (a.Enumerator == b.Enumerator) && (a.Denominator == b.Denominator);
        }

        /// <summary> Возвращает не равны ли дроби. </summary>
        public static bool operator !=(Fraction? a, Fraction? b)
        {
            return !(a == b);
        }

        // ---------- 3 задание ----------

        /// <summary>
        /// Возвращает клон дроби.
        /// </summary>
        public object Clone()
        {
            return new Fraction(Enumerator, Denominator);
        }


        // ---------- 4 задание ----------

        /// <summary>
        /// Возвращает вещественное значение.
        /// </summary>
        public double GetDoubleValue()
        {
            if (!_isCached)
            {
                _cachedValue = (double)Enumerator / Denominator;
                _isCached = true;
            }
            
            return _cachedValue;
        }
        

        /// <summary>
        /// Изменяет числитель.
        /// </summary>
        public void SetEnumerator(int value)
        {
            Normalize(value, Denominator);
            _isCached = false;
        }


        /// <summary>
        /// Изменияет знаменатель.
        /// </summary>
        public void SetDenominator(int value)
        {
            Validate(value);
            Normalize(Enumerator, value);
            _isCached = false;
        }



    }
}