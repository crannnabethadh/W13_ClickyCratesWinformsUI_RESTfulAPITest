using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W13_ClickyCratesWinformsUI
{
    public partial class RegisterDialog : Form
    {
        public RegisterDialog()
        {
            InitializeComponent();
        }

        private async void RegisterNewUserButton_Click(object sender, EventArgs e)
        {
            AspNetUserModel aspPlayer = new AspNetUserModel();
            if (RegisterPasswordTextBox.Text == ConfirmRegiterPasswordTextBox.Text)
            {
                if (!string.IsNullOrEmpty(RegisterUserEmailTextBox.Text))
                {
                    aspPlayer.Email = RegisterUserEmailTextBox.Text;
                    aspPlayer.Password = RegisterPasswordTextBox.Text;
                    aspPlayer.ConfirmPassword = ConfirmRegiterPasswordTextBox.Text;

                    APIHelper.InitializeClient();
                    string newId = await APIHelper.RegisterNewAspNetUser(aspPlayer);
                    // get new assigned id for aspnetuser, create a new player and insert it into Player table

                    Player player = new Player();
                    player.Id = newId;
                    player.FirstName = RegisterFirstNameTextBox.Text;
                    player.LastName = RegisterLastNameTextBox.Text;
                    player.NickName = RegisterNickNameTextBox.Text;
                    player.City = RegisterCityComboBox.Text;

                    string token = await APIHelper.Authenticate(RegisterUserEmailTextBox.Text, RegisterPasswordTextBox.Text);

                    bool success = await APIHelper.InsertNewPlayer(player, token);

                    if (success)
                    {
                        MessageBox.Show("New player registered successfully!", "Register player", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("New player failed to register!", "Register player", MessageBoxButtons.OK);
                    }

                }
            }
        }
    }
}
