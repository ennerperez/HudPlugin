using System;
namespace Plugin.Hud
{
    public static class Extensions
    {
        public static void Show(this Models.Hud hud, Action clickCallback = null, Action cancelCallback = null)
        {
            switch (hud.Type)
            {
                case Abstractions.HudType.Normal:
                    CrossHud.Current.Show(hud.Message, hud.Progress, hud.Mask, hud.Centered, new TimeSpan(0, 0, hud.Timeout), clickCallback, hud.CancelCaption, cancelCallback);
                    break;
                case Abstractions.HudType.Error:
                    CrossHud.Current.ShowError(hud.Message, hud.Mask, new TimeSpan(0, 0, hud.Timeout), clickCallback, hud.CancelCaption, cancelCallback);
                    break;
                case Abstractions.HudType.Success:
                    CrossHud.Current.ShowSuccess(hud.Message, hud.Mask, new TimeSpan(0, 0, hud.Timeout), clickCallback, hud.CancelCaption, cancelCallback);
                    break;
                case Abstractions.HudType.Image:
                    CrossHud.Current.ShowImage(hud.Image, hud.Message, hud.Mask, new TimeSpan(hud.Timeout), clickCallback, hud.CancelCaption, cancelCallback);
                    break;
                default:
                    CrossHud.Current.ShowToast(hud.Message, hud.Mask, hud.Position, new TimeSpan(0, 0, hud.Timeout), clickCallback, cancelCallback);
                    break;
            }
        }

        public static void Dismiss(this Models.Hud hud)
        {
            CrossHud.Current.Dismiss();
        }
    }
}
