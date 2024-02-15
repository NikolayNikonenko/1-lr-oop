using _1_lr_oop.Model;
using System.Linq.Expressions;
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
        private string _name;

        /// <summary>
        /// фамилия персоны.
        /// </summary>
        private string _surname;

        /// <summary>
        /// введенный возраст.
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        private const int _min = 0;

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        private const int _max = 120;

        /// <summary>
        /// возраст персоны.
        /// </summary>

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = ChecString(value, nameof(Name));
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _surname = ChecString(value, nameof(Name));
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                CheckAge(value);
            }
        }

        /// <summary>
        /// Метод проверки на пустую строку.
        /// </summary>
        /// <param name="value">имя.</param>
        /// <param name="propertyName">Имя для обновления исключения. </param>
        /// <returns>Значение имени, если строка не пуста.</returns>
        /// <exception cref="System.ArgumentNullException">Выдает исключение в случае незаданного значения.</exception>
        /// <exception cref="System.ArgumentException">Выдает исключение в случае пустого значения.</exception>
        private string ChecString(string value, string propertyName)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException($"{propertyName} should not be null");
            }

            if (value == string.Empty)
            {
                throw new System.ArgumentException($"{propertyName} should not be empty");
            }

            return value;
        }

        /// <summary>
        /// гендер персоны.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// информация о человеке.
        /// </summary>
        /// <returns>Информация о человеке.</returns>
        public string GetInfo()
        {
            return $"Perconname: {this._name}, Sername: {this._surname}," +
                $" Age: {this.Age}, Gender: {this.Gender}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="surname">Фамилия человека.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">пол.</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            this._age = age;
            this._gender = gender;
        }

        /// <summary>
        /// Метод проверки возраста персоны.
        /// </summary>
        /// <param name="value">Принимаемый возраст персоны.</param>
        /// <returns>Возраст персоны.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выдает исключение в случае выхода возраста за диапазон.</exception>
        public static int CheckAge(int value)
        {
            if (value > _max || value < _min)
            {
                throw new ArgumentOutOfRangeException("Введен некорректный возраст," +
                    $"введите возраст от {_min} до {_max} лет");
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Проверка на ввод только русских или английских имен и фамилий.
        /// </summary>
        /// <param name="nameSurname">Имя и фамилия персоны</param>
        /// <returns>Имя и фамилия персоны.</returns>
        /// <exception cref="FormatException">Выдает исключение на содержание букв одного языка.</exception>
        public static string ChecknamesSurenames(string nameSurname)
        {
            Regex regex = new Regex(@"[А-я,A-z-]+");
            if (!regex.IsMatch(nameSurname))
            {
                throw new FormatException("Введенное слово не распозноно," +
                    "проверьте правильность введенного слова и введите повторно");
            }
            else
            {
                return nameSurname;
            }
        }

        /// <summary>
        /// Проверка регистра.
        /// </summary>
        /// <param name="namesurename">Принимаемые имя и фамилия.</param>
        /// <returns>Имя и фамилия с учетом регистра.</returns>
        public static string CheckRegister(string namesurename)
        {
            Regex checkregex = new Regex(@"(\w)");
            MatchCollection match = checkregex.Matches(namesurename);
            foreach (Match i in match)
            {
                Console.WriteLine(i);
                return i.Value;
            }

            return namesurename;
        }
    }
}
