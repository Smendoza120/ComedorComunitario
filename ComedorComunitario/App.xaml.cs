using ComedorComunitario.Views;

namespace ComedorComunitario
{
    public partial class App : Application
    {
        public App(HomePage homePage)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(homePage);
        }
    }
}
