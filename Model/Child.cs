using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс для описания ребенка.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Минимальный возраст ребенка.
        /// </summary>
        public override int MinAge => 0;

        /// <summary>
        /// Максимальный возраст ребенка.
        /// </summary>
        public override int MaxAge => 17;

        /// <summary>
        /// Детский сад или школа ребенка.
        /// </summary>
        private string? _schoolOrKindergarten;

        /// <summary>
        /// Ввод возраста ребенка.
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = CheckAge(value);
            }
        }

        /// <summary>
        /// Задание мамы ребенка.
        /// </summary>
        public Adult? Mother { get; set; }

        /// <summary>
        /// Задание папы ребенка.
        /// </summary>
        public Adult? Father { get; set; }

        /// <summary>
        /// Задание детского сада или школы ребенка.
        /// </summary>
        public string SchoolOrKindergarten
        {
            get
            {
                return _schoolOrKindergarten;
            }

            set
            {
                _schoolOrKindergarten = value;
            }
        }

        /// <summary>
        /// Метод проверки возраста ребенка.
        /// </summary>
        /// <param name="age">Принимаемый возраст ребенка.</param>
        /// <returns>Возраст ребенка.</returns>
        /// <exception cref="ArgumentException">Исключение, 
        /// в случае если возраст ребенка не входит в допустимый диапазон.</exception>
        protected override int CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Возраст должен быть в диапазоне от {MinAge} до {MaxAge}!");
            }

            return age;
        }

        /// <summary>
        /// Метод проверки на наличие родителя.
        /// </summary>
        /// <param name="parent">Родитель.</param>
        /// <param name="personAgeCategory">Срока.</param>
        /// <returns>Информацию о родителе.</returns>
        public static string CheckParents(Adult? parent, string personAgeCategory = "Mother")
        {
            if (parent != null)
            {
                return $"\n {personAgeCategory}: {parent.Name} {parent.Surename}";
            }
            else
            {
                return $"\n {personAgeCategory}: Нет информации о родителе";
            }
        }

        /// <summary>
        /// Метод получения информации о ребенке.
        /// </summary>
        /// <returns>Информацию о ребенке.</returns>
        public override string GetInfo()
        {
            string infoChildPerson = base.GetInfo() + CheckParents(Mother, "Мама") +
                CheckParents(Father, "Папа");
            infoChildPerson += "\n Образовательное учреждение: ";
            if (string.IsNullOrEmpty(SchoolOrKindergarten))
            {
                infoChildPerson += $" Ребенок не учится в школе и не ходит в детский сад";
            }
            else
            {
                infoChildPerson += $"\n {SchoolOrKindergarten}";
            }

            return infoChildPerson;
        }

        /// <summary>
        /// Метод присущий классу ребенок.
        /// </summary>
        public void GetChildDrinking()
        {
            Console.WriteLine("Пьет молоко перед сном");
        }
    }
}
