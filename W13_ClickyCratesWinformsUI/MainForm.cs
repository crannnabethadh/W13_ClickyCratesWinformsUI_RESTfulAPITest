using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W13_ClickyCratesWinformsUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            await TryLogin();
        }

        private async Task TryLogin()
        {
            if (!string.IsNullOrEmpty(UserEmailTextBox.Text) && !string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                try
                {
                    APIHelper.InitializeClient();
                    string playerToken = await APIHelper.Authenticate(UserEmailTextBox.Text, PasswordTextBox.Text);
                    MessageBox.Show("Player token: " + playerToken, "Login correct", MessageBoxButtons.OK);
                    // TODO: Call api endpoint to get player data using token
                    Player loggeidInPlayer = await APIHelper.GetLoggedInPlayerInfo(playerToken);
                    FirstNameTextBox.Text = loggeidInPlayer.FirstName;
                    LastNameTextBox.Text = loggeidInPlayer.LastName;
                    NickNameTextBox.Text = loggeidInPlayer.NickName;
                    CityComboBox.Text = loggeidInPlayer.City;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Credentials are not correct. Try again\n (" + ex.Message + ")", "Login failed", MessageBoxButtons.OK);
                }
            }
        }

        private void RegisterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterDialog registerDialog = new RegisterDialog();
            DialogResult result = registerDialog.ShowDialog(this);

            // TODO: Implement event system that communicates successful player registration

            if (result == DialogResult.OK)
            {
                // user inserted correctly
                // Populate login and player data
                
            }
        }
    }
}
