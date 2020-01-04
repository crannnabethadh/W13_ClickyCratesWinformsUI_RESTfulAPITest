using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
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
                    string playerToken = await APIHelper.Authenticate(UserEmailTextBox.Text, PasswordTextBox.Text);
                    // MessageBox.Show("Player token: " + playerToken, "Login correct", MessageBoxButtons.OK);
                    // TODO: Call api endpoint to get player data using token
                    Player loggeidInPlayer = await APIHelper.GetLoggedInPlayerInfo(playerToken);
                    FirstNameTextBox.Text = loggeidInPlayer.FirstName;
                    LastNameTextBox.Text = loggeidInPlayer.LastName;
                    NickNameTextBox.Text = loggeidInPlayer.NickName;
                    CityComboBox.Text = loggeidInPlayer.City;
                    PlayerAvatarPictureBox.ImageLocation = loggeidInPlayer.BlobUri;
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
            registerDialog.PlayerRegisteredEvent += RegisterDialog_PlayerRegisteredEvent;
            DialogResult result = registerDialog.ShowDialog(this);
            registerDialog.PlayerRegisteredEvent -= RegisterDialog_PlayerRegisteredEvent;
        }

        private void RegisterDialog_PlayerRegisteredEvent(object sender, Player e)
        {
            UserEmailTextBox.Text = e.Email;
            FirstNameTextBox.Text = e.FirstName;
            LastNameTextBox.Text = e.LastName;
            NickNameTextBox.Text = e.NickName;
            CityComboBox.Text = e.City;
            PlayerAvatarPictureBox.ImageLocation = e.BlobUri;
        }
    }
}
