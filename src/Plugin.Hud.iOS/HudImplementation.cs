using Foundation;
using System.Security;
using BigTed;

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
        [SecurityCritical]
        public override void Dismiss()
        {
            BTProgressHUD.Dismiss();
        }

        [SecurityCritical]
        public override void Show()
        {
            BTProgressHUD.Show(null, -1, ProgressHUD.MaskType.Black);
        }

        [SecurityCritical]
        public override void Show(string message)
        {
            BTProgressHUD.Show(message, -1, ProgressHUD.MaskType.Black);
        }
    }
}