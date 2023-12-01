using _1_lr_oop.Model;

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
                "Абрамов", "Иванов", "Воробьев", "Петухов",
                "Соловьев", "Калинин", "Чириков", "Дятлов",
                };
            string[] womenSurname =
                {
                "Синицына", "Соловьева", "Петухова",
                "Гусева", "Воробьева", "Малинина", "Дединсайдова", "Семченко",
                };

            Random random = new Random();

            Gender gender = (Gender)random.Next(2);
            int age = random.Next(1, 100);
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