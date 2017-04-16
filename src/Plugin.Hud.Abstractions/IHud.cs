using System;

namespace Plugin.Hud.Abstractions
{
    /// <summary>
    /// Interface for Hud
    /// </summary>
    public interface IHud : IDisposable
    {
        /// <summary>
        /// Show this instance.
        /// </summary>
        void Show();

        /// <summary>
        /// Show the specified message.
        /// </summary>
        /// <returns>The show.</returns>
        /// <param name="message">Message.</param>
        void Show(string message);

        /// <summary>
        /// Dismiss this instance.
        /// </summary>
        void Dismiss();
    }
}