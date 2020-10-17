using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HudSample
{
    /// <summary>
    /// private bool _isDefective;
    /// public bool IsDefective
    /// {
    ///     get { return _isDefective; }
    ///     set { SetValue(ref _isDefective, value); }
    /// }
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetValue<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (!property.Equals(null) && property.Equals(value)) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Masks = new[] { "None", "Clear", "Black", "Gradient" };
            Types = new[] { "Normal", "Error", "Success", "Image" };
            Positions = new[] { "None", "Bottom", "Center", "Top" };
        }

        public string[] Masks { get; private set; }
        public string[] Types { get; private set; }
        public string[] Positions { get; private set; }

        private string message = "Hi world!";

        public string Message
        {
            get { return message; }
            set { this.SetValue(ref message, value); }
        }

        private int selectedMask = 0;

        public int SelectedMask
        {
            get { return selectedMask; }
            set { this.SetValue(ref selectedMask, value); }
        }

        private int selectedType = 0;

        public int SelectedType
        {
            get { return selectedType; }
            set { this.SetValue(ref selectedType, value); }
        }

        private int selectedPosition = 0;

        public int SelectedPosition
        {
            get { return selectedPosition; }
            set { this.SetValue(ref selectedPosition, value); }
        }

        private int timeout = 3;

        public int Timeout
        {
            get { return timeout; }
            set { this.SetValue(ref timeout, value); }
        }

        private float progress = -1F;

        public float Progress
        {
            get { return progress; }
            set { this.SetValue(ref progress, value); }
        }
    }
}