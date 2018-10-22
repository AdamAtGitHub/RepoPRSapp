using System.Diagnostics;
using System.Windows.Input;
using ViewModels.Commands;

namespace ViewModels
{
    public class ViewModelBase
    {
        public AddNewContentCmd AddNewContentCmd { get; set; }
        public DictationModeCmd DictationModeCmd { get; set; }

        public ViewModelBase()
        {
            AddNewContentCmd = new AddNewContentCmd(this);
            DictationModeCmd = new DictationModeCmd(this);
        }

        public void DictateMode()
        {
            Debug.WriteLine("In Dictate Mode");
        }

        public void AddNewContent()
        {
            Debug.WriteLine("Add New Content");
        }
    }
}
