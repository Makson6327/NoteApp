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
    public class ProjectManagerTest
    {
        [Test]
        public void TestSaveLoadProject()
        {
            List<Note> list = new List<Note>();
            Note note = new Note("С названием", NoteCategory.Work, "", DateTime.Now, DateTime.Now);
            list.Add(note);
            Project project = new Project(list);
            ProjectManager.SaveToFile(project, "Новая заметка");
            var loadedProject = ProjectManager.LoadFromFile("Новая заметка");
            ClassicAssert.AreEqual(loadedProject.GetNotes()[0].noteName, project.GetNotes()[0].noteName);
        }
    }
}
