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
    public class NoteTest
    {
        [Test]
        public void TestSetName_Incorrect_50()
        {
            Note note = new Note("", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            bool wasItThrow = false;
            try
            {
                note.noteName = "This note name has exectly 54 letters including spaces";
            }
            catch(ArgumentException)
            {
                wasItThrow = true;
            }
            ClassicAssert.AreEqual(wasItThrow, true);
        }

        [Test]
        public void TestSetName_Null()
        {
            Note note = new Note("", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            ClassicAssert.AreEqual(note.noteName, "Без названия");
        }

        [Test]
        public void TestSetName()
        {
            Note note = new Note("С названием", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            ClassicAssert.AreEqual(note.noteName, "С названием");
        }

        [Test]
        public void TestSetCategory()
        {
            Note note = new Note("С названием", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            ClassicAssert.AreEqual(note.noteCategory, NoteCategory.Diff);
        }

        [Test]
        public void TestSetText()
        {
            Note note = new Note("С названием", NoteCategory.Diff, 
                "Этот текст содержит фактическую ошибку", DateTime.Now, DateTime.Now);
            ClassicAssert.AreEqual(note.noteText, "Этот текст содержит фактическую ошибку");
        }

        [Test]
        public void TestSetCreationTime()
        {
            Note note = new Note("С названием", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            ClassicAssert.AreEqual(note.creationTime, DateTime.Now);
        }

        [Test]
        public void TestSetUpdatedTime()
        {
            Note note = new Note("С названием", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            ClassicAssert.AreEqual(note.lastUpdatedTime, DateTime.Now);
        }
    }
}
