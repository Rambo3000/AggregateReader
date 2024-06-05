using AggregateReader.Config;
using AggregateReader.DataProviders;
using AggregateReader.DataProviders.RestServiceDataProvider;

namespace AggregateReader
{
    public partial class UsrRestServiceProvider : UserControl
    {
        private AggregateReaderConfig? Config;
        private Dictionary<string, DataProviderFactory>? Factories;

        public event EventHandler<string> XmlDataFetched;

        public UsrRestServiceProvider()
        {
            InitializeComponent();
            XmlDataFetched += UsrRestServiceProvider_XmlDataFetched;
        }

        private void UsrRestServiceProvider_XmlDataFetched(object? sender, string e)
        {
            btnGetFromUrl.Enabled = true;
        }

        public void LoadConfig(AggregateReaderConfig config)
        {
            Config = config;
            Factories = [];

            if (config.UrlConfigs == null) return;

            urlSelector.Items.Clear();
            foreach (UrlConfig urlConfig in config.UrlConfigs)
            {
                urlSelector.Items.Add(urlConfig.Name ?? string.Empty);
                Factories[urlConfig.Name ?? string.Empty] = new RestServiceProviderFactory(urlConfig);
            }
            if (urlSelector.Items.Count > 0) urlSelector.SelectedIndex = 0;
        }

        private RestServiceProviderFactory? GetRestServiceProviderFactory()
        {

            if (Factories == null) return null;

            string? selectedUrl = urlSelector.SelectedItem?.ToString();

            if (selectedUrl == null || !Factories.TryGetValue(selectedUrl, out DataProviderFactory? value))
            {
                btnGetFromUrl.Enabled = true;
                return null;
            }
            return (RestServiceProviderFactory)value;
        }

        private void BtnGetFromUrl_Click(object sender, EventArgs e)
        {
            RestServiceProviderFactory? restServiceProviderFactory = GetRestServiceProviderFactory();


            if (restServiceProviderFactory == null)
            {
                MessageBox.Show("Please select a valid URL.");
                return;
            }
            string id = txtId.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                btnGetFromUrl.Enabled = true;
                MessageBox.Show($"Please enter a {restServiceProviderFactory.UrlConfig.ParameterName}.");
                return;
            }

            if (restServiceProviderFactory.UrlConfig.Url == null) return;

            FetchDataAsync(restServiceProviderFactory, id);
        }

        private async void FetchDataAsync(RestServiceProviderFactory restServiceProviderFactory, string id)
        {
            try
            {
                btnGetFromUrl.Enabled = false;
                IDataProvider provider = restServiceProviderFactory.CreateProvider();
                string xmlContent = await Task.Run(() => provider.GetDataAsync(id));

                // Raise the event to return the XML data
                XmlDataFetched?.Invoke(this, xmlContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
            finally { btnGetFromUrl.Enabled = true; }
        }

        private void UrlSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            RestServiceProviderFactory? factory = GetRestServiceProviderFactory();
            lblId.Text = factory == null ? "" : factory.UrlConfig.ParameterName;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (Config == null) return;
            using UsrEditRestServiceConfig editForm = new(Config);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Reload the combo box with updated config
                urlSelector.Items.Clear();
                if (Config == null) return;
                LoadConfig(Config);
            }
            else
            {
                Config = ConfigManager.LoadConfig();
            }
        }
    }
}
