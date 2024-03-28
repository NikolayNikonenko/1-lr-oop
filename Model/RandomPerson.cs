namespace Model
{
    /// <summary>
    /// Класс для создания
    /// рандомного человека.
    /// </summary>
    public class RandomPerson
    {
        /// <summary>
        /// Рандомная персона.
        /// </summary>
        private static Random _random = new Random();

            /// <summary>
            /// Массив строк.
            /// </summary>
            private static string[] _menName =
                {
                    "Петр", "Дмитрий", "Александр", "Сергей",
                    "Алексей", "Михаил", "Артем", "Кирилл",
                };

            /// <summary>
            /// Массив строк женских имен.
            /// </summary>
            private static string[] _womenName =
                {
                    "Татьяна", "Алена", "Оксана", "Груня",
                    "Светлана", "Елена", "Анна", "Виктория",
                };

            /// <summary>
            /// Массив строк мужских фамилий.
            /// </summary>
            private static string[] _menSurname =
                {
                    "Абрамов", "Иванов", "Воробьев", "Арбузов",
                    "Соловьев", "Калинин", "Чириков", "Дятлов",
                };

            /// <summary>
            /// Массив строк женских фамилий.
            /// </summary>
            private static string[] _womenSurname =
                {
                    "Синицына", "Соловьева", "Петухова",
                    "Гусева", "Воробьева", "Малинина", "Дединсайдова", "Семченко",
                };

        /// <summary>
        /// Метод создания взрослого или ребенка.
        /// </summary>
        /// <returns>Взрослого или ребенка.</returns>
        public static PersonBase GetRandomPersonAgeCategory()
        {
            var personAgeCategory = _random.Next(0, 2);
            if (personAgeCategory > 0)
            {
                return GetRandomChild();
            }
            else
            {
                return GetRandomAdult();
            }
        }

        /// <summary>
        /// Создание рандомного человека.
        /// </summary>
        /// <param name="person">Персона.</param>
        /// <param name="gender">Пол.</param>
        public static void GetRandomPerson(PersonBase person, Gender gender = Gender.Deafault)
        {
            if (gender == Gender.Deafault)
            {
                person.Gender = (Gender)_random.Next(2);
            }
            else
            {
                person.Gender = gender;
            }

            if (person.Gender == Gender.Male)
            {
                person.Name = _menName[_random.Next(1, _menName.Length)];
                person.Surename = _menSurname[_random.Next(1, _menSurname.Length)];
            }
            else if (person.Gender == Gender.Female)
            {
                person.Name = _womenName[_random.Next(1, _womenName.Length)];
                person.Surename = _womenSurname[_random.Next(1, _womenSurname.Length)];
            }
        }

        /// <summary>
        /// Метод создания рандомного взрослого.
        /// </summary>
        /// <param name="status">Семейное положение.</param>
        /// <param name="partner">Партнер.</param>
        /// <param name="gender">Пол партнера.</param>
        /// <returns>Взрослый.</returns>
        public static Adult GetRandomAdult(
            FamilyStatus status = FamilyStatus.Single,
            Adult? partner = null, Gender gender = Gender.Deafault)
        {
            Adult randomAdult = new Adult();
            GetRandomPerson(randomAdult, gender);
            randomAdult.Age = _random.Next(randomAdult.MinAge, randomAdult.MaxAge);
            FamilyStatus familyStatus = (FamilyStatus)_random.Next(2);
            randomAdult.FamilyStatus = familyStatus;
            if (familyStatus == FamilyStatus.Married)
            {
                if (randomAdult.Gender == Gender.Male)
                {
                    randomAdult.Partner = GetRandomAdult(FamilyStatus.Married, randomAdult, Gender.Female);
                }
                else
                {
                    randomAdult.Partner = GetRandomAdult(FamilyStatus.Married, randomAdult, Gender.Male);
                }
            }
            else
            {
                randomAdult.FamilyStatus = status;
            }

            string[] job = {"Архитектор", "Программист", "Системный администратор",
                "Предприниматель", "Дворник", "Врач", "Преродаватель" };
            var getRandomJob = _random.Next(0, 4);
            if (getRandomJob > 0)
            {
                randomAdult.Job = job[_random.Next(0, job.Length)];
            }

            var passport = (uint)_random.Next(
                Adult.MinPassportNumber,
                unchecked((int)Adult.MaxPassportNumber));
            randomAdult.Passport = passport;
            return randomAdult;
        }

        /// <summary>
        /// Метод создания рандомного ребенка.
        /// </summary>
        /// <returns>Ребенок.</returns>
        public static Child GetRandomChild()
        {
            Child randomChild = new Child();
            GetRandomPerson(randomChild);
            randomChild.Age = _random.Next(randomChild.MinAge, randomChild.MaxAge);
            var mother = _random.Next(0, 4);
            if (mother > 0)
            {
                randomChild.Mother = GetRandomAdult(FamilyStatus.Married, randomChild.Father, Gender.Female);
            }

            var father = _random.Next(0, 4);
            if (father > 0)
            {
                randomChild.Father = GetRandomAdult(FamilyStatus.Married, randomChild.Father, Gender.Male);
            }

            string[] kindergarten = {"Детский сад Солнышко", "Детский сад Ручеек",
                "Детский сад Облачко", "Детский сад Звездочка"};
            string[] school = { "МБОУ СОШ №1", "МБОУ СОШ №2", "Гимназия №3", "Лицей им. Баумана" };
            var schoolOrKindergarten = _random.Next(0, 4);
            if (schoolOrKindergarten > 0)
            {
                if (randomChild.Age < 7)
                {
                    randomChild.SchoolOrKindergarten = kindergarten[_random.Next(1, kindergarten.Length)];
                }
                else
                {
                    randomChild.SchoolOrKindergarten = school[_random.Next(1, school.Length)];
                }
            }

            return randomChild;
        }
    }
}