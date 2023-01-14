
namespace MindfulNote.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class EntryPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "entries.txt");
    public EntryPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.entries.txt";

        LoadEntry(Path.Combine(appDataPath, randomFileName));
    }

    //Save method
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Entry entry)
            File.WriteAllText(entry.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    //Delete method
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Entry entry)
        {
            // Delete the file.
            if (File.Exists(entry.Filename))
                File.Delete(entry.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    //Load Entry method
    private void LoadEntry(string fileName)
    {
        Models.Entry entryModel = new Models.Entry();
        entryModel.Filename = fileName;

        //Check if fileName exists
        if (File.Exists(fileName))
        {
            //Get date of creation
            entryModel.Date = File.GetCreationTime(fileName);
            //Read all fext in file
            entryModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = entryModel;
    }

    public string ItemId
    {
        set { LoadEntry(value); }
    }
}