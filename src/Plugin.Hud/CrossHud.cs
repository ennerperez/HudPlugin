using Plugin.Hud.Abstractions;
using System;

namespace Plugin.Hud
{
    /// <summary>
    /// Cross platform Hud implementations
    /// </summary>
    public class CrossHud
    {
        private static Lazy<ICrossHud> _implementation = new Lazy<ICrossHud>(() => CreateHud(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static ICrossHud Current
        {
            get
            {
                var ret = _implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        private static ICrossHud CreateHud()
        {
#if NETSTANDARD
            return null;
#else
            return new HudImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }

        /// <summary>
        /// Dispose of everything
        /// </summary>
        public static void Dispose()
        {
            if (_implementation != null && _implementation.IsValueCreated)
            {
                _implementation.Value.Dispose();
                _implementation = new Lazy<ICrossHud>(() => CreateHud(), System.Threading.LazyThreadSafetyMode.PublicationOnly);
            }
        }
    }
}