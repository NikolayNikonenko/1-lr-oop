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
        private List<Person> _peoples = new List<Person>();

        /// <summary>
        /// Добавление персоны.
        /// </summary>
        /// <param name="person">Персона.</param>
        public void Add(Person person)
        {
            _peoples.Add(person);
        }

        /// <summary>
        /// Удаление списка персон.
        /// </summary>
        /// <param name="people">имя.</param>
        public void DeleteAll()
        {
            _peoples.Clear();
        }

        /// <summary>
        /// Удаление элементов по индексу.
        /// </summary>
        /// <param name="index">индекс выбранной персоны.</param>
        public void DeleteByIndex(int index) => this._peoples.RemoveAt(index);

        /// <summary>
        /// Удаляет выбранный по фамилии элемент из списка.
        /// </summary>
        /// <param name="surname">Фамилия персоны.</param>
        /// <returns>Количетво удаленных элементов.</returns>
        public int DeleteBySurname(string surname)
        {
            int count = this._peoples.RemoveAll(s => s.Surename == surname);
            return count;
        }

        /// <summary>
        /// Поиск персоны по индексу.
        /// </summary>
        /// <param name="index">Индекс персоны.</param>
        /// <returns>Персону с заданным индексом.</returns>
        /// <exception cref="IndexOutOfRangeException">если отстутствует заданный индекс.</exception>
        public Person FindByIndex(int index)
        {
            int countIndex = _peoples.Count - 1;

            if (countIndex < index)
            {
                throw new IndexOutOfRangeException("Персоны с индексом " +
                    "{index} нет в списке");
            }
            else
            {
                return _peoples[index];
            }
        }

        /// <summary>
        /// Возвращает индекс персоны по фамилии
        /// </summary>
        /// <param name="surname">Фамилия.</param>
        /// <returns>Индекс персоны.</returns>
        public int FindIndex(string surname)
        {
            int index = _peoples.FindIndex(s => s.Surename == surname);
            return index;
        }

        /// <summary>
        /// Gets Колличество персон в списке.
        /// </summary>
        /// <param name="people">счетчик персон.</param>
        /// <returns>количество персон.</returns>
        public int CountElementsList => this._peoples.Count;
    }
}
