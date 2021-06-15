using Plugin.Media;
using Xamarin.Forms;

namespace MyGarden
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CrossMedia.Current.Initialize();
            XF.Material.Forms.Material.Init(this);

            MainPage = new Paginas.TabbedPage1();
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
