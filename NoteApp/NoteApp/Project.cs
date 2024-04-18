using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проекта, хранящий список всех заметок, созданных в приложении.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список всех заметок, созданных в приложении.
        /// </summary>
        private List<Note> _noteList = new List<Note>();
        /// <summary>
        /// Возвращает и задаёт список всех заметок в приложении.
        /// </summary>
        public List<Note> noteList
        {   
            get { return _noteList; }
            set { _noteList = noteList; }
        }
        /// <summary>
        /// Создаёт экземпляр класса Project.
        /// </summary>
        /// <param name="noteList"> Список всех заметок в приложении. </param>
        public Project(List<Note> noteList)
        {
            _noteList = noteList;
        }
    }
}
