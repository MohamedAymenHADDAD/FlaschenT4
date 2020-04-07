using Xamarin.Forms;
using FlaschenFi.Services;
using FlaschenFi.Views;
using System.Threading.Tasks;

namespace FlaschenFi
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<FlaschenDataStore>();
            DependencyService.Register<ArticleModelFactory>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
