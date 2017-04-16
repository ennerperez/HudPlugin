using AndroidHUD;
using Plugin.Hud.Abstractions;
using System.Security;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(Plugin.Hud.HudImplementation))]

namespace Plugin.Hud
{
    //[Android.Runtime.Preserve(AllMembers = true)]

    /// <summary>
    /// Hud implementation.
    /// </summary>
    [SecurityCritical]
    [Preserve(AllMembers = true)]
    public class HudImplementation : BaseHud
    {
        [SecurityCritical]
        public override void Dismiss()
        {
            AndHUD.Shared.Dismiss(Forms.Context);
        }

        [SecurityCritical]
        public override void Show()
        {
            AndHUD.Shared.Show(Forms.Context);
        }

        [SecurityCritical]
        public override void Show(string message)
        {
            AndHUD.Shared.Show(Forms.Context, message);
        }
    }
}