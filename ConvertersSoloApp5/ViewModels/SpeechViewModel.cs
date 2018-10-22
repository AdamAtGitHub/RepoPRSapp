
using Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels.Commands;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

namespace ViewModels
{
    public class SpeechViewModel : INotifyPropertyChanged
    {
        public MediaElement uiMediaElement { get; private set; }
        SpeechModel speechModel = new SpeechModel();

        #region Synthesize Ssml To SpeechAsync Methods

        async Task<IRandomAccessStream> SynthesizeSsmlToSpeechAsync(StorageFile ssmlFile)
        {
            // Windows.Storage.Streams.IRandomAccessStream
            IRandomAccessStream stream = null;
            // Windows.Media.SpeechSynthesis.SpeechSynthesizer
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                // Windows.Media.SpeechSynthesis.SpeechSynthesisStream
                string text = await FileIO.ReadTextAsync(ssmlFile);
                stream = await synthesizer.SynthesizeSsmlToStreamAsync(text);
            }
            return (stream);
        }
        async Task SpeakSsmlFileAsync(StorageFile ssmlFile, MediaElement mediaElement)
        {
            IRandomAccessStream stream = await SynthesizeSsmlToSpeechAsync(ssmlFile);
            // Send the stream to the media object.
            try
            {
                MediaElement mE = new MediaElement();
                mE.SetSource(stream, ssmlFile.ContentType);
                mE.Play();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: {0}", e.Message.ToString());
            }
            Debug.WriteLine("got past mediaElement.Play()");
        }
        #endregion

        #region Misc  Xml file Paths
        //path = "ms-appx:///Speech/SSML/UsageSyntax.xml";
        #endregion

        #region
        RelayCommand speakAsyncCommand;
        public ICommand SpeakAsyncCommand
        {
            get
            {
                if (speakAsyncCommand == null)
                {
                    speakAsyncCommand = new RelayCommand(
                    param => SpeakAsync(),
                    param => CanSpeakAsync
                    );
                };
                return speakAsyncCommand;
            }
        }
        public async void SpeakAsync()
        {
            //SpeakAsync Logic goes here
            Debug.WriteLine("from SpeakAsync()");
            try
            {
                // contentPath = content.Path.ToString();
                // Debug.WriteLine("content.Path : {0}", content.Path);
                if (speechModel.IsCmdMode != true)
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode  == true <-- Worked");
                    path = "ms-appx:///Speech/SSML/SED/en-ES/2ndPersonSingular/FU_Phase1_mb_1_0.xml";
                    Debug.WriteLine("property path value: {0}", path);
                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync
        {
            get { return true; }
        }
        #endregion

        #region  public class RelayCommand : ICommand
        //Create Relay Command that inherits ICommand Interface
        RelayCommand speakAsync20_DayPart2Command;
        public ICommand SpeakAsync20_DayPart2Command
        {
            get
            {
                if (speakAsync20_DayPart2Command == null)
                {
                    speakAsync20_DayPart2Command = new RelayCommand(
                    param => SpeakAsync20_DayPart2(),
                    param => CanSpeakAsync20_DayPart2Command
                    );
                };
                return speakAsync20_DayPart2Command;
            }
        }

        public async void SpeakAsync20_DayPart2()
        {
            try
            {
                if (speechModel.IsCmdMode != true)
                {
                    path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/20_DayPart2.xml";
                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync20_DayPart2Command
        {
            get { return true; }
        }
        #endregion

        private string path; //part of SDK Behaviors 
        //ex: private object selectionChangedCommand -below;

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("propName"));
        }
        #endregion

        #region public RelayCommand<IList<object>> SelectionChangedCommand -Not Working Yet.
        //{
        //    get
        //    {
        //        if (selectionChangedCommand == null)
        //        {
        //            selectionChangedCommand = new RelayCommand<IList<object>>(
        //                items =>
        //                {
        //                    // do something with selected items!
        //                    return selectionChangedCommand;
        //                }

        //            );
        //        }
        //        return selectionChangedCommand;
        //    }
        //}
        #endregion
    }
}