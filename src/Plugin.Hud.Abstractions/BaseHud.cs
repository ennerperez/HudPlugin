using System;

namespace Plugin.Hud.Abstractions
{
    /// <summary>
    /// Base class for all Hud classes
    /// </summary>
    public abstract class BaseHud : ICrossHud
    {
        #region IHud

        public abstract void SetMessage(string message);

        public abstract void Show(string message = null, float progress = -1F, MaskType mask = MaskType.Black, bool centered = true, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);

        public abstract void ShowError(string message = null, MaskType mask = MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);

        public abstract void ShowSuccess(string message = null, MaskType mask = MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);

        public abstract void ShowImage(object image, string message = null, MaskType mask = MaskType.Black, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, string cancelCaption = null, Action cancelCallback = null);

        public abstract void ShowToast(string message, MaskType mask = MaskType.Black, ToastPosition position = ToastPosition.Center, TimeSpan? timeout = default(TimeSpan?), Action clickCallback = null, Action cancelCallback = null);

        public abstract void Dismiss();

        #endregion IHud

        #region IDisposable

        /// <summary>
        /// Dispose of class and parent classes
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose up
        /// </summary>
        ~BaseHud()
        {
            Dispose(false);
        }

        private bool _disposed;

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //dispose only
                }

                _disposed = true;
            }
        }

        #endregion IDisposable
    }
}