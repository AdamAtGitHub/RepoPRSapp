using System;
using Models;
using Windows.UI.Xaml.Controls;

namespace Views.UsrControls
{
    public sealed partial class UC_DrillDown_ContentInfo : UserControl
    {
        private M_Content m_content;

        public M_Content M_Content
        {
            get { return m_content; }
            set
            {
                m_content = value;
                lblContentName.Text = m_content.ContentName;
                lblContentPlayTime.Text = m_content.ContentPlayTime;
                lblContentFileName.Text = m_content.ContentFileName;
                imgAllThreeMedTypes.Source = m_content.ProfilePicture;
            }
        }

        public UC_DrillDown_ContentInfo()
        {
            this.InitializeComponent();
        }
    }
}
