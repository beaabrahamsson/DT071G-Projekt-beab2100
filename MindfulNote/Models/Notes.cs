using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindfulNote.Models
{
    internal class Notes
    {
        public ObservableCollection<Entry> Entries { get; set; } = new ObservableCollection<Entry>();

        public Notes() =>
            LoadEntries();

        public void LoadEntries()
        {
            Entries.Clear();

            // Get the folder where the entries are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.entries.txt files.
            IEnumerable<Entry> entries = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.entries.txt")

                                        // Each file name is used to create a new Entry
                                        .Select(filename => new Entry()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of entries, order them by date
                                        .OrderBy(entry => entry.Date);

            // Add each entry into the ObservableCollection
            foreach (Entry entry in entries)
                Entries.Add(entry);
        }
    }
}
