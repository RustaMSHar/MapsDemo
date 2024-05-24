using MapsDemo.Models;
using System.Text;

namespace MapsDemo.View
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();

            string appDataPath = FileSystem.AppDataDirectory;
            string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

            LoadNote(Path.Combine(appDataPath, randomFileName));
        }

        public string ItemId //itemID
        {
            set { LoadNote(value); }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.Note note)
            {
                note.Title = TitleEntry.Text;
                note.Text = TextEditor.Text;
                string noteContent = $"{note.Title}\n{note.Text}";
                File.WriteAllText(note.Filename, noteContent, Encoding.UTF8);
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e) // deleteclicked button
        {
            if (BindingContext is Models.Note note)
            {
                // Delete the file.
                if (File.Exists(note.Filename))
                    File.Delete(note.Filename);
            }

            await Shell.Current.GoToAsync("..");
        }

        private void LoadNote(string fileName)
        {
            Models.Note noteModel = new Models.Note();
            noteModel.Filename = fileName;

            if (File.Exists(fileName))
            {
                noteModel.Date = File.GetCreationTime(fileName);
                var noteContent = File.ReadAllText(fileName);
                var noteLines = noteContent.Split(new[] { '\n' }, 2);
                if (noteLines.Length > 1)
                {
                    noteModel.Title = noteLines[0];
                    noteModel.Text = noteLines[1];
                }
                else
                {
                    noteModel.Title = noteContent;
                    noteModel.Text = string.Empty;
                }
            }

            BindingContext = noteModel;
        }
    }
}
