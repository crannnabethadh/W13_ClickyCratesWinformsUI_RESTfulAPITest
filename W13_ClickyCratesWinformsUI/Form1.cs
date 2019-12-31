using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W13_ClickyCratesWinformsUI
{
    public partial class Form1 : Form
    {
        public Form1()
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
                    APIHelper apiHelper = new APIHelper();
                    string playerToken = await apiHelper.Authenticate(UserEmailTextBox.Text, PasswordTextBox.Text);
                    MessageBox.Show("Player token: " + playerToken, "Login correct", MessageBoxButtons.OK);
                    // TODO: Call api endpoint to get player data using token
                    Player loggeidInPlayer = await apiHelper.GetLoggedInPlayerInfo(playerToken);
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
    }
}
