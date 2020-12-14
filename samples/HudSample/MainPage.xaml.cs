using Plugin.Hud;
using Plugin.Hud.Abstractions;
using System;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace HudSample
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();

            ButtonHud.Clicked += buttonHUD_Clicked;
            ButtonToast.Clicked += buttonToast_Clicked;
            
        }

        private void Current_Hide()
        {
            ButtonHud.IsEnabled = true;
            ButtonToast.IsEnabled = true;
        }

        private void Current_Shown()
        {
            ButtonHud.IsEnabled = false;
            ButtonToast.IsEnabled = false;
        }

        private void CancelDelegate()
        {
            CrossHud.Current?.Dismiss();
            var model = (MainViewModel)BindingContext;
            CrossHud.Current?.ShowToast("Dismissed!", position: ToastPosition.Bottom, timeout: new TimeSpan(0, 0, model.Timeout));
        }

        private void ClickDelegate()
        {
            var model = (MainViewModel)BindingContext;
            CrossHud.Current?.ShowToast("Clicked!", position: ToastPosition.Bottom, timeout: new TimeSpan(0, 0, model.Timeout));
        }

        private async void buttonHUD_Clicked(object sender, EventArgs e)
        {
            var model = (MainViewModel)BindingContext;
            var hud = CrossHud.Current;

            Current_Shown();

            switch (model.SelectedType)
            {
                case 1:
                    hud.ShowError(model.Message, (MaskType)model.SelectedMask, new TimeSpan(0, 0, model.Timeout), ClickDelegate, model.CancelCaption, CancelDelegate);
                    break;
                    
                case 2:
                    hud.ShowSuccess(model.Message, (MaskType)model.SelectedMask, new TimeSpan(0, 0, model.Timeout), ClickDelegate, model.CancelCaption, CancelDelegate);
                    break;

                case 3:
                    var url = new Uri(@"https://raw.githubusercontent.com/ennerperez/HudPlugin/master/src/.editoricon.png");
                    using (var wc = new WebClient())
                    {
                        var data = await wc.DownloadDataTaskAsync(url);
                        var logo = ImageSource.FromStream(()=> new MemoryStream(data));
                        hud.ShowImage(logo, model.Message, (MaskType)model.SelectedMask, new TimeSpan(0, 0, model.Timeout), ClickDelegate, model.CancelCaption, CancelDelegate);
                    }
                    break;

                default:
                    hud.Show(model.Message, model.Progress, (MaskType)model.SelectedMask, model.Centered, new TimeSpan(0, 0, model.Timeout), ClickDelegate, model.CancelCaption, CancelDelegate);
                    break;
            }

            Current_Hide();
        }

        private void buttonToast_Clicked(object sender, EventArgs e)
        {
            var model = (MainViewModel)BindingContext;
            CrossHud.Current?.ShowToast(model.Message, (MaskType)model.SelectedMask, (ToastPosition)model.SelectedPosition, new TimeSpan(0, 0, model.Timeout), ClickDelegate, CancelDelegate);
        }
    }
}