namespace ConsoleApp
{
    using Model;

    /// <summary>
    /// Основная программа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Основная программа.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Каждый новый шаг выполняется по нажатию" +
                " любой клавиши клавиатуры.\nНажмите любую клавишу.");
            Console.ReadKey();

            // а.Создание программно двух списков персон,
            // в каждом из которых будет по три человека.
            Console.WriteLine("\n\t\tСоздание программно двух списков" +
                " персон, в каждом из которых будет по три человека.");
            Console.ReadKey();

            PersonList personList1 = new PersonList();
            PersonList personList2 = new PersonList();

            // Создание исходного списка персон 1
            for (int i = 0; i < 3; i++)
            {
                personList1.Add(RandomPerson.GetRandomPerson());
            }

            // Создание исходного списка персон 2
            for (int i = 0; i < 3; i++)
            {
                personList2.Add(RandomPerson.GetRandomPerson());
            }

            // b. Вывод содержимое каждого списка персон на экран
            Console.WriteLine("\n\t\tВывод списков на экран.");
            Console.ReadKey();

            // Печать исходного списка 1
            Console.WriteLine("Список №1:");
            ConsolePerson.Print(personList1);

            // Печать исходного списка 2
            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personList2);

            // c. Добавление нового человека в список 1
            Console.WriteLine("\n\t\tДобавление человека в список №1.");
            Console.ReadKey();
            personList1.Add(ConsolePerson.AddPersonWithConsole());

            // Печать списка 1
            Console.WriteLine("\nСписок №1 с добавлением:");
            ConsolePerson.Print(personList1);

            // d.Скопируйте второго человека из первого списка
            // в конец второго списка.
            // Покажите, что один и тот же человек
            // находится в обоих списках.
            Console.WriteLine();
            Console.WriteLine("\n\t\tКопирование 2-ого человека из" +
                " первого списка в конец второго списка.");
            Console.ReadKey();
            personList2.Add(personList1.FindByIndex(1));

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(personList1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personList2);

            // e.Удалите второго человека из первого списка. Покажите, что
            // удаление человека из первого списка
            // не привело к уничтожениютэтого же человека во втором списке.
            Console.WriteLine("\n\t\tУдаление второго человека" +
                " из первого списка.");
            Console.ReadKey();
            personList1.DeleteByIndex(1);

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(personList1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personList2);

            // f.Очистка второго списка.
            Console.WriteLine("\n\t\tОчищение второго списка.");
            Console.ReadKey();
            personList2.DeleteAll();

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(personList1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personList2);
            Console.ReadKey();
        }
    }
}