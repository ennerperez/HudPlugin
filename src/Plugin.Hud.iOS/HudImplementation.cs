using Foundation;
using System.Security;
using BigTed;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Threading.Tasks;

#if __IOS__ || __TVOS__
#elif __MACOS__
using AppKit;
#endif

using Plugin.Hud.Abstractions;

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
                BTProgressHUD.Dismiss();
                //OnHide?.Invoke();
            });
        }

        public override void SetMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.SetStatus(message);
            });
        }

        public override void Show(string message = null, float progress = -1F, MaskType mask = MaskType.None, bool centered = true, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (string.IsNullOrEmpty(cancelCaption))
                {
                    if (Math.Abs(progress - (-1.0F)) < 0)
                        BTProgressHUD.ShowContinuousProgress(message, (ProgressHUD.MaskType)(mask + 1));
                    else
                        BTProgressHUD.Show(message, progress, (ProgressHUD.MaskType)(mask + 1));
                }
                else
                {
                    if (Math.Abs(progress - (-1.0F)) < 0)
                        BTProgressHUD.ShowContinuousProgress(message, (ProgressHUD.MaskType)(mask + 1));
                    else
                        BTProgressHUD.Show(cancelCaption, cancelCallback, message, progress, (ProgressHUD.MaskType)(mask + 1));
                }

                //OnShown?.Invoke();

                if (timeout != null) { 
                    await Task.Delay(timeout.Value);
                    Dismiss();
                }

            });
        }

        public override void ShowError(string message = null, MaskType mask = MaskType.None, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.ShowErrorWithStatus(message, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
                //OnShown?.Invoke();
            });
        }

        public override void ShowImage(object image, string message = null, MaskType mask = MaskType.None, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (mask == MaskType.Gradient) mask = MaskType.Black;
                if (image is ImageSource source)
                {
                    var renderer = new StreamImagesourceHandler();
                    var uiimage = await renderer.LoadImageAsync(source);
                    BTProgressHUD.ShowImage(uiimage, message, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
                    //OnShown?.Invoke();
                }
                
            });
        }

        public override void ShowSuccess(string message = null, MaskType mask = MaskType.None, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.ShowSuccessWithStatus(message, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
                //OnShown?.Invoke();
            });
        }

        //TODO: ShowToast without mask?
        public override void ShowToast(string message, MaskType mask = MaskType.None, ToastPosition position = ToastPosition.None, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (position == ToastPosition.None)
                    BTProgressHUD.ShowToast(message, (ProgressHUD.MaskType)mask + 1, true, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
                else
                    BTProgressHUD.ShowToast(message, (ProgressHUD.ToastPosition)position, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
                //OnShown?.Invoke();
            });
        }

    }
}