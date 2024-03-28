using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс для описания взрослого.
    /// </summary>
    public class Adult : PersonBase
    {
       /// <summary>
       /// Минимальный возраст.
       /// </summary>
        public override int MinAge => 18;

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        public override int MaxAge => 120;

        /// <summary>
        /// Минимальный номер паспорта.
        /// </summary>
        public const int MinPassportNumber = 0000000001;

        /// <summary>
        /// Максимальный номер пасспорта.
        /// </summary>
        public const long MaxPassportNumber = 9999999999;

        /// <summary>
        /// Пасспорт.
        /// </summary>
        private uint _passport;

        /// <summary>
        /// Пара.
        /// </summary>
        private Adult? _partner;

        /// <summary>
        /// Задание пасспорта.
        /// </summary>
        public uint Passport
        {
            get
            {
                return _passport;
            }

            set
            {
                _passport = CheckPassport(value);
            }
        }

        /// <summary>
        /// Проверка номера паспорта.
        /// </summary>
        /// <param name="value">Принимаемый номер пасспрота.</param>
        /// <returns>Номер пасспорта.</returns>
        /// <exception cref="ArgumentException">Исключение в случае выхода за
        /// допустимый диапазон, при задании пасспорта.</exception>
        public uint CheckPassport(uint value)
        {
            if (value > MaxPassportNumber || value < MinPassportNumber)
            {
                throw new ArgumentException($"Введен некорректный номер пасспорта," +
                    $" введите номер в диапазоне от {MinPassportNumber} до {MaxPassportNumber}!");
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Задание семейного положения.
        /// </summary>
        public FamilyStatus FamilyStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Задание партнера.
        /// </summary>
        public Adult Partner
        {
            get
            {
                return _partner;
            }

            set
            {
                if (FamilyStatus == FamilyStatus.Married &&
                    value.FamilyStatus == FamilyStatus.Married)
                {
                    _partner = value;
                }
                else
                {
                    throw new ArgumentException("Проверьте статус партнера!");
                }
            }
        }

        /// <summary>
        /// Задание места работы.
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Ввод возраста для взрослого.
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
        /// Проверка возраста взрослого.
        /// </summary>
        /// <param name="age">Принимаемый возраст.</param>
        /// <returns>Возраст взрослого человека.</returns>
        /// <exception cref="ArgumentException">Исключение,
        /// в случае выхода возраста за допустимый диапазон.</exception>
        protected override int CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Возраст должен быть в диапазоне от {MinAge} до {MaxAge}!");
            }

            return age;
        }

        /// <summary>
        /// Метод получения информации.
        /// </summary>
        /// <returns>информацию о взрослой персоне.</returns>
        public override string GetInfo()
        {
            string infoAdultPerson = base.GetInfo() + $"\n Номер паспорта: {Passport}, " +
                $"\n Семейное положение: {FamilyStatus}, ";
            if (FamilyStatus == FamilyStatus.Married)
            {
                infoAdultPerson += $"Пара: {Partner.Name} {Partner.Surename}";
            }

            if (string.IsNullOrEmpty(Job))
            {
                infoAdultPerson += $"\n Работа: Безработный";
            }
            else
            {
                infoAdultPerson += $"\n Работа: {Job}";
            }

            return infoAdultPerson;
        }

        /// <summary>
        /// Метод присущий классу взрослый.
        /// </summary>
        public void GetAdultDrinking()
        {
            Console.WriteLine("Пьет пиво по выходным");
        }
    }
}
