namespace labaaa6
{
    interface IFraction
    {
        public int Chislitel { set; }
        public int Znamenatel { set; }

        public double Value();
    }
    class FractionD : IFraction
    {
        private Fraction fraction; //хранит ссылку на экз класса Fraction
        private double? cachedValue; //кэширует зн дроби

        public FractionD(Fraction _fraction)
        {
            fraction = _fraction;
            cachedValue = null; // Инициализируем кэшированное значение при создании
        }

        public int Chislitel
        {
            set
            {
                fraction.Chislitel = value;
                cachedValue = null;
            }
        }

        public int Znamenatel
        {
            set
            {
                fraction.Znamenatel = value;
                cachedValue = null;
            }
        }

        public double Value()
        {
            // Обновляем кэшированное значение 
            return calcVal();
        }

        private double calcVal()
        {
            if (cachedValue == null)
            {
                cachedValue = fraction.Value(); // пересчитываем значение дроби только тогда, когда это необходимо
            }
            return cachedValue.Value; // возвращаем кэшированное значение
        }
    }

    class Fraction : IFraction, ICloneable
    {
        private int chislitel;
        private int znamenatel;
        public int Chislitel
        {
            get => chislitel;
            set
            {
                chislitel = znamenatel;
                simplify();
            }
        }
        public int Znamenatel
        {
            get => znamenatel; set
            {
                if (value == 0) throw new Exception("0 не может быть знаменателем");
                if (value < 0)
                {
                    chislitel *= -1;
                    value *= -1;
                }
                znamenatel = value;
                simplify();
            }
        }

        public Fraction(int _chislitel, int _znamenatel)
        {
            if (_znamenatel == 0)
                throw new Exception("0 не может быть знаменателем");
            chislitel = _chislitel;
            if (_znamenatel < 0)
            {
                chislitel *= -1;
                _znamenatel *= -1;
            }
            znamenatel = _znamenatel;
            simplify();
        }

        public Fraction(int a)
        {
            chislitel = a;
            znamenatel = 1;
        }

        private void simplify()
        {
            int nod = NOD(Math.Abs(chislitel), znamenatel);
            chislitel /= nod;
            znamenatel /= nod;
        }

        private static int NOD(int a, int b)// НОД
        {
            while (a != b && a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else b %= a;
            }

            return (a != 0) ? a : b; //если a != нулю, возвращается a, иначе возвращается b
        }

        private static int NOK(int a, int b)// НОК
        {
            return a * b / NOD(a, b);
        }

        private Fraction reverse()
        {
            if (chislitel == 0)
            {
                return this;
            }
            if (chislitel < 0)
            {
                return new Fraction(-znamenatel, chislitel);
            }

            return new Fraction(znamenatel, chislitel);
        }

        public static Fraction operator +(Fraction fract1, Fraction fract2)
        {
            return new Fraction(fract1.chislitel * NOK(fract1.znamenatel, fract2.znamenatel) / fract1.znamenatel + fract2.chislitel * NOK(fract1.znamenatel, fract2.znamenatel) / fract2.znamenatel, NOK(fract1.znamenatel, fract2.znamenatel));
        }
        public static Fraction operator *(Fraction fract1, Fraction fract2)
        {
            return new Fraction(fract1.chislitel * fract2.chislitel, fract1.znamenatel * fract2.znamenatel);
        }
        public static Fraction operator -(Fraction fract1, Fraction fract2)
        {
            return new Fraction(fract1.chislitel * NOK(fract1.znamenatel, fract2.znamenatel) / fract1.znamenatel - fract2.chislitel * NOK(fract1.znamenatel, fract2.znamenatel) / fract2.znamenatel, NOK(fract1.znamenatel, fract2.znamenatel));
        }
        public static Fraction operator /(Fraction fract1, Fraction fract2)
        {
            return fract1 * fract2.reverse();
        }

        public static Fraction operator -(Fraction fract)
        {
            return -1 * fract;
        }

        public static implicit operator Fraction(int a)
        {
            return new Fraction(a);
        }

        public static bool operator ==(Fraction fract1, Fraction fract2)
        {
            return (fract1.chislitel == fract2.chislitel) && (fract1.znamenatel == fract2.znamenatel);
        }
        public static bool operator !=(Fraction fract1, Fraction fract2)
        {
            return !(fract1 == fract2);
        }

        public object Clone()
        {
            return new Fraction(chislitel, znamenatel);
        }

        public double Value()
        {
            if (znamenatel == 0)
                throw new DivideByZeroException("Знаменатель не может быть равен нулю.");

            return (double)chislitel / znamenatel;
        }

        public override string ToString()
        {
            return $"{chislitel}/{znamenatel}";
        }
    }
}