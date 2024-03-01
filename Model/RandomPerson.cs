namespace Model
{
    /// <summary>
    /// Класс для создания
    /// рандомного человека.
    /// </summary>
    public class RandomPerson
    {
        /// <summary>
        /// Создание рандомного человека.
        /// </summary>
        /// <returns>рандомная персона.</returns>
        public static Person GetRandomPerson()
        {
            //TODO: RSDN
            string[] menName =
                {
                    "Петр", "Дмитрий", "Александр", "Сергей",
                    "Алексей", "Михаил", "Артем", "Кирилл",
                };
            string[] womenName =
                {
                "Татьяна", "Алена", "Оксана", "Груня",
                "Светлана", "Елена", "Анна", "Виктория",
                };

            string[] menSurname =
                {
                "Абрамов", "Иванов", "Воробьев", "Арбузов",
                "Соловьев", "Калинин", "Чириков", "Дятлов",
                };
            string[] womenSurname =
                {
                "Синицына", "Соловьева", "Петухова",
                "Гусева", "Воробьева", "Малинина", "Дединсайдова", "Семченко",
                };

            Random random = new Random();

            Gender gender = (Gender)random.Next(2);
            //TODO: duplication
            int age = random.Next(1, 120);
            string name;
            string surname;

            if (gender == Gender.Male)
            {
                name = menName[new Random().Next(1, menName.Length)];
                surname = menSurname[new Random().Next(1, menSurname.Length)];
            }
            else
            {
                name = womenName[new Random().Next(1, womenName.Length)];
                surname = womenSurname[new Random().Next(1, womenSurname.Length)];
            }

            return new Person(name, surname, age, gender);
        }
    }
}