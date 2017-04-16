using System;

namespace Plugin.Hud.Abstractions
{
    /// <summary>
    /// Base class for all Hud classes
    /// </summary>
    public abstract class BaseHud : IHud, IDisposable
    {
        #region IHud

        public abstract void Show();

        public abstract void Show(string message);

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

        private bool disposed = false;

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose only
                }

                disposed = true;
            }
        }

        #endregion IDisposable
    }
}