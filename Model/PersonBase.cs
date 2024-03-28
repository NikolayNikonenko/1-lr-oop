namespace Model
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Класс Person.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// имя персоны.
        /// </summary>
        protected string _name;

        /// <summary>
        /// фамилия персоны.
        /// </summary>
        protected string _surname;

        /// <summary>
        /// введенный возраст.
        /// </summary>
        protected int _age;

        /// <summary>
        /// Пол.
        /// </summary>
        protected Gender _gender;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        public abstract int MinAge { get; }

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        public abstract int MaxAge { get; }

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
                _name = ConvertRegister(
                CheckNameSurename(value));
                if (value != null)
                {
                    CheckLanguage(value);
                }
            }
        }

        /// <summary>
        /// Фамилия персоны.
        /// </summary>
        public string Surename
        {
            get
            {
                return _surname;
            }

            set
            {
                _surname = ConvertRegister(
                CheckNameSurename(value));
                if (_surname != null)
                {
                    CheckLanguage(value);
                }
            }
        }

        /// <summary>
        /// Возраст персоны.
        /// </summary>
        public abstract int Age
        {
            get;
            set;
        }

        /// <summary>
        /// Метод проверки на пустую строку.
        /// </summary>
        /// <param name="value">имя.</param>
        /// <param name="propertyName">Имя для обновления исключения. </param>
        /// <returns>Значение имени, если строка не пуста.</returns>
        /// <exception cref="ArgumentNullException">Выдает исключение,
        /// в если значение равно null.</exception>
        /// <exception cref="ArgumentException">Выдает исключение,
        /// в случае если пустой строки .</exception>
        public static string CheckString(string value)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException($" should not be null");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new System.ArgumentException($" should not be empty");
            }

            return value;
        }

        /// <summary>
        /// гендер персоны.
        /// </summary>
        public Gender Gender
        {
            get;
            set;
        }

        /// <summary>
        /// информация о человеке.
        /// </summary>
        /// <returns>Информация о человеке.</returns>
        public virtual string GetInfo()
        {
            //TODO: error+
            return $" Имя персоны: {Name}, Фамилия персоны: {Surename}," +
                $" Возраст персоны: {Age}, Пол персоны: {Gender}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBase"/> class.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="surname">Фамилия человека.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">пол.</param>
        protected PersonBase(string name, string surname, int age, Gender gender)
        {
            //TODO: to properties+
            Name = name;
            Surename = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBase"/> class.
        /// Дефолтный конструктор.
        /// </summary>
        protected PersonBase()
        {
        }

        /// <summary>
        /// Метод проверки возраста персоны.
        /// </summary>
        /// <param name="value">Принимаемый возраст персоны.</param>
        /// <returns>Возраст персоны.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выдает исключение ,
        /// в случае выхода возраста за диапазон.</exception>
        protected abstract int CheckAge(int value);

        /// <summary>
        /// Возможность ввода двойного имени или фамилии.
        /// </summary>
        /// <param name="nameSurname">Вводимая строка.</param>
        /// <returns>Имя и фамилия персоны с возможностью задания через -.</returns>
        /// <exception cref="FormatException">В случае,
        /// если слово написано на ином языке.</exception>
        public static string CheckNameSurename(string nameSurname)
        {
            Regex regex = new Regex(@"([^A-zА-я-]+)");
            if (regex.IsMatch(nameSurname))
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
        /// Метод преобразования регистра первой буквы в строке.
        /// </summary>
        /// <param name="nameSurename">вводимая строка.</param>
        /// <returns>Строка с преобразованной к верхнему регистру первой буквой.</returns>
        public static string ConvertRegister(string nameSurename)
        {
            nameSurename = nameSurename[0].ToString().ToUpper()
                + nameSurename.Substring(1);
            Regex doubleSurename = new Regex(@"[-]");
            if (doubleSurename.IsMatch(nameSurename))
            {
                string[] words = nameSurename.Split(new char[] { '-' });
                string firstSurename = words[0];
                string secondSurename = words[1];
                firstSurename = firstSurename[0].ToString().ToUpper() + firstSurename.Substring(1);
                secondSurename = secondSurename[0].ToString().ToUpper() + secondSurename.Substring(1);
                nameSurename = firstSurename + "-" + secondSurename;
            }

            return nameSurename;
        }

        /// <summary>
        /// Проверка на язык.
        /// </summary>
        /// <param name="nameSurename">Входная строка.</param>
        /// <returns>true если русский, false если английский.</returns>
        /// <exception cref="ArgumentException">если другой язык.</exception>
        public static bool CheckLanguage(string nameSurename)
        {
            Regex russian = new Regex(@"[а-яА-Я]");
            Regex english = new Regex(@"[a-zA-Z]");
            if (russian.IsMatch(nameSurename))
                {
                return true;
                }

            if (english.IsMatch(nameSurename))
            {
                return false;
            }
            else
            {
                throw new ArgumentException("Язык не распознан" +
                    "Разрешено вводить только английские или русские буквы");
            }
        }
    }
}
