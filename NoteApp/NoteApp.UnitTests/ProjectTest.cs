using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Compatibility;
using NoteApp;
using NUnit.Framework.Legacy;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        [Test]
        public void TestNotes()
        {
            Note note = new Note("С названием", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            List<Note> list = new List<Note> { note };
            Project project = new Project(list);
            var stillThatList = project.GetNotes();
            ClassicAssert.AreEqual(list, stillThatList);
        }

        [Test]
        public void TestAddNote()
        {
            Note note = new Note("С названием", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            List<Note> list = new List<Note> { note };
            Project project = new Project(list);
            Note newNote = new Note("С другим названием", 
                NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            project.AddNote(newNote);
            ClassicAssert.AreEqual(project.GetNotes()[1], newNote);
        }

        [Test]
        public void TestSortNotes1()
        {
            Note note = new Note("С названием", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            note.lastUpdatedTime = (new DateTime(2024, 1, 1, 0, 0, 0));
            Note newNote = new Note("С другим названием",
                NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            newNote.lastUpdatedTime = (new DateTime(2023, 1, 1, 0, 0, 0));
            List<Note> list = new List<Note> { newNote, note };
            Project project = new Project(list);
            List<Note> correctList = new List<Note> { note, newNote };
            ClassicAssert.AreEqual(project.SortNotes(NoteCategory.Diff), correctList);
        }

        [Test]
        public void TestSortNotes2()
        {
            Note note = new Note("С названием", NoteCategory.Work, "", DateTime.Now, DateTime.Now);
            note.lastUpdatedTime = (new DateTime(2024, 1, 1, 0, 0, 0));
            Note newNote = new Note("С другим названием",
                NoteCategory.Home, "", DateTime.Now, DateTime.Now);
            newNote.lastUpdatedTime = (new DateTime(2023, 1, 1, 0, 0, 0));
            List<Note> incorrectList = new List<Note> { newNote, note };
            Project project = new Project(incorrectList);
            List<Note> correctList = new List<Note> { note };
            ClassicAssert.AreEqual(incorrectList, project.SortNotes(NoteCategory.Work));
        }

        [Test]
        public void TestSortNotes3()
        {
            List<Note> voidList = new List<Note>();
            Project project = new Project(voidList);
            ClassicAssert.AreEqual(project.SortNotes(NoteCategory.Work), voidList);
        }
    }
}
