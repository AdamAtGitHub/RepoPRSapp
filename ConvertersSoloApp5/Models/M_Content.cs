using Windows.UI.Xaml.Media.Imaging;

namespace Models
{
    public class M_Content
    {
        public string ContentName;
        public string ContentPlayTime;
        public string ContentFileName;
        //Adding props for list part 2,  Details/Content Info page
        public string Notes;
        public BitmapImage ProfilePicture; 
        
        public string ContentInfo()
        {
            return string.Format("Content info - Name is {0}, Play Time is {1}, and file Name is {2}",
                                  ContentName, ContentPlayTime, ContentFileName);
        }
    }
}
