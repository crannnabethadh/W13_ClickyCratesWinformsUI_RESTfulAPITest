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
        public event EventHandler<Player> PlayerRegisteredEvent;
        bool success = false;
        Player player;

        public RegisterDialog()
        {
            InitializeComponent();
            success = false;
            player = null;
        }

        private async void RegisterNewUserButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RegisterGroupBox.Enabled = false;
            AspNetUserModel aspPlayer = new AspNetUserModel();
            if (RegisterPasswordTextBox.Text == ConfirmRegiterPasswordTextBox.Text)
            {
                if (!string.IsNullOrEmpty(RegisterUserEmailTextBox.Text))
                {
                    aspPlayer.Email = RegisterUserEmailTextBox.Text;
                    aspPlayer.Password = RegisterPasswordTextBox.Text;
                    aspPlayer.ConfirmPassword = ConfirmRegiterPasswordTextBox.Text;

                    try
                    {
                        string newId = await APIHelper.RegisterNewAspNetUser(aspPlayer);
                        player = new Player();
                        player.Id = newId;
                        player.Email = RegisterUserEmailTextBox.Text;
                        player.FirstName = RegisterFirstNameTextBox.Text;
                        player.LastName = RegisterLastNameTextBox.Text;
                        player.NickName = RegisterNickNameTextBox.Text;
                        player.City = RegisterCityComboBox.Text;
                        string token = await APIHelper.Authenticate(RegisterUserEmailTextBox.Text, RegisterPasswordTextBox.Text);
                        success = await APIHelper.InsertNewPlayer(player, token);
                        this.Cursor = Cursors.Default;
                        RegisterGroupBox.Enabled = true;
                        if (success)
                        {
                            MessageBox.Show("New player registered successfully!", "Register player success", MessageBoxButtons.OK);
                            this.Close();  // Will trigger PlayerRegisteredEvent
                        }
                        else
                        {
                            MessageBox.Show("New player failed to register! Try again.", "Register player error", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong: " + ex.Message, "Register player error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void RegisterDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (success)
            {
                PlayerRegisteredEvent?.Invoke(this, player);  // Comunicate listeners there's a new player in the system
            }
        }
    }
}
