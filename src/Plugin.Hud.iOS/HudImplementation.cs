using Foundation;
using System.Security;
using BigTed;
using System;
using System.Threading;
using Xamarin.Forms;

#if __IOS__ || __TVOS__
#elif __MACOS__
using AppKit;
#endif

using Plugin.Hud.Abstractions;

[assembly: Xamarin.Forms.Dependency(typeof(Plugin.Hud.HudImplementation))]

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
            });
        }

        public override void SetMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.SetStatus(message);
            });
        }

        //WIP: Timer implementation for autodismiss with [timeout] value
        internal class timerState
        {
            internal int counter = 0;
            internal Timer tmr;
        }

        internal void checkTimerState(object state)
        {
            var s = (timerState)state;
            s.counter++;

            if (s.counter == 1)
            {
                Dismiss();
            }
            else
            {
                s.tmr.Dispose();
                s.tmr = null;
            }
        }

        private void autoDismiss(TimeSpan timeout)
        {
            var s = new timerState();
            var timerDelegate = new TimerCallback(checkTimerState);
            var timer = new Timer(timerDelegate, s, timeout, timeout);
            s.tmr = timer;
            while (s.tmr != null)
                Thread.Sleep(0);
        }

        public override void Show(string message = null, float progress = -1F, MaskType mask = MaskType.None, bool centered = true, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (string.IsNullOrEmpty(cancelCaption))
                    BTProgressHUD.Show(message, progress, (ProgressHUD.MaskType)mask + 1);
                else
                    BTProgressHUD.Show(cancelCaption, cancelCallback, message, progress, (ProgressHUD.MaskType)mask + 1);

                if (timeout != null)
                    autoDismiss(timeout.Value);
            });
        }

        //TODO: ShowContinuousProgress

        public override void ShowError(string message = null, MaskType mask = MaskType.None, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.ShowErrorWithStatus(message, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
            });
        }

        public override void ShowImage(object image, string message = null, MaskType mask = MaskType.None, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.ShowImage((UIKit.UIImage)image, message, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
            });
        }

        public override void ShowSuccess(string message = null, MaskType mask = MaskType.None, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.ShowSuccessWithStatus(message, timeout.HasValue ? timeout.Value.TotalMilliseconds : 1000);
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
            });
        }
    }
}