using System;

namespace Plugin.Hud.Abstractions
{
    /// <summary>
    /// Interface for Hud
    /// </summary>
    public interface IHud : IDisposable
    {
        void SetMessage(string message);
            
        void Show(string message = null, float progress = -1F, MaskType mask = MaskType.Black, bool centered = true, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);

        void ShowError(string message = null, MaskType mask = MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);

        void ShowSuccess(string message = null, MaskType mask = MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);

        void ShowImage(object image, string message = null, MaskType mask = MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);
        
        void ShowToast(string message, MaskType mask = MaskType.Black, ToastPosition position = ToastPosition.Center, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, Action cancelCallback = null);

        /// <summary>
        /// Dismiss this instance.
        /// </summary>
        void Dismiss();
    }
}