namespace ConsoleApp
{
    using _1_lr_oop.Model;
    using Model;
    using System.Text.RegularExpressions;
    using _1_lr_oop.Model;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System;

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
            string truename = Person.ChecknamesSurenames(name);
            Console.Write($"Введите фамилию персоны: ");
            string surname =Console.ReadLine();
            string truesurename = Person.ChecknamesSurenames(surname);

            Console.Write($"Введите возраст персоны: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                throw new ArgumentException("Везраст должен быть числом");
            }

            int trueage = Person.CheckAge(age);

            Console.Write($"Введите пол человека (м - Мужской или ж - Женский): ");
            string pregen = Console.ReadLine();
            Gender gen = Gender.Male;
            if (pregen == "м")
            {
                gen = Gender.Male;
            }
            else if (pregen == "ж")
            {
                gen = Gender.Female;
            }
            else
            {
                 throw new ArgumentException("Введен некорректный пол, " +
                     "введите: м если мужской или: ж если женский");
            }

            return new Person(name, surname, age, gen);
        }
    }
}