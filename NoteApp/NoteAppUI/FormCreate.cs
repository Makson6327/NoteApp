using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class FormCreate : Form
    {
        private Note remotenote;
        public FormCreate(Note note)
        {
            InitializeComponent();
            remotenote = note;
        }

        private string[] categories = new string[7]
        {
            "Работа",
            "Дом",
            "Здоровье и спорт",
            "Люди",
            "Документы",
            "Финансы",
            "Разное"
        };

        private void FormCreate_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.AddRange(categories);

            textBoxName.Text = remotenote.noteName;
            comboBoxCategory.SelectedIndex = ((int)remotenote.noteCategory);
            textBoxText.Text = remotenote.noteText;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            remotenote.noteName = textBoxName.Text;
            remotenote.noteCategory = Category(comboBoxCategory.Text);
            remotenote.noteText = textBoxText.Text;

            Close();
        }
    }
}
