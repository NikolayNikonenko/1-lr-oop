namespace ConsoleApp
{
    using Model;

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
            int count = people.CountElementsList;

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
            Person newPerson = new Person();
            var actionList = new List<Action>
            {
                () =>
                {
                    Console.WriteLine("Введите имя человека");
                    string name = Console.ReadLine();
                    newPerson.Name = Person.CheckString(name);
                },
                () =>
                {
                    Console.WriteLine("Введите фамилию человека");
                    string surename = Person.CheckString(Console.ReadLine());
                    if (Person.CheckLanguage(newPerson.Name) == Person.CheckLanguage(surename))
                    {
                        newPerson.Surename = surename;
                    }
                    else
                    {
                        throw new ArgumentException("Фамилия и имя должны быть написаны на " +
                            "одном языке, введите повторно!");
                    }
                },
                () =>
                {
                    Console.WriteLine("Введите Возраст человека");
                    bool result = ushort.TryParse(Console.ReadLine(), out ushort age);
                    if (result != true)
                    {
                        throw new ArgumentException("Возраст не должен быть отрицательным, " +
                            "и должен быть числом, введите повторно!");
                    }
                    else
                    {
                    newPerson.Age = age;
                    }
                },
                () =>
                {
                    Console.WriteLine("Введите пол человека(Мужской/Женский)");
                    string inputGender = Console.ReadLine().ToLower();
                    switch (inputGender)
                    {
                        case "м":
                        case "m":
                        {
                            newPerson.Gender = Gender.Male;
                            break;
                        }

                        case "ж":
                        case "f":
                        {
                            newPerson.Gender = Gender.Female;
                            break;
                        }

                        default:
                        {
                                throw new ArgumentOutOfRangeException("Введен некорректный пол, " +
                             "введите: м если мужской или: ж если женский");
                        }
                    }

                },
            };
            foreach (var action in actionList)
            {
                ActionHandler(action);
            }

            return newPerson;
        }

        /// <summary>
        /// Получение значений, введенных пользователемю.
        /// </summary>
        /// <param name="action">Действие.</param>
        private static void ActionHandler(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    var exceptionType = ex.GetType();
                    if (exceptionType == typeof(FormatException)
                        || exceptionType == typeof(ArgumentOutOfRangeException)
                        || exceptionType == typeof(ArgumentNullException)
                        || exceptionType == typeof(ArgumentException))
                    {
                        Console.WriteLine($"Возникло исключение {ex.Message}");
                    }
                    else
                    {
                        throw ex;
                    }
                }

                Console.WriteLine("\n!Ошибка ввода!\nПопробуйте снова:");
            }
        }
    }
}