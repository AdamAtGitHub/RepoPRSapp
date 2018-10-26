using System;
using System.Diagnostics;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ViewModels;
using System.Reflection;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ConvertersSoloApp5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Paths
        const string ENV_PROJ_PATH = "ms-appx:///Assets/AV/PlayLibray/Audio/";
        const string ENV_CENTRAL_PATH = @"C:\Users\Flazz\Music\AV\PlayLibray\Audio\";
        #endregion


        public MainPage()
        {
            this.InitializeComponent();

            PickAFileButton00.Click += new RoutedEventHandler(PickAFileButton_Click);
            PickAFileButton10.Click += new RoutedEventHandler(PickAFileButton_Click);
            ApplicationView view = ApplicationView.GetForCurrentView();
            bool IsInFullScreenMode = view.IsFullScreenMode;
            if (IsInFullScreenMode)
            {
                view.ExitFullScreenMode();
            }
            else
            {
                view.TryEnterFullScreenMode();
            }
        }

        #region PickAFileButton's Click event handler
        private async void PickAFileButton_Click(object sender, RoutedEventArgs e)
        {
            //BUG - with break point here, you can see somehow filepicker is raising
            //prop change for somedatetime
           
            #region Gets name prop of sender
            string name = Convert.ToString(e.OriginalSource.GetType().GetProperty("Name").GetValue(e.OriginalSource, null));
            // MessageBox.Show(name);
            if (name == "PickAFileButton00")
                // whatever is the code
                if (name == "PickAFileButton10")
                    // whatever is the code
                    #endregion

                    // Clear previous returned file name, if it exists, between iterations of this scenario
                    tbFilePicked.Text = "";

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
            openPicker.FileTypeFilter.Add(".m4v");
            openPicker.FileTypeFilter.Add(".avi");
            openPicker.FileTypeFilter.Add(".wav");
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".xml");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file

                tbFilePicked.Text = file.Name;
                TimeViewModel tvm = new TimeViewModel
                {
                    PickedFileName = tbFilePicked.Text
                };
                Debug.WriteLine("tvm.Full_Uri: \t{0}", tvm.Full_Uri);
            }
            else
            {
                tbFilePicked.Text = "Operation cancelled.";
            }
        }
        #endregion

        private void MenuFlyoutItem_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MenuFlyoutItem selectedItemFlyout = sender as MenuFlyoutItem;
            selectedItem.Text = "Selected item is " + selectedItemFlyout.Text.ToString();
        }
    }
}
