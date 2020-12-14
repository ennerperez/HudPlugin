using Plugin.Hud.Abstractions;

namespace Plugin.Hud.Models
{
    public class Hud 
    {
        public string Message { get; set; }

        public MaskType Mask { get; set; }

        public HudType Type { get; set; }

        public ToastPosition Position { get; set; }

        public int Timeout { get; set; }

        public float Progress { get; set; }

        public bool Centered { get; set; }

        public string CancelCaption { get; set; }

        public object Image { get; set; }
    }
}
