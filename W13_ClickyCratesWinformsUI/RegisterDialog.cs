using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W13_ClickyCratesWinformsUI
{
    public partial class RegisterDialog : Form
    {
        public event EventHandler<Player> PlayerRegisteredEvent;
        bool success = false;
        bool imageLoadedFromLocalFilesystem;
        Player player;
        CloudStorageAccount storageAccount;
        CloudBlobClient blobClient;
        CloudBlobContainer clickycratesBlobContainer;
        CloudBlobDirectory defaultDir;
        CloudBlobDirectory customDir;
        List<IListBlobItem> defaultBlobs = new List<IListBlobItem>();
        List<IListBlobItem> customBlobs = new List<IListBlobItem>();

        public RegisterDialog()
        {
            InitializeComponent();
            success = false;
            player = null;
        }

        private void RegisterDialog_Load(object sender, EventArgs e)
        {
            InitializeBlobStorage();
            GetRandomBlobFromAzureStorage();
        }

        private void InitializeBlobStorage()
        {
            try
            {
                // TODO: Refactor to store configuration string in App.config or better in Azure Key Vault
                storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=spdvistorage;AccountKey=gvceCorkm2MJlxNWsnSpfAJvEPGen+fN6aYkrYlS47O5prrnthfjnhz+ddEjUb/z8dlmHf4pf2QYXXCmLrGLsQ==;EndpointSuffix=core.windows.net");
                blobClient = storageAccount.CreateCloudBlobClient();
                clickycratesBlobContainer = blobClient.GetContainerReference("clickycrates-blobs");
                defaultDir = clickycratesBlobContainer.GetDirectoryReference("default");
                customDir = clickycratesBlobContainer.GetDirectoryReference("custom");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetRandomBlobFromAzureStorage()
        {
            try
            {
                defaultBlobs = defaultDir.ListBlobs().ToList();
                int randomIndex = new Random().Next(0, defaultBlobs.Count - 1);
                string randomBlobUri = defaultBlobs[randomIndex].Uri.AbsoluteUri;
                AvatarImagePictureBox.ImageLocation = randomBlobUri;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void RegisterNewUserButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RegisterGroupBox.Enabled = false;
            AvatarImageGroupBox.Enabled = false;

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
                        
                        player.BlobUri = await GetPlayerImageUri();

                        string token = await APIHelper.Authenticate(RegisterUserEmailTextBox.Text, RegisterPasswordTextBox.Text);

                        success = await APIHelper.InsertNewPlayer(player, token);

                        this.Cursor = Cursors.Default;
                        RegisterGroupBox.Enabled = true;
                        AvatarImageGroupBox.Enabled = true;

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
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private async Task<string> GetPlayerImageUri()
        {
            if (imageLoadedFromLocalFilesystem)
            {
                //// Upload new image as BlockBlob if not already in any of the container's folders
                
                // Set the blob's content type so that the browser knows to treat it as an image.
                string imageType = Path.GetExtension(AvatarImagePictureBox.ImageLocation);
                string imageFileName = Path.GetFileName(AvatarImagePictureBox.ImageLocation);
                //Upload new image as blockBlob
                CloudBlockBlob blockBlob = customDir.GetBlockBlobReference(imageFileName);
                blockBlob.Properties.ContentType = "image/" + imageType;
                await blockBlob.UploadFromFileAsync(AvatarImagePictureBox.ImageLocation);
                
                return blockBlob.Uri.AbsoluteUri;
            }
            else
            {
                // Image with same name already in storage?
                bool isInDefaultFolder = defaultBlobs.Contains(new CloudBlockBlob(new Uri(AvatarImagePictureBox.ImageLocation)));

                customDir = clickycratesBlobContainer.GetDirectoryReference("custom");
                customBlobs = customDir.ListBlobs().ToList();
                bool isInCustomFolder = customBlobs.Contains(new CloudBlockBlob(new Uri(AvatarImagePictureBox.ImageLocation)));
                if (isInCustomFolder || isInDefaultFolder)
                {
                    return AvatarImagePictureBox.ImageLocation;
                }
                else
                {
                    return string.Empty;
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

        private void LoadNewAvatarImageButton_Click(object sender, EventArgs e)
        {
            AvatarImageOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            AvatarImageOpenFileDialog.Filter = "Image Files(*.PNG;*.JPEG;*.JPG;*.GIF)|*.PNG;*.JPEG;*.JPG;*.GIF|All files (*.*)|*.*";
            if (AvatarImageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                AvatarImagePictureBox.ImageLocation = AvatarImageOpenFileDialog.FileName;
                imageLoadedFromLocalFilesystem = true;
            }
        }
    }
}
