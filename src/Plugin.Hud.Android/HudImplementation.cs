using AndroidHUD;
using Plugin.Hud.Abstractions;
using System;
using System.Security;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(Plugin.Hud.HudImplementation))]

namespace Plugin.Hud
{
    /// <summary>
    /// Hud implementation.
    /// </summary>
    [SecurityCritical]
    [Preserve(AllMembers = true)]
    public class HudImplementation : BaseHud
    {
        public override void Dismiss()
        {
            AndHUD.Shared.Dismiss(Forms.Context);
        }

        //TODO: Find a way to change dialog message in Android
        public override void SetMessage(string message)
        {
            throw new NotImplementedException();
        }

        public override void Show(string message = null, float progress = -1F, Abstractions.MaskType mask = Abstractions.MaskType.Black, bool centered = true, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
            AndHUD.Shared.Show(Forms.Context, message, (int)progress, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, centered, cancelCallback);
        }

        public override void ShowError(string message = null, Abstractions.MaskType mask = Abstractions.MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
            if (string.IsNullOrEmpty(message))
                AndHUD.Shared.ShowError(Forms.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
            else
                AndHUD.Shared.ShowErrorWithStatus(Forms.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
        }

        public override void ShowImage(object image, string message = null, Abstractions.MaskType mask = Abstractions.MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
            if (image.GetType() == typeof(int))
                AndHUD.Shared.ShowImage(Forms.Context, (int)image, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
            else
                AndHUD.Shared.ShowImage(Forms.Context, (Android.Graphics.Drawables.Drawable)image, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
        }

        public override void ShowSuccess(string message = null, Abstractions.MaskType mask = Abstractions.MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
            if (string.IsNullOrEmpty(message))
                AndHUD.Shared.ShowSuccess(Forms.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
            else
                AndHUD.Shared.ShowSuccessWithStatus(Forms.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
        }

        public override void ShowToast(string message, Abstractions.MaskType mask = Abstractions.MaskType.Black, ToastPosition position = ToastPosition.Center, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, Action cancelCallback = null)
        {
            if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
            AndHUD.Shared.ShowToast(Forms.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, (position == ToastPosition.Center), clickCallback, cancelCallback);
        }
    }
}