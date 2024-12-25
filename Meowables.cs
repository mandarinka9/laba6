namespace labaaa6
{
    //Котики
    class Meoweble : Meowww
    {
        private readonly string name; //можно инициал только констр
        public string Name { get => name; } //св-во предостав доступ к имени для чтения

        public Meoweble(string _name) //экземпляр с заданным именем
        {
            name = _name;
        }

        public void meow(int amount = 1)
        {
            if (amount < 1)
                return;
            Console.Write($"{name}: ");
            for (int i = 1; i < amount; ++i)
            { Console.Write("мяу-"); }
            Console.WriteLine("мяу!");
        }
    }


    public interface Meowww
    {
        public void meow(int amount = 1); //объявл

        public static void meowAll(Meowww[] meowables)
        {
            foreach (Meowww meowable in meowables) //для кваждого объекта meow
                meowable.meow();
        }
    }


    class MeowCount : Meowww
    {
        private readonly Meowww meowObj; // ссылка на объект, реализующий IMeow
        private int callCount; // счетчик вызовов метода meow
        public int Count { get => callCount; } // свойство для доступа к счетчику

        public MeowCount(Meowww _meowObj)
        {
            meowObj = _meowObj; // инициализация ссылки на объект
            callCount = 0; // инициализация счетчика
        }

        public void meow(int amount)
        {
            if (amount < 1) // проверка на корректность количества
                return;
            callCount += amount;
            meowObj.meow(amount); // вызов метода meow у оборачиваемого объекта
        }
    }

    class Puma : Meowww
    {
        private readonly string name;
        public string Name { get => name; }

        public Puma(string _name)
        {
            name = _name;
        }

        public void meow(int count = 1)
        {
            if (count < 1)
                return;
            Console.Write($"{name}: ");
            for (int i = 1; i < count; ++i)
            { Console.Write("раррр-"); }
            Console.WriteLine("раррр!");

        }
    }
}
