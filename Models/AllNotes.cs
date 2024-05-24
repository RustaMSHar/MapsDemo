using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MapsDemo.Models;

namespace MapsDemo.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public AllNotes()
        {
            LoadNotes();
        }

        public void LoadNotes()
        {
            Notes.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Note> notes = Directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")
                                        .Select(filename => LoadNoteFromFile(filename))
                                        .OrderBy(note => note.Date);

            foreach (Note note in notes)
                Notes.Add(note);
        }

        private Note LoadNoteFromFile(string filename)
        {
            var noteContent = File.ReadAllText(filename);
            var noteLines = noteContent.Split(new[] { '\n' }, 2);
            var note = new Note
            {
                Filename = filename,
                Date = File.GetCreationTime(filename)
            };

            if (noteLines.Length > 1)
            {
                note.Title = noteLines[0];
                note.Text = noteLines[1];
            }
            else
            {
                note.Title = noteContent;
                note.Text = string.Empty;
            }

            return note;
        }
    }
}
