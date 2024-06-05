using AggregateReader.Config;

namespace AggregateReader.DataProviders.RestServiceDataProvider
{
    public partial class UsrEditRestServiceConfig : Form
    {
        private readonly AggregateReaderConfig Config;

        public UsrEditRestServiceConfig(AggregateReaderConfig config)
        {
            Config = config;
            InitializeComponent();
            LoadUrlList();
        }

        private void LoadUrlList()
        {
            lstNames.Items.Clear();
            if (Config.UrlConfigs == null) return;

            foreach (UrlConfig urlConfig in Config.UrlConfigs)
            {
                lstNames.Items.Add(urlConfig.Name ?? "");
            }
        }

        private bool IsUpdatingInputFields = false;

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UrlConfig newConfig = new()
            {
                Name = "New URL",
                Method = "GET",
                Url = "",
                JsonPath = "",
                BodyTemplate = ""
            };
            Config.UrlConfigs ??= [];
            Config.UrlConfigs.Add(newConfig);
            LoadUrlList();
            lstNames.SelectedIndex = lstNames.Items.Count - 1;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstNames.SelectedIndex;
            if (selectedIndex != -1 && Config.UrlConfigs != null)
            {
                lstNames.ClearSelected();
                Config.UrlConfigs.RemoveAt(selectedIndex);
                LoadUrlList();
                ClearTextBoxes();
            }
        }

        private void UpdateAfterNewInput(object sender, EventArgs e)
        {
            if (IsUpdatingInputFields) return;

            int selectedIndex = lstNames.SelectedIndex;
            if (selectedIndex != -1 && Config.UrlConfigs != null)
            {
                UrlConfig selectedConfig = Config.UrlConfigs[selectedIndex];
                selectedConfig.Name = txtName.Text;
                if (cboRequestMethod.SelectedItem != null) selectedConfig.Method = cboRequestMethod.SelectedItem.ToString();
                selectedConfig.Url = txtRequestUrl.Text;
                selectedConfig.JsonPath = txtResponseJsonPath.Text;
                selectedConfig.BodyTemplate = txtRequestBody.Text;
                selectedConfig.ParameterName = txtIdDescription.Text;
                LoadUrlList();
                lstNames.SelectedIndex = selectedIndex;
            }
        }

        private void ClearTextBoxes()
        {
            txtName.Text = "";
            txtRequestUrl.Text = "";
            cboRequestMethod.SelectedIndex = 0;
            txtRequestBody.Text = "";
            txtResponseJsonPath.Text = "";
            txtIdDescription.Text = "";
        }

        private void CboRequestMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRequestMethod.SelectedItem == null) return;
            txtRequestBody.Enabled = cboRequestMethod.SelectedItem.ToString() == "POST";
            UpdateAfterNewInput(sender, e);
        }

        private void LstNames_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            panel1.Enabled = lstNames.SelectedIndex != -1;
            btnRemove.Enabled = lstNames.SelectedIndex != -1;
            btnDown.Enabled = lstNames.SelectedIndex != -1 && lstNames.SelectedIndex < lstNames.Items.Count - 1;
            btnUp.Enabled = lstNames.SelectedIndex > 0 ;

            if (lstNames.SelectedIndex != -1 && Config.UrlConfigs != null)
            {
                IsUpdatingInputFields = true;
                UrlConfig selectedConfig = Config.UrlConfigs[lstNames.SelectedIndex];
                txtName.Text = selectedConfig.Name;
                cboRequestMethod.Text = selectedConfig.Method;
                txtRequestUrl.Text = selectedConfig.Url;
                txtResponseJsonPath.Text = selectedConfig.JsonPath;
                if (txtRequestBody.Text != selectedConfig.BodyTemplate) txtRequestBody.Text = selectedConfig.BodyTemplate;
                txtIdDescription.Text = selectedConfig.ParameterName;
                IsUpdatingInputFields = false;
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstNames.SelectedIndex;
            if (selectedIndex > 0 && Config.UrlConfigs != null)
            {
                var item = Config.UrlConfigs[selectedIndex];
                Config.UrlConfigs.RemoveAt(selectedIndex);
                Config.UrlConfigs.Insert(selectedIndex - 1, item);

                LoadUrlList();
                lstNames.SelectedIndex = selectedIndex - 1;
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstNames.SelectedIndex;
            if (selectedIndex < lstNames.Items.Count - 1 && Config.UrlConfigs != null)
            {
                var item = Config.UrlConfigs[selectedIndex];
                Config.UrlConfigs.RemoveAt(selectedIndex);
                Config.UrlConfigs.Insert(selectedIndex + 1, item);

                LoadUrlList();
                lstNames.SelectedIndex = selectedIndex + 1;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            ConfigManager.SaveConfig(Config);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
