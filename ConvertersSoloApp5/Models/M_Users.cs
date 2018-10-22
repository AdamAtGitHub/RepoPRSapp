using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Models
{
    public class M_Users
    {
        public string FName;
        public string LName;
        public string Email;//Also used for login
        public string Password;
        //Adding props forlist part 2,
        //Details-Content Info page
       
        public BitmapImage ProfilePicture;
        public string ContentInfo()
        {
            return string.Format("User info - FirstName is {0}, Last Name is {1}, and Email is {2}",
                                  FName, LName, Email);
        }
    }
}
