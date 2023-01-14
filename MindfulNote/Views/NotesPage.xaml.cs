namespace MindfulNote.Views;

public partial class NotesPage : ContentPage
{
	public NotesPage()
	{
        InitializeComponent();

        BindingContext = new Models.Notes();
    }

    //On appearing method
    protected override void OnAppearing()
    {
        ((Models.Notes)BindingContext).LoadEntries();
    }
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(EntryPage));
    }
    private async void entriesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the entry model
            var entry = (Models.Entry)e.CurrentSelection[0];

            // Navigate to entry
            await Shell.Current.GoToAsync($"{nameof(EntryPage)}?{nameof(EntryPage.ItemId)}={entry.Filename}");

            entriesCollection.SelectedItem = null;
        }
    }
}