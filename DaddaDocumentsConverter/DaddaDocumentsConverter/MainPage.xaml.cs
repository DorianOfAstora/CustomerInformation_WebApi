namespace DaddaDocumentsConverter;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnFileSelectorClicked(object sender, EventArgs e)
    {
        PickOptions pickType = new PickOptions();
        var pickedFiles = PickAndShow(pickType);
        if (pickedFiles != null)
        {
            return;
        }

    }
    public async Task<IEnumerable<FileResult>> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickMultipleAsync(options);
            if (result != null)
            {
                SelectedFiles.Text = string.Empty;
                foreach (var file in result)
                {
                    if (SelectedFiles.Text == string.Empty)
                        SelectedFiles.Text += file.FileName;
                    else
                        SelectedFiles.Text += " - " + file.FileName;

                }
            }
            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
}

