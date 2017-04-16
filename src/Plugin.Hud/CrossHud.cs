using Plugin.Hud.Abstractions;
using System;

namespace Plugin.Hud
{
    /// <summary>
    /// Cross platform Hud implementations
    /// </summary>
    public class CrossHud
    {
        private static Lazy<IHud> Implementation = new Lazy<IHud>(() => CreateHud(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IHud Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        private static IHud CreateHud()
        {
#if PORTABLE
            return null;
#else
            return new HudImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }

        /// <summary>
        /// Dispose of everything
        /// </summary>
        public static void Dispose()
        {
            if (Implementation != null && Implementation.IsValueCreated)
            {
                Implementation.Value.Dispose();
                Implementation = new Lazy<IHud>(() => CreateHud(), System.Threading.LazyThreadSafetyMode.PublicationOnly);
            }
        }
    }
}