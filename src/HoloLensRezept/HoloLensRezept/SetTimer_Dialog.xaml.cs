using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class SetTimer_Dialog : ContentDialog
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(SetTimer_Dialog), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
            "Time", typeof(TimeSpan), typeof(SetTimer_Dialog), new PropertyMetadata(default(TimeSpan)));

        public SetTimer_Dialog()
        {
            this.InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        private void ContentDialog_AddButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            TimerManagement.timerlist.Add( Task.Run(TimerRun) );
        }

        private void ContentDialog_CancelButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        public async Task TimerRun()
        {
            int i = 0;
            DateTime end = DateTime.Now + Time;
            while(end > DateTime.Now)
            {
                i++;
                // busy wait
            }
            if(end <= DateTime.Now)
            {
                ContentDialog timerReady = new ContentDialog
                {
                    Title = "Timer",
                    Content = String.Format("Timer {0} has expired", Text),
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await timerReady.ShowAsync();
            }
        }
    }
}
