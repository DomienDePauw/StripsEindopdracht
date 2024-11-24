using StripsBL.DTO;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Linq;

namespace StripsClientWPFStripView
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/") };
        }

        private void GetStripButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(IdTextBox.Text, out int stripId))
            {
                MessageBox.Show("Voer een geldig Id in.");
                return;
            }

            try
            {
                var response = _httpClient.GetAsync($"Strips/beheer/strip/{stripId}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Strip niet gevonden of er is iets fout gegaan.");
                    return;
                }
                var responseContent = response.Content.ReadAsStringAsync().Result;

                var strip = JsonSerializer.Deserialize<StripsDTO>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                TitleTextBox.Text = strip.Titel;
                NrTextBox.Text = strip.Nr?.ToString() ?? string.Empty;
                ReeksTextBox.Text = strip.Reeks;
                PublisherTextBox.Text = strip.Uitgeverij;
                AuthorsListBox.ItemsSource = strip.Auteurs.Select(a => a.Auteur).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
