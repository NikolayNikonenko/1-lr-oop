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
        private int _age;

        /// <summary>
        /// возраст персоны.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            
            set
            {
                if (CheckAge(value))
                {
                    _age=value;
                }
            }
        }   
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
            _age = age;
            Gender = gender;
        }
        /// <summary>
        /// Проверка на вхождение в диапазон
        /// </summary>
        /// <param name="age">принимаемый возраст.</param>
        /// <returns>сообщение об исключениях.</returns>
        public static bool CheckAge(int age)
        {
            bool flag = false;
                try
                {
                    if (age > 0 & age < 120)
                    {
                        flag = true;
                        return flag;
                    }
                    else
                    {
                        throw new Exception("Значение возраста должно быть в диапазоне от 0 до 120");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                return flag;
            }
            
        }
        /// <summary>
        /// проверка на ввод только русских или внглийских имен и фамилий
        /// </summary>
        /// <param name="name_surname">имя и фамилия</param>
        /// <returns> ссобщение в случае ошибки.</returns>
        public static bool ChecknamesSurenames(string name_surname)
        {
            {
                bool flag = false;
                {
                    
                    Regex regex = new Regex(@"[А-я,A-z-]+");
                    if (!regex.IsMatch(name_surname))
                    {
                        Console.WriteLine("Имя и фамилия должны содержать " +
                            "толко русские или английскик буквы");
                        return flag;
                    }
                    else
                    {
                        flag=true;
                        return flag;
                    }
                }
            }
        }
        /// <summary>
        /// Проверка регистра(недоделано)
        /// </summary>
        /// <param name="namesurename">принимаемые имя и фамилия.</param>
        /// <returns>имя и фамилия с учетом регистра</returns>
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