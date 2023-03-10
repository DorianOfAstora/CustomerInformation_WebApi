using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.IO;

namespace DaddaConverter
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertPage : ContentPage
    {

        public ConvertPage()
        {

            Title = "DaddaConverter"; // Imposta il titolo della pagina principale
        }
        private async void ConvertButton_Clicked(object sender, EventArgs e)
        {
            // Ottiene il percorso del file di input dal'entry box
            string inputFilePath = InputFileEntry.Text;

            // Ottiene il formato di output dal picker
            string outputFormat = OutputFormatPicker.SelectedItem.ToString();

            // Verifica che il file di input esista
            if (!File.Exists(inputFilePath))
            {
                await DisplayAlert("Errore", "Il file di input non esiste", "OK");
                return;
            }

            // Verifica che il formato di output sia valido
            if (string.IsNullOrEmpty(outputFormat))
            {
                await DisplayAlert("Errore", "Seleziona il formato di output", "OK");
                return;
            }

            // Converte il file di input nel formato specificato
            string outputFilePath = ConvertFile(inputFilePath, outputFormat);

            // Mostra un messaggio di conferma e il percorso del file di output
            await DisplayAlert("Conversazione completata", $"Il file è stato convertito con successo e salvato come {outputFormat} in {outputFilePath}", "OK");
        }

        private string ConvertFile(string inputFilePath, string outputFormat)
        {
            // Qui andrebbe la logica per la conversione del file
            // In questo esempio, il file di output viene semplicemente rinominato con l'estensione specificata
            string outputFilePath = Path.ChangeExtension(inputFilePath, outputFormat);
            File.Copy(inputFilePath, outputFilePath, true);
            return outputFilePath;
        }
    }
}
