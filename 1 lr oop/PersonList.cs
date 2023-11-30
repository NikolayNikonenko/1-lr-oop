namespace Model
{
    /// <summary>
    /// Лист персоны.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Список персон
        /// </summary>
        private List<Person> _people = new List<Person>();

        /// <summary>
        /// Добавление персоны.
        /// </summary>
        /// <param name="people">имя.</param>
        public void Add(Person person)
        {
            _people.Add(person);
        }

        /// <summary>
        /// Удаление списка персон.
        /// </summary>
        /// <param name="people">имя.</param>
        public void DeleteAll()
        {
            _people.Clear();
        }

        /// <summary>
        /// Удаление персоны по индексу.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="index"></param>
        public void DeleteByIndex(int index)
        {
            int countIndex = _people.Count - 1;

            if (countIndex < index)
            {
                throw new IndexOutOfRangeException($"Персоны с индексом" +
                    $" {index} нет в списке");
            }
            else
            {
                _people.RemoveAt(index);
            }
        }

        /// <summary>
        /// Удаление выбранной персоны по фамилии.
        /// </summary>
        /// <param name="people">имя.</param>
        /// <returns>список без выбранной персоны.</returns>
        public int DeleteBySurname(string surname)
        {
            // Удаляет персоны из списка по условию
            // и возвращает кол-во удалений.
            int count = _people.RemoveAll(s => s.Surname == surname);
            return count;
        }

        /// <summary>
        /// Искать персону по указанному индексу.
        /// </summary>
        /// <param name="people">имя.</param>
        /// <param name="index">соответствующий индекс.</param>
        public Person FindByIndex(int index)
        {
            int countIndex = _people.Count - 1;

            if (countIndex < index)
            {
                throw new IndexOutOfRangeException("Персоны с индексом " +
                    "{index} нет в списке");
            }
            else
            {
                return _people[index];
            }
        }

        /// <summary>
        /// Вернуть индекс персоны по фамилии, при наличии его в списке.
        /// </summary>
        /// <param name="people">фамиля.</param>
        /// <returns>индекс персоны.</returns>
        public int FindIndex(string surname)
        {
            int index = _people.FindIndex(s => s.Surname == surname);
            return index;
        }

        /// <summary>
        /// Колличество персон в списке.
        /// </summary>
        /// <param name="people">счетчик персон.</param>
        /// <returns>количество персон.</returns>
        public int CountElementsList()
        {
            return _people.Count;
        }
    }
}
