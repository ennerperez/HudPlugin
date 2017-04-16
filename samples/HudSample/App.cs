using Plugin.Hud;
using Xamarin.Forms;

namespace HudSample
{
    public class App : Application
    {
        public App()
        {
            var showHUD = new Button
            {
                Text = "DisplayHUD"
            };

            showHUD.Clicked += (sender, args) =>
            {
                var hud = CrossHud.Current;
                hud.Show("Loading...");
            };

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = { showHUD }
                }
            };

            //MainPage.Appearing += (sender, e) =>
            //{
            //	var hud = CrossHud.Current;
            //	hud.Show("Loading...");
            //};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}