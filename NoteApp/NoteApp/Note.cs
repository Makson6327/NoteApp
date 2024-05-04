using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс заметки, хранящий информацию о названии, категории, тексте, времени создания и времени последнего редактирования заметки.
    /// </summary>
    public class Note: ICloneable
    {
        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _noteName;
        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _noteCategory;
        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _noteText;
        /// <summary>
        /// Время создания заметки.
        /// </summary>
        private DateTime _creationTime;
        /// <summary>
        /// Время последнего редактирования заметки.
        /// </summary>
        private DateTime _lastUpdatedTime;
        /// <summary>
        /// Возвращает и задаёт имя заметки.
        /// </summary>
        public string noteName
        {
            get { return _noteName; }
            set 
            {
                if (noteName.Length > 50)
                {
                    throw new ArgumentException("Длина строки должна быть меньше 50 букв.");
                }
                else
                    _noteName = noteName;
            }
        }
        /// <summary>
        /// Возвращает и задаёт категорию заметки.
        /// </summary>
        public NoteCategory noteCategory
        {
            get { return _noteCategory; }
            set { _noteCategory = noteCategory; }
        }
        /// <summary>
        /// Возвращает и задаёт текст заметки.
        /// </summary>
        public string noteText
        {
            get { return _noteText; }
            set { _noteText = noteText;  }
        }
        /// <summary>
        /// Возвращает и задаёт время создания заметки.
        /// </summary>
        public DateTime creationTime
        {
            get { return _creationTime; }
            set { _creationTime = creationTime; }
        }
        /// <summary>
        /// Возвращает и задаёт время последнего редактирования заметки.
        /// </summary>
        public DateTime lastUpdatedTime
        {
            get { return _lastUpdatedTime; }
            set { _lastUpdatedTime = lastUpdatedTime; }
        }
        /// <summary>
        /// Создаёт экземпляр класса Note.
        /// </summary>
        /// <param name="noteName"> Название заметки. </param>
        /// <param name="noteCategory"> Категория заметки. </param>
        /// <param name="noteText"> Текст заметки. </param>
        /// <param name="creationTime"> Время создания заметки. </param>
        /// <param name="lastUpdatedTime">Время последнего редактирования заметки. </param>
        public Note(string noteName, NoteCategory noteCategory, string noteText,
            DateTime creationTime, DateTime lastUpdatedTime)
        {
            _noteName = noteName;
            _noteCategory = noteCategory;
            _noteText = noteText;
            _creationTime = creationTime;
            _lastUpdatedTime = lastUpdatedTime;
        }
        /// <summary>
        /// Метод, выполняющий редактирование заметки.
        /// </summary>
        /// <param name="noteName"> Новое название заметки. </param>
        /// <param name="noteCategory"> Новая категория заметки. </param>
        /// <param name="noteText"> Новый текст заметки. </param>
        public void UpdateNote(string noteName, NoteCategory noteCategory, string noteText)
        {
            _noteName = noteName;
            _noteCategory = noteCategory;
            _noteText = noteText;
            _lastUpdatedTime = DateTime.Now;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
