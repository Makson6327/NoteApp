using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NoteApp;

namespace NoteAppUI
{
    public partial class FormMain : Form
    {
        private Project project;
        public FormMain()
        {
            InitializeComponent();
            Project project = new Project(new List<Note>());
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Note note = new Note("Без названия", NoteCategory.Diff, "", DateTime.Now, DateTime.Now);
            FormCreate f = new FormCreate(note);
            f.ShowDialog();
            project.AddNote(note);
            listBoxNotes.Items.Add(note.noteName);
        }

        private string Category(NoteCategory category)
        {
            switch (category)
            {
                case NoteCategory.Work: return "Работа";
                case NoteCategory.Home: return "Дом";
                case NoteCategory.Health: return "Здоровье и спорт";
                case NoteCategory.People: return "Люди";
                case NoteCategory.Docs: return "Документы";
                case NoteCategory.Money: return "Финансы";
            }
            return "Разное";
        }

        private NoteCategory Category(string category)
        {
            switch (category)
            {
                case "Работа": return NoteCategory.Work;
                case "Дом": return NoteCategory.Home;
                case "Здоровье и спорт": return NoteCategory.Health;
                case "Люди": return NoteCategory.People;
                case "Документы": return NoteCategory.Docs;
                case "Финансы": return NoteCategory.Money;
            }
            return NoteCategory.Diff;
        }

        private void FormMain_FormClosing(object sender, EventArgs e)
        {
            ProjectManager.SaveToFile(project, "New Note");
            Close();
        }

        private void FormMain_About(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string[] categories = new string[8]
            {
                "Работа",
                "Дом",
                "Здоровье и спорт",
                "Люди",
                "Документы",
                "Финансы",
                "Разное",
                "Все"
            };
            comboBoxCategory.Items.AddRange(categories);
            comboBoxCategory.SelectedText = categories[7];
        }

        private void listBoxNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex != -1)
            {
                Note current = project.GetNotes().ElementAt(listBoxNotes.SelectedIndex);
                labelName.Text = current.noteName;
                labelCategory.Text = Category(current.noteCategory);
                dateTimePickerCreated.Value = current.creationTime;
                dateTimePickerUpdated.Value = current.lastUpdatedTime;
                textBoxText.Text = current.noteText;

                project.CurrentNote = current;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Note current = project.GetNotes().ElementAt(listBoxNotes.SelectedIndex);
            project.GetNotes().Remove(current);
            listBoxNotes.Items.Remove(current.noteName);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Note current = project.GetNotes().ElementAt(listBoxNotes.SelectedIndex);
            FormCreate f = new FormCreate(current);
            f.ShowDialog();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem.ToString() == "Все")
            {
                listBoxNotes.Items.Clear();
                foreach (Note note in project.GetNotes())
                {
                    listBoxNotes.Items.Add(note.noteName);
                }
            }
            else
            {
                var sortedNotes = 
                    project.SortNotes(Category(comboBoxCategory.SelectedItem.ToString()));
                listBoxNotes.Items.Clear();
                foreach (Note note in sortedNotes)
                {
                    listBoxNotes.Items.Add(note.noteName);
                }
            }
        }
    }
}
