using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlaschenFi.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenXingCommand = new Command(async () => await Browser.OpenAsync("https://www.xing.com/profile/MohamedAymen_HADDAD"));
            OpenLinkedInCommand = new Command(async () => await Browser.OpenAsync("https://www.linkedin.com/in/haddad-mohamed-aymen-37883274"));
        }

        public ICommand OpenXingCommand { get; }
        public ICommand OpenLinkedInCommand { get; }
    }
}
