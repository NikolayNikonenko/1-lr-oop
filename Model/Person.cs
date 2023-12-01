using _1_lr_oop.Model;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс Person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// имя персоны.
        /// </summary>
        public string Name;

        /// <summary>
        /// фамилия персоны.
        /// </summary>
        public string Surname;

        /// <summary>
        /// возраст персоны.
        /// </summary>
        public int Age;

        /// <summary>
        /// гендер персоны.
        /// </summary>
        public Gender Gender;

        /// <summary>
        /// информация о человеке.
        /// </summary>
        /// <returns>Информация о человеке.</returns>
        public string GetInfo()
        {
            return $"Perconname: {Name}, Sername: {Surname}," +
                $" Age: {Age}, Gender: {Gender}";
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name">имя.</param>
        /// <param name="surname">фамилия.</param>
        /// <param name="age">возраст.</param>
        /// <param name="gender">пол.</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }
    }
}