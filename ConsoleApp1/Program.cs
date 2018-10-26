using System;
using System.ComponentModel;

namespace ConsoleApp1
{
    class Program : CoreViewModel
    {       
        static void Main(string[] args)
        {
            CoreViewModel Cvm = new CoreViewModel
            {
                Path = @"C:\Users\Flazz\Music\AV\PlayLibray\PlayLists\Out\",
                PickedFileName = "Jessie.m4a",
            };
            
            Console.WriteLine("----INotifyPropertyChanged----\n");
            Console.WriteLine("\tPath: \n\t{0}", Cvm.Path);
            Console.WriteLine("\tPickedFileName: \n\t{0}", Cvm.PickedFileName);
            Console.WriteLine("\tFull_Uri: \n\t{0}", Cvm.Full_Uri);
            Console.ReadKey();
        }
    }

   public class CoreViewModel : INotifyPropertyChanged
    {
        #region RaisePropertyChanged Event & Method
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Path, PickedFileName, and Uri - Full Properties
        private string path;
        public string Path
        {
            get => path;
            set
            {
                path = value;
                RaisePropertyChanged("Path");
                RaisePropertyChanged("Full_Uri");
            }
        }

        private string pickedFileName;
        public string PickedFileName
        {
            get => pickedFileName;
            set
            {
                pickedFileName = value;
                RaisePropertyChanged("PickedFileName");
                RaisePropertyChanged("Full_Uri");
            }
        }

        private string full_Uri;
        public string Full_Uri
        {
            get => Path + PickedFileName;
            set
            {
                full_Uri = value;
                RaisePropertyChanged("Full_Uri");
            }
        }
        #endregion
    }

}
