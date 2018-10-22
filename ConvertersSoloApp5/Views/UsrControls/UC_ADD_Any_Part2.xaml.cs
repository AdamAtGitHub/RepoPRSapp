using Models;
using System;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace ConvertersSoloApp5.Views.UsrControls
{
    public sealed partial class UC_ADD_Any_Part2 : UserControl
    {
        MediaCapture mediaCapture;
        BitmapImage theProfilePicture;

        public UC_ADD_Any_Part2()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            M_Content m_content = new M_Content();

            m_content.ContentName = boxContentName.Text;
            m_content.ContentPlayTime = boxContentPlayTime.Text;
            m_content.ContentFileName = boxContentFileName.Text;
            //Adding textbox for list part,
            //Details-Content Info page
            m_content.Notes = boxNotes.Text;

            if (theProfilePicture != null)
                m_content.ProfilePicture = theProfilePicture;

            UC_ContentInfo uc_contentInfo = new UC_ContentInfo();
            uc_contentInfo.M_Content = m_content;

            listM_Content.Items.Add(uc_contentInfo);
        }

        private void listM_Content_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = listM_Content.SelectedItem as UC_ContentInfo;
            //Frame.Navigate(typeof(ContentDetailsPage), selected.M_Content);
        }

        private async void ImgAllThreeMedTypes_TappedAsync(object sender, TappedRoutedEventArgs e)
        {
            mediaCapture = new MediaCapture();
            ////**Need web cam Or med capture device
            await mediaCapture.InitializeAsync();

            stackPreview.Visibility = Visibility.Visible;
            previewElement.Source = mediaCapture;

            await mediaCapture.StartPreviewAsync();
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            //*Note - can also capture video
            var imageFormat = ImageEncodingProperties.CreateJpeg();

            StorageFile storageFile =
              await ApplicationData.Current.LocalFolder.CreateFileAsync(
                "profilePicture.jpg", CreationCollisionOption.GenerateUniqueName);

            await mediaCapture.CapturePhotoToStorageFileAsync(imageFormat, storageFile);

            BitmapImage image = new BitmapImage(new Uri(storageFile.Path));

            theProfilePicture = new BitmapImage(new Uri(storageFile.Path));

            imgAllThreeMedTypes.Source = image;

            stackPreview.Visibility = Visibility.Collapsed;

            await mediaCapture.StopPreviewAsync();
        }
    }
}
