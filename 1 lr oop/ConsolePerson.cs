namespace ConsoleApp
{
    using _1_lr_oop.Model;
    using Model;
    using System.Text.RegularExpressions;
    using _1_lr_oop.Model;
    using System.Text.RegularExpressions;
    /// <summary>
    /// добавление и печать персоны через консоль.
    /// </summary>
    public static class ConsolePerson
    {
        /// <summary>
        /// Печать списка.
        /// </summary>
        /// <param name="people"> Список.</param>
        public static void Print(PersonList people)
        {
            int count = people.CountElementsList();

            for (int i = 0; i < count; i++)
            {
                Person pers = people.FindByIndex(i);
                Console.WriteLine(pers.GetInfo());
            }
        }

        /// <summary>
        /// Добавление персоны через консоль.
        /// </summary>
        /// <returns> Новая персона.</returns>
        public static Person AddPersonWithConsole()
        {
            Console.Write($"Введите имя персоны: ");
            string name = Console.ReadLine();
            name = Person.ChecknamesSurenames(name);

            Console.Write($"Введите фамилию персоны: ");
            string surname = Console.ReadLine();
            surname = Person.ChecknamesSurenames(surname);

            int age = 0;
            while (true)
            {
                Console.Write($"Введите возраст персоны: ");
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Возраст должен быть числом");
                    continue;
                }
                else if (!Person.CheckAge(age))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Write($"Введите пол человека (1 - Мужской или 0 - Женский): ");
            int pregen = Convert.ToInt32(Console.ReadLine());
            Gender gen = Gender.Male;
            switch (pregen)
            {
                case 1:
                    gen = Gender.Male;
                    break;
                case 0:
                    gen = Gender.Female;
                    break;
            }

            return new Person(name, surname, age, gen);
        }
    }
}