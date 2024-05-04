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
        private Note _currentNote;

        public Note CurrentNote
        {
            get { return _currentNote; }
            set { _currentNote = value; }
        }

        private static int CompareNotes(Note note1, Note note2)
        {
            return note2.lastUpdatedTime.CompareTo(note1.lastUpdatedTime);
        }

        public void AddNote(Note note)
        {
            _noteList.Add(note);
        }

        public List<Note> SortNotes(NoteCategory category)
        {
            var notes = new List<Note>();
            foreach(Note note in _noteList)
            {
                if (note.noteCategory == category)
                {
                    notes.Add(note);
                }
            }
            if (notes.Count == 0)
            {
                return notes;
            }

            notes.Sort(CompareNotes);
            return notes;
        }

        /// <summary>
        /// Возвращает и задаёт список всех заметок в приложении.
        /// </summary>
        public List<Note> GetNotes()
        {   
            return _noteList;
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
