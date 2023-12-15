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
        public static string ChecknamesSurenames(string name_surname)
        {
            {
                while (true)
                {
                    
                    Regex regex = new Regex(@"[А-я,A-z-]+");
                    if (!regex.IsMatch(name_surname))
                    {
                        Console.WriteLine("Имя и фамилия должны содержать " +
                            "толко русские или английскик буквы");
                        continue;
                    }
                    else
                    {
                        return name_surname;
                    }
                }
            }
        }
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