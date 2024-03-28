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

            PersonList personList = new PersonList();

            for (int i = 0; i < 7; i++)
            {
                personList.Add(RandomPerson.GetRandomPersonAgeCategory());
            }

            // Печать списка
            Console.WriteLine("Список персон:");
            ConsolePerson.Print(personList);
            Console.WriteLine("\n\t Тип четвертого человека в списке:\n");
            Console.ReadKey();
            PersonBase person = personList.FindByIndex(3);

            switch (person)
            {
                case Adult adult:
                    {
                        Console.WriteLine("Это взрослый !");
                        adult.GetAdultDrinking();
                        break;
                    }

                case Child child:
                    {
                        Console.WriteLine("Это ребенок");
                        child.GetChildDrinking();
                        break;
                    }

                default:
                    break;
            }
        }
    }
}