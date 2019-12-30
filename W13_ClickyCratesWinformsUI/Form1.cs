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
                    Player authenticatedPlayer = await apiHelper.Authenticate(UserEmailTextBox.Text, PasswordTextBox.Text);
                    MessageBox.Show("Player token: " + authenticatedPlayer.Access_Token, "Login correct", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Credentials are not correct. Try again\n (" + ex.Message + ")", "Login failed", MessageBoxButtons.OK);
                }
            }
        }
    }
}
