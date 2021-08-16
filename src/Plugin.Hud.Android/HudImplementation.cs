using Android.Graphics.Drawables;
using AndroidHUD;
using Plugin.Hud.Abstractions;
using System;
using System.Security;
using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

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
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Dismiss(Application.Context);
                //OnHide?.Invoke();
            });
        }

        //TODO: Find a way to change dialog message in Android
        public override void SetMessage(string message)
        {
            throw new NotImplementedException();
        }

        public override void Show(string message = null, float progress = -1F, Abstractions.MaskType mask = Abstractions.MaskType.Black, bool centered = true, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
                AndHUD.Shared.Show(Application.Context, message, (int)progress, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, centered, cancelCallback);
                //OnShown?.Invoke();
            });
        }

        public override void ShowError(string message = null, Abstractions.MaskType mask = Abstractions.MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
                if (string.IsNullOrEmpty(message))
                    AndHUD.Shared.ShowError(Application.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
                else
                    AndHUD.Shared.ShowErrorWithStatus(Application.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
                //OnShown?.Invoke();
            });
        }

        public override void ShowImage(object image, string message = null, Abstractions.MaskType mask = Abstractions.MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
                if (image is int @int)
                {
                    AndHUD.Shared.ShowImage(Application.Context, @int, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
                    //OnShown?.Invoke();
                }
                else if (image is ImageSource source)
                {
                    var handler = GetHandler(source);
                    var drawable = new BitmapDrawable(Application.Context.Resources, await handler.LoadImageAsync(source, Application.Context));
                    AndHUD.Shared.ShowImage(Application.Context, drawable, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
                    //OnShown?.Invoke();
                }
            });
        }

        private static IImageSourceHandler GetHandler(ImageSource imageSource)
        {
            //if (imageSource is SvgImageSource)
            //{
            //    return new SvgImageSourceHandler();
            //}
            if (imageSource is FontImageSource)
            {
                return new FontImageSourceHandler();
            }
            else if (imageSource is UriImageSource)
            {
                return new ImageLoaderSourceHandler();
            }
            else if (imageSource is FileImageSource)
            {
                return new FileImageSourceHandler();
            }
            else if (imageSource is StreamImageSource)
            {
                return new StreamImagesourceHandler();
            }
            return null;
        }

        public override void ShowSuccess(string message = null, Abstractions.MaskType mask = Abstractions.MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
                if (string.IsNullOrEmpty(message))
                {
                    AndHUD.Shared.ShowSuccess(Application.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
                    //OnShown?.Invoke();
                }
                else
                {
                    AndHUD.Shared.ShowSuccessWithStatus(Application.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, clickCallback, cancelCallback);
                    //OnShown?.Invoke();
                }
            });
        }

        public override void ShowToast(string message, Abstractions.MaskType mask = Abstractions.MaskType.Black, ToastPosition position = ToastPosition.Center, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (mask == Abstractions.MaskType.Gradient) mask = Abstractions.MaskType.Black;
                AndHUD.Shared.ShowToast(Application.Context, message, (AndroidHUD.MaskType)mask + 1, timeout, (position == ToastPosition.Center), clickCallback, cancelCallback);
                //OnShown?.Invoke();
            });
        }
    }
}