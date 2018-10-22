using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Models;
using Windows.UI.Xaml;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Views.UsrControls
{
    public sealed partial class UC_AddContentList : UserControl
    {
        //Works for a string
        ObservableCollection<string> myCollection = new ObservableCollection<string>();
        public ObservableCollection<string> MyCollection
        { get { return myCollection; } }

        //Works for a Class-Model
        ObservableCollection<ContentLists> contentCollection = new ObservableCollection<ContentLists>();
        public ObservableCollection<ContentLists> ContentCollection
        {
            get
            {
                return contentCollection;
            }
        }
        public UC_AddContentList()
        {
            this.InitializeComponent();
        }

        private int i = 0;
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            i++;
            myCollection.Add(i.ToString());
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //Replace string with your object type
            while (myListBox.SelectedItems.Count > 0)
            {
                myCollection.Remove((string)myListBox.SelectedItem);
            }
        }

        private int x = 0;
        private void btnClassAdd_Click(object sender, RoutedEventArgs e)
        {
            x++;
            ContentLists c = new ContentLists();
            c.Id = c.Id + x;
            c.Category = c.Category + x;
            c.Title = c.Title + x;
            contentCollection.Add(c);
        }

        private void btnClassRemove_Click(object sender, RoutedEventArgs e)
        {

            //Replace Class with your object type
            while (myClassListBox.SelectedItems.Count > 0)
            {
                contentCollection.Remove((ContentLists)myClassListBox.SelectedItem);
            }
        }

    }
}
