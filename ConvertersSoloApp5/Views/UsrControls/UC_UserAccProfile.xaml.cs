//using System; Commented as hint to remeber async / await won't 
//work w/o it, but it won't tell you.
//so filepickerSingleFileAsync() won't work
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace ConvertersSoloApp5.Views.UsrControls
{
    public sealed partial class UC_UserAccProfile : UserControl
    {
        public UC_UserAccProfile()
        {
            this.InitializeComponent();
        }
        private void FilePickProfileImg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImgProfile_TappedAsync(object sender, TappedRoutedEventArgs e)
        {

        }

        //Not wired
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCapturePhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        //May not need List in this UC
        private void listM_User_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
