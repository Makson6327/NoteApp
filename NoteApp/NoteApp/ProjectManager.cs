using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteApp
{
    /// <summary>
    /// Класс управления проектами.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Сериализует список заметок.
        /// </summary>
        /// <param name="project"> Класс проекта. </param>
        public static void SaveToFile(Project project, string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"c:Users\Наталья\Documents\Note.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }
        /// <summary>
        /// Десериализует список заметок.
        /// </summary>
        /// <param name="project"> Класс проекта. </param>
        public static Project LoadFromFile(string filename)
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(@"c:Users\Наталья\Documents\Note.json"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }
            return project;
        }
    }
}
