using System;
using System.Collections.Generic;
using Plugin.Hud;
using Plugin.Hud.Abstractions;
using Xamarin.Forms;

namespace HudSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();

            this.buttonHUD.Clicked += buttonHUD_Clicked;
            this.buttonToast.Clicked += buttonToast_Clicked;
        }

        private void cancelDelegate()
        {
            var hud = CrossHud.Current;
            hud.Dismiss();
        }

        private void buttonHUD_Clicked(object sender, EventArgs e)
        {
            var model = (MainViewModel)BindingContext;
            var hud = CrossHud.Current;

            switch (model.SelectedType)
            {
                case 1:
                    hud.ShowError(model.Message, (MaskType)model.SelectedMask, timeout: new TimeSpan(0, 0, model.Timeout), cancelCallback: cancelDelegate);
                    break;
                case 2:
                    hud.ShowSuccess(model.Message, (MaskType)model.SelectedMask, timeout: new TimeSpan(0, 0, model.Timeout), cancelCallback: cancelDelegate);
                    break;
                case 3:
                    //TODO: Image implementation fix
                    var logo = ImageSource.FromUri(new Uri(@"https://raw.githubusercontent.com/ennerperez/HudPlugin/master/art/icon.png"));
                    hud.ShowImage(logo, model.Message, (MaskType)model.SelectedMask, timeout: new TimeSpan(0, 0, model.Timeout), cancelCallback: cancelDelegate);
                    break;
                default:
                    hud.Show(model.Message, model.Progress, (MaskType)model.SelectedMask, timeout: new TimeSpan(0, 0, model.Timeout), cancelCallback: cancelDelegate);
                    break;
            }

        }

        private void buttonToast_Clicked(object sender, EventArgs e)
        {
            var model = (MainViewModel)BindingContext;
            var hud = CrossHud.Current;

            hud.ShowToast(model.Message, (MaskType)model.SelectedMask, (ToastPosition)model.SelectedPosition, timeout: new TimeSpan(0, 0, model.Timeout), cancelCallback: cancelDelegate);

        }

    }
}
