using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Views.UsrControls
{
    public sealed partial class UC_UserProfile : UserControl
    {
        public UC_UserProfile()
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
